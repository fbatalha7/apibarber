using barberapi.Models;

namespace barberapi.Models
{
    public class Barber
    {
        public string? Name { get; set; }
        public double Stars { get; set; }
        public string? City { get; set; }
        public List<Barber>? ListAvailable { get; set;}
        public List<Barber> DadosListaDisponivel()
        {
            if (ListAvailable?.Count == 0 || ListAvailable is null)
            {
                ListAvailable?.Add(new Barber { City = "Coari", Stars = 4.5, Name = "ADMIM TESTE" });
                ListAvailable?.Add(new Barber { City = "Anori", Stars = 4.5, Name = "ADMIM TESTE" });
                ListAvailable?.Add(new Barber { City = "Manaus", Stars = 4.5, Name = "ADMIM TESTE" });
            }

            return ListAvailable;
        }

    }
}

