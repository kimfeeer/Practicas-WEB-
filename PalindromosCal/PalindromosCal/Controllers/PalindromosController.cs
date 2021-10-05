using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalindromosCal.Entities;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PalindromosCal.Controllers
{
    public class PalindromosController
    {
        [HttpPost]
        public string POST(Frases dto)
        {
            string Frases = dto.frase.Replace(" ", String.Empty).ToLower();
            string caracter;
            string inverso = "";
            string msg;

            int i = Frases.Length;
            MatchCollection wordColl = Regex.Matches(dto.frase, @"[\W]+");

            for(int x = (i - 1); x >= 0; x--)
            {
                caracter = Frases.Substring(x, 1);
                inverso = inverso + caracter;
            }

            if (Frases == inverso)
            {
                msg = "Es un Palindromo";
            }
            else
            {
                msg = "No es un Palindromo";
            }
            
            palindromo palindromo = new palindromo()
            {
                frase = dto.frase,
                status = msg,
                numeropalabras = (wordColl.Count + 1)
            };

            string json = JsonSerializer.Serialize(palindromo);

            return json;
        }
    }
}