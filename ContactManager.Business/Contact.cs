using System.Collections.Generic;

namespace ContactManager.Business
{
    public class Contact
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Adres Adres { get; protected set; } = new Adres();
        public ICollection<Telefoon> Telefoons { get; set; } = new List<Telefoon>();      //toch andere manier van werken waarbij telefoonnummers tegelijkertijd opgehaald worden

        public override string ToString()
        {
            return $"{Naam}";
        }
    }    
}
