namespace barberapi.Models
{
    public class BarberPK
    {
        public int Id { get; set; }
        public bool favorited { get; set; }
        public List<string> photos { get; set; }
        public List<string> services { get; set; }


    }
}
