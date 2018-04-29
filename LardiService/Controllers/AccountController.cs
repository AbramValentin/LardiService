using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LardiApiService.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult AuthorizeUser(string userLogin, string userPassword)
        {
            if (userLogin == "valentin.abram@ukr.net")
            {
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
