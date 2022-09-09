using Fintech.DA;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class IdentityTypeController : Controller
    {/*
        private readonly IIdentityTypeDA _identityTypeDA;





        public IdentityTypeController(IIdentityTypeDA identityTypeDA)
        {
            _identityTypeDA = identityTypeDA;
        }

        [HttpGet]
        [Route("IdentityType")]
        public async Task<IActionResult> GetIdentityType()
        {
            var identityTypes = await _identityTypeDA.GetIdentityTypes();

            


            

            return Ok(identityTypes);
        }*/
    }
}
