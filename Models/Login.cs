using System.Text.Json.Serialization;

namespace barberapi.Models
{
    public class Login
    {
        public required string Email { get; set; }
        public required string? Password { get; set; }
        [JsonIgnore]
        public string? Token { get; set; } = "teste";

    }

    public class Cadastro : Login
    {
        public required string NomeUsuario { get; set; }
    }

}
