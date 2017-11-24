namespace ContactManager.Business
{
    public class Adres
    {
        public string Straat { get; set; }
        public string Locatie { get; set; }
        public string Land { get; set; }

        public override string ToString()
        {
            return $"{Straat} {Locatie} {Land}";
        }
    }
}