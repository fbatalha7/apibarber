using System.Text.Json.Serialization;

namespace barberapi.Models
{
    public class Login
    {
        public required string Email { get; set; }
        public required string? Password { get; set; }
        [JsonIgnore]
        public string? Token { get; set; } = "teste";
        [JsonIgnore]
        public string Avatar { get; set; } = "https://img.freepik.com/fotos-gratis/o-gato-vermelho-ou-branco-eu-no-estudio-branco_155003-13189.jpg?size=626&ext=jpg&ga=GA1.1.235991548.1717966240&semt=sph";
    }

    public class Cadastro : Login
    {
        public required string NomeUsuario { get; set; }
    }

}
