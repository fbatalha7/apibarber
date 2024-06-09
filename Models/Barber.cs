using barberapi.Models;

namespace barberapi.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public double stars { get; set; }
        public string? city { get; set; }
        public string avatar { get; set; }
        public List<Barber>? ListAvailable { get; set; }        
        public List<Barber> DadosListaDisponivel()
        {

            List<Barber> barbeiros = new List<Barber>();
            if (barbeiros?.Count == 0 || barbeiros is null)
            {
                barbeiros?.Add(new Barber { city = "Coari", stars = 4.5, name = "ADMIM TESTE", Id = 1, avatar = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph" });
                barbeiros?.Add(new Barber { city = "Anori", stars = 4.5, name = "ADMIM TESTE", Id = 2, avatar = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph" });
                barbeiros?.Add(new Barber { city = "Manaus", stars = 4.5, name = "ADMIM TESTE", Id = 3, avatar = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph" });
            }

            return barbeiros;
         }

    }
}

