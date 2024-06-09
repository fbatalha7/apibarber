using barberapi.Models;

namespace barberapi.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Stars { get; set; }
        public string? City { get; set; }
        public string Avatar { get; set; }
        public List<Barber>? ListAvailable { get; set; }        
        public List<Barber> DadosListaDisponivel()
        {

            List<Barber> barbeiros = new List<Barber>();
            if (barbeiros?.Count == 0 || barbeiros is null)
            {
                barbeiros?.Add(new Barber { City = "Coari", Stars = 4.5, Name = "ADMIM TESTE", Id = 1, Avatar = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph" });
                barbeiros?.Add(new Barber { City = "Anori", Stars = 4.5, Name = "ADMIM TESTE", Id = 2, Avatar = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph" });
                barbeiros?.Add(new Barber { City = "Manaus", Stars = 4.5, Name = "ADMIM TESTE", Id = 3, Avatar = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph" });
            }

            return barbeiros;
         }

    }
}

