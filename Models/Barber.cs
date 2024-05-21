using barberapi.Models;

namespace barberapi.Models
{
    public class Barber
    {
        public string? Name { get; set; }
        public double Stars { get; set; }
        public string? City { get; set; }
        public List<Barber>? ListAvailable { get; set; }        
        public List<Barber> DadosListaDisponivel()
        {

            List<Barber> barbeiros = new List<Barber>();
            if (barbeiros?.Count == 0 || barbeiros is null)
            {
                barbeiros?.Add(new Barber { City = "Coari", Stars = 4.5, Name = "ADMIM TESTE" });
                barbeiros?.Add(new Barber { City = "Anori", Stars = 4.5, Name = "ADMIM TESTE" });
                barbeiros?.Add(new Barber { City = "Manaus", Stars = 4.5, Name = "ADMIM TESTE" });
            }

            return barbeiros;
         }

    }
}

