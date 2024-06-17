namespace barberapi.Models
{
    public class BarberPK
    {
        public int Id { get; set; }
        public string name { get; set; }
        public double stars { get; set; }

        public bool favorited  {  get; set; }
        public List<Photos> photos { get; set; }
        public List<Services> services { get; set; }
        public List<Available> available { get; set; }   


    }

    public class Photos
    {
        public int Id { get; set; }

        public string url { get; set; }

    }

    public class Services
    {
        public string name { get; set; }
        public double price { get; set; }

    }

    public class Available
    {
        public string date { get; set; } 
        public string hours { get; set; }
    }

   
}
