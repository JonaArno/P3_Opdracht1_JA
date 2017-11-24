using System.Collections.Generic;
using ContactManager.Business;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Threading;

namespace ContactManager.AdoConnected
{
    public class ContactStore : IContactStore
    {
        //connectionstring nog weg te werken
        private const string connectionString = @"Server=(localdb)\MSSQLLocalDB;AttachDbFileName=|DataDirectory|\contacten.mdf;Initial Catalog=contacten;Integrated Security=true";

        public IEnumerable<Contact> Contacten(string filter)
        {
            const string cmdTextNoFilter =
                "SELECT TOP 50" +
                "Contact.Id, Contact.Naam, Contact.Straat, Contact.Locatie, Contact.Land, " +
                "Organisatie.ContactPersoon, Persoon.GeboorteDatum, " +
                "Organisatie.Id As OrganisatieId, Persoon.Id AS PersoonId," +
                "Contact2.Id AS Contact2Id, Contact2.Naam AS Contact2Naam, " +
                "Contact2.Straat AS Contact2Straat," +
                "Contact2.Locatie AS Contact2Locatie, Contact2.Land AS Contact2Land," +
                "Persoon2.GeboorteDatum AS Contact2GeboorteDatum " +
                "FROM               Contact as Contact " +
                "LEFT OUTER JOIN    Organisatie as Organisatie On Contact.Id = Organisatie.Id " +
                "LEFT OUTER JOIN    Persoon as Persoon ON Contact.Id = Persoon.Id " +
                "LEFT OUTER JOIN    Persoon as Persoon2 ON Organisatie.ContactPersoon = Persoon2.Id " +
                "LEFT OUter JOIN    Contact as Contact2 ON Persoon2.Id = Contact2.Id";


            var cmdText =
                 "SELECT " +
                    "Contact.Id, Contact.Naam, Contact.Straat, Contact.Locatie, Contact.Land, " +
                    "Organisatie.ContactPersoon, Persoon.GeboorteDatum, " +
                    "Organisatie.Id As OrganisatieId, Persoon.Id AS PersoonId," +
                    "Contact2.Id AS Contact2Id, Contact2.Naam AS Contact2Naam, " +
                    "Contact2.Straat AS Contact2Straat," +
                    "Contact2.Locatie AS Contact2Locatie, Contact2.Land AS Contact2Land," +
                    "Persoon2.GeboorteDatum AS Contact2GeboorteDatum " +
                    "FROM               Contact as Contact " +
                    "LEFT OUTER JOIN    Organisatie as Organisatie On Contact.Id = Organisatie.Id " +
                    "LEFT OUTER JOIN    Persoon as Persoon ON Contact.Id = Persoon.Id " +
                    "LEFT OUTER JOIN    Persoon as Persoon2 ON Organisatie.ContactPersoon = Persoon2.Id " +
                    "LEFT OUter JOIN    Contact as Contact2 ON Persoon2.Id = Contact2.Id " +
                    "WHERE Contact.Naam LIKE @Filter";



            if (String.IsNullOrWhiteSpace(filter)) cmdText = cmdTextNoFilter;

            using (var connection = new SqlConnection(connectionString))
            {
                var personen = new Dictionary<int, Persoon>();
                var lijst = new List<Contact>();

                using (var command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("Filter", $"{filter}%");

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (IsOrganisatie(reader))
                            {
                                lijst.Add(GetOrganisatie(personen, reader));
                            }
                            else
                            {
                                lijst.Add(GetPersoon(personen, reader));
                            }
                        }
                    }
                }
                return lijst;
            }
        }

        private Persoon GetPersoon(Dictionary<int, Persoon> personen, SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            if (personen.ContainsKey(id))
            {
                return personen[id];
            }
            var persoon = new Persoon();
            SetContactProperties(reader, persoon);
            var ordinal = reader.GetOrdinal("GeboorteDatum");
            DateTime? datum = reader.IsDBNull(ordinal) ? default(DateTime) : reader.GetDateTime(ordinal);
            persoon.GeboorteDatum = datum;
            personen[persoon.Id] = persoon;
            return persoon;
        }

        //properties in contactklasse opvullen
        private void SetContactProperties(SqlDataReader reader, Contact contact)
        {
            contact.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            contact.Naam = reader.GetString(reader.GetOrdinal("Naam"));
            contact.Adres.Straat = reader.GetString(reader.GetOrdinal("Straat"));
            contact.Adres.Locatie = reader.GetString(reader.GetOrdinal("Locatie"));
            contact.Adres.Land = reader.GetString(reader.GetOrdinal("Land"));
            contact.Telefoons = GetTelefoonInformatie(contact.Id);
        }

        private ICollection<Telefoon> GetTelefoonInformatie(int meegegevenId)
        {
            var telefoonCmdText =
                "SELECT Contact.Id, Telefoon.Naam as TelefoonNaam, Telefoon.Nummer as TelefoonNummer " +
                "FROM Contact as Contact " +
                "LEFT OUTER JOIN Telefoon as Telefoon ON Contact.Id = Telefoon.Contact " +
                "WHERE contact.Id = @Id and Telefoon.Nummer is not null";

            using (var connection = new SqlConnection(connectionString))
            {
                var lijst = new List<Telefoon>();

                using (var command = new SqlCommand(telefoonCmdText, connection))
                {
                    command.Parameters.AddWithValue("Id", $"{meegegevenId}");

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lijst.Add(GetTelefoon(reader));
                        }
                        return lijst;
                    }
                }
            }
        }

        private Telefoon GetTelefoon(SqlDataReader reader)
        {
            var telefoon = new Telefoon
            {
                TelefoonType = reader.GetString(reader.GetOrdinal("TelefoonNaam")),
                Nummer = reader.GetString(reader.GetOrdinal("TelefoonNummer"))
            };
            return telefoon;
        }

        private Organisatie GetOrganisatie(Dictionary<int, Persoon> personen, SqlDataReader reader)
        {
            var organisatie = new Organisatie();
            //Basisproperties instellen
            SetContactProperties(reader, organisatie);
            //Contactpersoon wordt toegevoegd/opgehaald uit dictionary en toegevoegd aan instantie van Organisatie
            if (HeeftContactPersoon(reader))
            {
                //id van contactpersoon wordt opgehaald uit reader
                var id = reader.GetInt32(reader.GetOrdinal("Contact2Id"));
                if (!personen.ContainsKey(id))
                {
                    personen[id] = GetContactPersoon(reader);
                }
                organisatie.ContactPersoon = personen[id];
            }
            return organisatie;
        }

        private Persoon GetContactPersoon(SqlDataReader reader)
        {
            var contact = new Persoon();
            contact.Id = reader.GetInt32(reader.GetOrdinal("Contact2Id"));
            contact.Naam = reader.GetString(reader.GetOrdinal("Contact2Naam"));
            contact.Adres.Straat = reader.GetString(reader.GetOrdinal("Contact2Straat"));
            contact.Adres.Locatie = reader.GetString(reader.GetOrdinal("Contact2Locatie"));
            contact.Adres.Land = reader.GetString(reader.GetOrdinal("Contact2Land"));
            var ordinal = reader.GetOrdinal("Contact2GeboorteDatum");
            contact.GeboorteDatum = reader.IsDBNull(ordinal) ? default(DateTime?) : reader.GetDateTime(ordinal);
            return contact;                                                 
        }

        private bool HeeftContactPersoon(SqlDataReader reader)      //als kolom ingevuld is, dan is er een contactpersoon
        {
            return !reader.IsDBNull(reader.GetOrdinal("ContactPersoon"));
        }

        private bool IsOrganisatie(SqlDataReader reader)
        {
            return !reader.IsDBNull(reader.GetOrdinal("OrganisatieId"));
        }

        //te gebruiken voor het zoekvenster
        public IEnumerable<Persoon> Personen(string filter)
        {
            //onnodige elementen nog uit query halen (Done)
            //gaf issues met GetContactPersoon call -> ZoekerGetContactPersoon gecreeërd
            var cmdTextZoekVenster =
                "SELECT Contact.Id, Naam, Straat, Locatie, Land FROM Contact INNER JOIN Persoon ON Contact.Id = Persoon.Id WHERE Contact.Naam LIKE @Filter";

            using (var connection = new SqlConnection(connectionString))
            {
                var lijst = new List<Persoon>();

                using (var command = new SqlCommand(cmdTextZoekVenster, connection))
                {
                    command.Parameters.AddWithValue("Filter", $"{filter}%");

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lijst.Add(ZoekerGetContactPersoon(reader));
                        }
                    }
                }
                return lijst;
            }
        }

        private Persoon ZoekerGetContactPersoon(SqlDataReader reader)
        {
            var contact = new Persoon();
            contact.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            contact.Naam = reader.GetString(reader.GetOrdinal("Naam"));
            contact.Adres.Straat = reader.GetString(reader.GetOrdinal("Straat"));
            contact.Adres.Locatie = reader.GetString(reader.GetOrdinal("Locatie"));
            contact.Adres.Land = reader.GetString(reader.GetOrdinal("Land"));
            return contact;
        }

        //SQL NAKIJKEN VOORALEER TE TESTEN
        public void Nieuw(Contact contact)
        {
            if (contact is Persoon)
            {
                var pers = contact as Persoon;
                var telArray = pers.Telefoons.ToList();

                var insertPersoonSql =
                    "INSERT INTO Contact(Naam, Straat, Locatie, Land) " +
                    "VALUES (@Naam, @Straat, @Locatie, @Land);" +
                    "INSERT INTO Persoon(Id, GeboorteDatum) " +
                    "VALUES (SCOPE_IDENTITY(), @GeboorteDatum);" +
                    "INSERT INTO Telefoon(Nummer, Naam, Contact)";

                for (var i = 0; i < pers.Telefoons.Count; i++)
                {
                    //Geeft deze scope identity wel de ID van contact mee of neemt hij de ID in telefoontabel over?
                    //Desnoods extra parameter voor de zekerheid?
                
                    insertPersoonSql += $"VALUES (@tel{i}Naam, @tel{i}Nummer, SCOPE_IDENTITY())";
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmdNieuwePersoon = new SqlCommand(insertPersoonSql, connection))
                    {
                        cmdNieuwePersoon.Parameters.AddWithValue("Naam", $"{pers.Naam}");
                        cmdNieuwePersoon.Parameters.AddWithValue("Straat", $"{pers.Adres.Straat}");
                        cmdNieuwePersoon.Parameters.AddWithValue("Locatie", $"{pers.Adres.Locatie}");
                        cmdNieuwePersoon.Parameters.AddWithValue("Land", $"{pers.Adres.Land}");

                        //is default van geboortedatum null?
                        cmdNieuwePersoon.Parameters.AddWithValue("GeboorteDatum", $"{pers.GeboorteDatum}");

                        for (var i = 0; i < pers.Telefoons.Count; i++)
                        {
                            cmdNieuwePersoon.Parameters.AddWithValue($"tel{i}Naam", $"{telArray[i].TelefoonType}");
                            cmdNieuwePersoon.Parameters.AddWithValue($"tel{i}Nummer", $"{telArray[i].Nummer}");
                        }
                        
                        connection.Open();
                        cmdNieuwePersoon.ExecuteNonQuery();
                    }
                }
            }

            else if (contact is Organisatie)
            {
                var org = contact as Organisatie;
                var telArray = org.Telefoons.ToList();
                
                var insertOrganisatieSql =
                    "INSERT INTO Contact(Naam, Straat, Locatie, Land) " +
                    "VALUES (@Naam, @Straat, @Locatie, @Land);" +
                    "INSERT INTO Organisatie(Id, ContactPersoon) " +
                    "VALUES (SCOPE_IDENTITY(), @ContactPersoon);" +
                    "INSERT INTO Telefoon(Nummer, Naam, Contact)";

                //Geeft deze scope identity wel de ID van contact mee of neemt hij de ID in telefoontabel over?
                //desnoods extra parameter voor de zekerheid?
                for (var i = 0; i < org.Telefoons.Count; i++)
                {
                    insertOrganisatieSql += $"VALUES (@tel{i}Naam, @tel{i}Nummer, SCOPE_IDENTITY())";
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmdNieuweOrganisatie = new SqlCommand(insertOrganisatieSql, connection))
                    {
                        cmdNieuweOrganisatie.Parameters.AddWithValue("Naam", $"{contact.Naam}");
                        cmdNieuweOrganisatie.Parameters.AddWithValue("Straat", $"{contact.Adres.Straat}");
                        cmdNieuweOrganisatie.Parameters.AddWithValue("Locatie", $"{contact.Adres.Locatie}");
                        cmdNieuweOrganisatie.Parameters.AddWithValue("Land", $"{contact.Adres.Land}");
                        
                        cmdNieuweOrganisatie.Parameters.AddWithValue("ContactPersoon", $"{org.ContactPersoon.Id}");

                        for (var i = 0; i < org.Telefoons.Count; i++)
                        {
                            cmdNieuweOrganisatie.Parameters.AddWithValue($"tel{i}Naam", $"{telArray[i].TelefoonType}");
                            cmdNieuweOrganisatie.Parameters.AddWithValue($"tel{i}Nummer", $"{telArray[i].Nummer}");
                        }

                        connection.Open();
                        cmdNieuweOrganisatie.ExecuteNonQuery();
                        
                    }
                }
            }

            else throw new NotImplementedException("Meegegeven object is geen geldige instantie van persoon of organisatie");
        }

        public void Wijzig(Contact contact)
        {
            if (contact is Persoon)
            {
                var pers = contact as Persoon;
                var telArray = pers.Telefoons.ToList();

                var updatePersoonSql =
                    "UPDATE Contact " +
                    "SET Contact.Naam = @Naam, " +
                    "Contact.Straat = @Straat, " +
                    "Contact.Locatie = @Locatie, " +
                    "Contact.Land = @Land " +
                    "WHERE Contact.Id = @Id;" +
                    "UPDATE Persoon " +
                    "SET Persoon.GeboorteDatum = @GeboorteDatum " +
                    "WHERE Persoon.Id = @Id;";
                    //telefoons nog toe te voegen
                    //methode 1: gebruiken van select om count te krijgen van bestaande telefoons dan met for- werken - als 0 -> Nieuwe lijnen invoeren
                    //methode 2: bestaande nummers schrappen en nieuwe collectie wegschrijven met INSERT
                    //TE IMPLEMENTEREN: 
                    //  - opvragen alle id's bestaande telefoonnummers voor bepaalde contactId
                    //  - deze telefoon-id's vergelijken met de id's van in het meegegeven object
                    //  - overeenkomstige id's updaten
                    //  - rest van de id's via INSERT in databank
                    //  - rest id's DELETE

                //for (var i = 0; i < pers.Telefoons.Count; i++)
                //{
                //    //Geeft deze scope identity wel de ID van contact mee of neemt hij de ID in telefoontabel over?
                //    insertPersoonSql += $"VALUES (@tel{i}Naam, @tel{i}Nummer, SCOPE_IDENTITY())";
                //}

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmdWijzigPersoon = new SqlCommand(updatePersoonSql, connection))
                    {
                        cmdWijzigPersoon.Parameters.AddWithValue("Id", $"{pers.Id}");

                        cmdWijzigPersoon.Parameters.AddWithValue("Naam", $"{pers.Naam}");
                        cmdWijzigPersoon.Parameters.AddWithValue("Straat", $"{pers.Adres.Straat}");
                        cmdWijzigPersoon.Parameters.AddWithValue("Locatie", $"{pers.Adres.Locatie}");
                        cmdWijzigPersoon.Parameters.AddWithValue("Land", $"{pers.Adres.Land}");

                        //is default van geboortedatum null?
                        cmdWijzigPersoon.Parameters.AddWithValue("GeboorteDatum", $"{pers.GeboorteDatum}");

                        for (var i = 0; i < pers.Telefoons.Count; i++)
                        {
                            cmdWijzigPersoon.Parameters.AddWithValue($"tel{i}Naam", $"{telArray[i].TelefoonType}");
                            cmdWijzigPersoon.Parameters.AddWithValue($"tel{i}Nummer", $"{telArray[i].Nummer}");
                        }

                        connection.Open();
                        cmdWijzigPersoon.ExecuteNonQuery();
                    }
                }
            }
            else if (contact is Organisatie)
            {
                var org = contact as Organisatie;
                var telArray = org.Telefoons.ToList();

                var updateOrganisatieSql =
                    "UPDATE Contact " +
                    "SET Contact.Naam = @Naam, " +
                    "Contact.Straat = @Straat, " +
                    "Contact.Locatie = @Locatie, " +
                    "Contact.Land = @Land " +
                    "WHERE Contact.Id = @Id;" +
                    "UPDATE Organisatie " +
                    "SET Organisatie.ContactPersoon = @ContactPersoonId " +
                    "WHERE Organisatie.Id = @Id;";
                //telefoons nog toe te voegen
                //methode 1: gebruiken van select om count te krijgen van bestaande telefoons dan met for- werken - als 0 -> Nieuwe lijnen invoeren
                //methode 2: bestaande nummers schrappen en nieuwe collectie wegschrijven met INSERT

                //for (var i = 0; i < pers.Telefoons.Count; i++)
                //{
                //    //Geeft deze scope identity wel de ID van contact mee of neemt hij de ID in telefoontabel over?
                //    insertPersoonSql += $"VALUES (@tel{i}Naam, @tel{i}Nummer, SCOPE_IDENTITY())";
                //}

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmdWijzigOrganisatie = new SqlCommand(updateOrganisatieSql, connection))
                    {
                        cmdWijzigOrganisatie.Parameters.AddWithValue("Id", $"{org.Id}");

                        cmdWijzigOrganisatie.Parameters.AddWithValue("Naam", $"{org.Naam}");
                        cmdWijzigOrganisatie.Parameters.AddWithValue("Straat", $"{org.Adres.Straat}");
                        cmdWijzigOrganisatie.Parameters.AddWithValue("Locatie", $"{org.Adres.Locatie}");
                        cmdWijzigOrganisatie.Parameters.AddWithValue("Land", $"{org.Adres.Land}");

                        cmdWijzigOrganisatie.Parameters.AddWithValue("ContactPersoonId", $"{org.ContactPersoon.Id}");

                        for (var i = 0; i < org.Telefoons.Count; i++)
                        {
                            cmdWijzigOrganisatie.Parameters.AddWithValue($"tel{i}Naam", $"{telArray[i].TelefoonType}");
                            cmdWijzigOrganisatie.Parameters.AddWithValue($"tel{i}Nummer", $"{telArray[i].Nummer}");
                        }

                        connection.Open();
                        cmdWijzigOrganisatie.ExecuteNonQuery();
                    }
                }
            }
        }

        //hier beetje yolo gedaan
        public void Verwijder(Contact contact)
        {
            if (contact is Persoon)
            {
                //wijzigen Tabel Organisatie
                //als contactpersoon, dan elke occurence in Organisatie.Contact op null gezet worden
                if (this.IsContactPersoon(contact as Persoon))
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        const string cmdVerwijderContactpersoonVanOrganisatie =
                            "UPDATE Organisatie as Organisatie " +
                            "SET Organisatie.ContactPersoon = NULL " +
                            "WHERE Organisatie.ContactPersoon = @ID;";

                        using (var command = new SqlCommand(cmdVerwijderContactpersoonVanOrganisatie, connection))
                        {
                            command.Parameters.AddWithValue("ID", $"{contact.Id}");

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }  
                
            }
            else if (contact is Organisatie)
            {
                
            }


            //verwijder uit telefoontabel (zowel persoon als organisatie)
            
            //verwijder uit contacttabel

        }

        //nut hiervan?
        public bool IsContactPersoon(Persoon persoon)
        {
            bool isContact = false;
          
            using (var connection = new SqlConnection(connectionString))
            {
                const string cmdContactId = "SELECT DISTINCT Organisatie.ContactPersoon FROM Organisatie WHERE Organisatie.Contactpersoon = @ID";
                using (var command = new SqlCommand(cmdContactId, connection))
                {
                    command.Parameters.AddWithValue("ID", $"{persoon.Id}");
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            isContact = true;
                        }
                    }
                }
            }
            return isContact;
        }
    }
}