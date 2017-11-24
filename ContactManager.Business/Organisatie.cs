
namespace ContactManager.Business 
{
    public class Organisatie : Contact
    {
        public Persoon ContactPersoon { get; set; }

        public override string ToString()
        {
            return $"{Naam}" + (ContactPersoon!=null? $" ({ContactPersoon.Naam})":"");
        }
    }
}