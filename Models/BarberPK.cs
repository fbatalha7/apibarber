namespace barberapi.Models
{
    public class BarberPK
    {
        public int Id { get; set; }
        public string name { get; set; }
        public double stars { get; set; }

        public bool favorited  {  get; set; }
        public List<string> photos { get; set; }
        public List<Services> services { get; set; }


    }

    public class Services
    {
        public string corte { get; set; }
        public double price { get; set; }

    }
}
