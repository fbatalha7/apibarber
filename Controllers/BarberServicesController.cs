﻿using barberapi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            var token = new{ token = "teste" } ;

            return Ok(JsonConvert.SerializeObject(token));
        }

        [HttpGet("barbersavailable")]
        public ActionResult<List<Barber>> BarbersAvailable(string City)
        {
            Barber barbeirosDisponiveis = new();

            barbeirosDisponiveis.ListAvailable = barbeirosDisponiveis.DadosListaDisponivel();
            
            if (City is null)
                return BadRequest(CityUnavailable());

            List<Barber> region = new();

            foreach (var item in barbeirosDisponiveis.ListAvailable)
                if (item.City.Equals(City))
                    region.Add(item);


            if (region.Count ==0 || region is null)
                return BadRequest(BarberUnavailable());

            var jsonreturn = new { data = region, error = 0, loc = City };

            string jsont = JsonConvert.SerializeObject(jsonreturn);


            return Ok(jsont);
        }

        private static string MsgRequiredField(string value) => $"O campo {value} é obrigatório!";
        private static string RegexForValideEmail() => @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        private static string BarberUnavailable() => "Nao ha barbeiros indiponiveis para sua regiao";
        private static string CityUnavailable() => "Por Favor, informe uma cidade.";
    }
}
