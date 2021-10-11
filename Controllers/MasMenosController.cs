using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiRest.Controllers
{
    [Route("api/masmenos")]
    [ApiController]
    public class MasMenosController : ControllerBase
    {

        private decimal[] masMenos(decimal[] numeros)
        {
            int numPos = 0, numNeutro = 0, numNegativo = 0;
            decimal cantidad = numeros.Length;
            for (int i = 0; i <= numeros.Length - 1; i++)
            {
                if (numeros[i] == 0)
                {
                    numNeutro++;
                }
                else if (numeros[i] > 0)
                {
                    numPos++;
                }
                else
                {
                    numNegativo++;
                }
            }

            decimal[] arr = { numPos / cantidad, numNeutro / cantidad, numNegativo / cantidad };
            return arr;
        }

        [HttpPost]
        public IActionResult ObtenerRespuesta(decimal[] numeros)
        {
            decimal[] arr = masMenos(numeros);
            return CreatedAtAction(nameof(ObtenerRespuesta), arr);
        }
    }
}
