SELECT
                Contact.Id, Telefoon.Naam as TelefoonNaam, Telefoon.Nummer as TelefoonNummer
                FROM	Contact as Contact    
				LEFT OUTER JOIN		Telefoon as Telefoon ON Contact.Id = Telefoon.Contact
				WHERE Id = @
                