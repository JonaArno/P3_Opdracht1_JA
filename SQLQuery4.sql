 SELECT 
                Contact.Id, Contact.Naam, Contact.Straat, Contact.Locatie, Contact.Land, 
                Persoon.GeboorteDatum, 
                Persoon.Id AS PersoonId
                FROM               Contact as Contact 
                LEFT OUTER JOIN    Organisatie as Organisatie On Contact.Id = Organisatie.Id
                LEFT OUTER JOIN    Persoon as Persoon ON Contact.Id = Persoon.Id 
				where organisatie.Id is null