using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ContactManager.Business
{
    public class Telefoon
    {
        public string TelefoonType { get; set; }
        public string Nummer { get; set; }

        //In the past when I've wanted to do something like this, I expose a property called FormattedPhoneNumber which returns 
        //the formatted phone number for display purposes, and the edit box just binds to plain old unformatted PhoneNumber

        //public override string ToString()
        //{
        //    return String.Format("Name : {0}, number {1}, date {2}, salary {3}", _name, _number, _date, _salary);
        //}
    
}
}