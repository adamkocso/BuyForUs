using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace buyforus.Controllers.API
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpPut("api/reservation")]
        public async Task<ActionResult> ReserveHotel([FromBody] ApiReservationViewModel model)
        {
    }
}