using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application;
using WebApplication1.Domain;

namespace WebApplication1.WebApi
{
    public class HomeController : Controller,IOutputPort
    {
        private IUserServices _services;
        private IActionResult? _viewModel;

        public HomeController(IUserServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser([FromBody] UserCreateRequest userRequest)
        {
            _services.SetOutputPor(this);
            _services.SaveUser(userRequest);
            return this._viewModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void Invaid()
        {
            throw new NotImplementedException();
        }


        void IOutputPort.Invaid() => this._viewModel = this.BadRequest("Error internal.");


        public void Ok(User user)
        {
            UserCreateResponse response = new UserCreateResponse();

            response.Id = user.Id;
            this._viewModel = this.Ok(response);
        
        }
        void IOutputPort.NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
