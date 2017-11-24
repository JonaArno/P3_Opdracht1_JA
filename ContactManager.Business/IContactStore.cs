using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Business
{
    public interface IContactStore
    {
        // indien filter ontbreekt : de eerste 50 teruggeven,
        // anders de eerste 50 waarvan de naam begint (case insensitive) met filter
        IEnumerable<Contact> Contacten(string filter);
        IEnumerable<Persoon> Personen(string filter);

        void Nieuw(Contact contact);
        void Wijzig(Contact contact);
        void Verwijder(Contact contact);

        // is deze persoon een contactpersoon van 1 of meer organisaties?
        bool IsContactPersoon(Persoon persoon);
    }
}
