    SELECT  TOP 50
                Contact.Id, Contact.Naam, Contact.Straat, Contact.Locatie, Contact.Land, 
                Organisatie.ContactPersoon, Persoon.GeboorteDatum, 
                Organisatie.Id As OrganisatieId, Persoon.Id AS PersoonId,
                Contact2.Id AS Contact2Id, Contact2.Naam AS Contact2Naam, 
                Contact2.Straat AS Contact2Straat,
                Contact2.Locatie AS Contact2Locatie, Contact2.Land AS Contact2Land,
                Persoon2.GeboorteDatum AS Contact2GeboorteDatum,
				Telefoon.Naam as TelefoonNaam, Telefoon.Nummer as TelefoonNummer
                FROM				Contact as Contact 
                LEFT OUTER JOIN		Organisatie as Organisatie On Contact.Id = Organisatie.Id 
                LEFT OUTER JOIN		Persoon as Persoon ON Contact.Id = Persoon.Id 
                LEFT OUTER JOIN		Persoon as Persoon2 ON Organisatie.ContactPersoon = Persoon2.Id
                LEFT OUter JOIN		Contact as Contact2 ON Persoon2.Id = Contact2.Id
				LEFT OUTER JOIN		Telefoon as Telefoon ON Contact.Id = Telefoon.Contact

				ORDER BY Contact.Naam
                