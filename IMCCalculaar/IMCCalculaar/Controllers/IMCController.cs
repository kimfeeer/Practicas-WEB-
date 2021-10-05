using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IMCCalculaar.Entities;
using System.Text.Json;

namespace IMCCalculaar.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class IMCController : ControllerBase
    {
        [HttpPost]
        public string POST(persona dto)
        {
            double resul = Math.Round((dto.peso / (Math.Pow((dto.altura/100), 2))), 2);
            string msg = "";

            if(resul < 18.5)
            {
                msg = "tu peso es menor a lo normal";
            }

            if(resul >= 18.5 && resul <= 24.9)
            {
                msg = "tu peso es normal";
            }

            if(resul > 24.9 && resul <= 29.9)
            {
                msg = "tu peso es mayor a lo normal";
            }

            if(resul > 29.9)
            {
                msg = "tienes obesidad";
            }

            IMCE imc = new IMCE()
            {
                imc = resul,
                corporal = msg

            };

            string json = JsonSerializer.Serialize(imc);

            return json;
    }
    
    }
}