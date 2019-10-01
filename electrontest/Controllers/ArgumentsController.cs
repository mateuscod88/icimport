using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace electrontest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArgumentsController : ControllerBase
    {
        [HttpPost("AddNewTokenOperation")]
        public IActionResult AddNewTokenOperation([FromBody]ArgumentyStartuResponse argumentyStartuResponse)
        {
            return Ok();
        }
    }
}