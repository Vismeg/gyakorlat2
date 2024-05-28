using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fogado.Models;
using Microsoft.EntityFrameworkCore;


namespace fogado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foglalasok : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var contex = new FoglalasokContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK, contex.Foglalasoks.Include(f => f.VendegNavigation).Include(f => f.SzobaNavigation).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
