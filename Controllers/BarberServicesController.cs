using barberapi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace barberapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberServicesController : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult Login([FromBody] Login login)
        {
            if (login.Email is null && login.Password is null)
                return BadRequest("Usuario ou senha invalidos!");

            string jsont = JsonConvert.SerializeObject(login);

            return Ok(jsont);
        }

        [HttpPost("logout")]
        public ActionResult logout()
        {
            return Ok(string.Empty);
        }

        [HttpPost("registeruser")]
        public ActionResult RegisterUser([FromBody] Cadastro cadastro)
        {
            if (cadastro.NomeUsuario is null)
                return BadRequest(MsgRequiredField(nameof(cadastro.NomeUsuario)));
            if (cadastro.Email is null)
                return BadRequest(MsgRequiredField(nameof(cadastro.Email)));
            if (Regex.IsMatch(cadastro.Email, RegexForValideEmail()))
                return BadRequest($"O Email informado nao e valido!");
            if (cadastro.Password is null)
                return BadRequest(MsgRequiredField(nameof(cadastro.Password)));

            var token = new { token = "teste" };

            return Ok(JsonConvert.SerializeObject(token));
        }

        [HttpPost("token")]
        public ActionResult TokenUser([FromBody] string tokenuser)
        {
            var token = new { token = "teste" };

            if (string.IsNullOrEmpty(tokenuser))
                token = new { token = "teste2" };

            return Ok(JsonConvert.SerializeObject(token));
        }

        [HttpGet("barbersavailable")]
        public ActionResult<List<Barber>> BarbersAvailable(string City = "")
        {
            Barber barbeirosDisponiveis = new();

            barbeirosDisponiveis.ListAvailable = barbeirosDisponiveis.DadosListaDisponivel();

            if (string.IsNullOrEmpty(City))
                return BadRequest(CityUnavailable());

            List<Barber> region = new();

            foreach (var item in barbeirosDisponiveis.ListAvailable)
                if (item.city.Equals(City))
                    region.Add(item);


            if (region.Count == 0 || region is null)
                return BadRequest(BarberUnavailable());

            var jsonreturn = new { data = region, error = 0, loc = City };

            string jsont = JsonConvert.SerializeObject(jsonreturn);


            return Ok(jsont);
        }

        [HttpGet("Barber")]
        public ActionResult<List<Barber>> GetBarber([FromQuery] int id)
        {
            Barber barbeirosDisponiveis = new();

            barbeirosDisponiveis.ListAvailable = barbeirosDisponiveis.DadosListaDisponivel();

            var barbeiro = barbeirosDisponiveis.ListAvailable.Find(x => x.Id == id);

            var days = GetDaysOfYear(DateTime.Now.Year);

            BarberPK services = new()
            {
                Id = id,
                name = barbeiro.name,
                favorited = true,
                stars = barbeiro.stars,
                photos = new()
                {
                    new()
                    {
                        Id = 1,
                        url = "https://attualizecontabil.com.br/wp-content/uploads/2020/06/imagem-texto-blog-2-300x200.jpg",
                    },
                     new()
                    {
                        Id = 2,
                        url = "https://attualizecontabil.com.br/wp-content/uploads/2020/06/imagem-texto-blog-4-300x200.jpg",
                    }
                },
                services = new()
                {
                    new() { name = "Masculino", price = 12.00},
                    new() { name = "infantil", price = 12.00}
                },
                available = days

            };


            var jsonreturn = new { data = services, error = 0 };

            string jsont = JsonConvert.SerializeObject(jsonreturn);


            return Ok(jsont);
        }

        private static List<DateTime> GetDaysOfYear(int year)
        {
            List<DateTime> days = new List<DateTime>();

            for (int month = 1; month <= 12; month++)
            {
                int daysInMonth = DateTime.DaysInMonth(year, month);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    days.Add(new DateTime(year, month, day));
                }
            }

            return days;
        }
        private static string MsgRequiredField(string value) => $"O campo {value} é obrigatório!";
        private static string RegexForValideEmail() => @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        private static string BarberUnavailable() => "Nao ha barbeiros indiponiveis para sua regiao";
        private static string CityUnavailable() => "Por Favor, informe uma cidade.";
    }
}
