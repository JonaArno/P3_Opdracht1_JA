SELECT
	Telefoon.Naam as TelefoonNaam, Telefoon.Nummer as TelefoonNummer, Contact.Id as ContactID, Contact.Naam as ContactNaam
	FROM Telefoon as Telefoon
	LEFT OUTER JOIN Contact as Contact 
		on Contact.ID = Telefoon.Contact




