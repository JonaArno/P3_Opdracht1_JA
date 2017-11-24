
using System;

namespace ContactManager.Business 
{
    public class Persoon : Contact
    {
        public DateTime? GeboorteDatum { get; set; }

        public override string ToString()
        {
            return $"{GeboorteDatum:MM/dd/yyyy}";      

        }
    }
}