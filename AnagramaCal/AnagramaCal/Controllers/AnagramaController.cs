using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramaCal.Entities;
using System.Text.Json;
namespace AnagramaCal.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class AnagramaController
    {
         [HttpPost]
        public string POST(Palabras dto)
        {
            string palabra1 = String.Concat(dto.Palabra1.ToLower().OrderBy(c => c));
            string palabra2 = String.Concat(dto.Palabra2.ToLower().OrderBy(c => c));
            string msg;

            if (palabra1 == palabra2)
            {
                msg = "estas palabras conforman un anagrama";
            }
            else
            {
                msg = "no es anagrama, puedes probar con estas palabras: ";
            }

            Anagrama anagrama = new Anagrama()
            {
                Palabra1 = dto.Palabra1,
                Palabra2 = dto.Palabra2,
                Estatus = msg,
            };

            string json = JsonSerializer.Serialize(anagrama);

            return json;
        }
    }
}