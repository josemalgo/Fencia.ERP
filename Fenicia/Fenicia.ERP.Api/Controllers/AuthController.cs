using Fenicia.Application.Common.Interfaces.UseCases.Users;
using Fenicia.Application.UseCases.Users.Get;
using Fenicia.Application.UseCases.Users.Login;
using Fenicia.Application.UseCases.Users.Register;
using Fenicia.Application.UseCases.Users.UpdateUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fenicia.ERP.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginUserInteractor _loginUserInteractor;
        private IRegisterUserInteractor _registerUserInteractor;
        private IUpdateUserInteractor _updateUserInteractor;
        private IGetAllUsersInteractor _getAllUsersInteractor;

        public AuthController(ILoginUserInteractor loginUserInteractor, IRegisterUserInteractor registerUserInteractor,
            IUpdateUserInteractor updateUserInteractor, IGetAllUsersInteractor getAllUsersInteractor)
        {
            _loginUserInteractor = loginUserInteractor;
            _registerUserInteractor = registerUserInteractor;
            _updateUserInteractor = updateUserInteractor;
            _getAllUsersInteractor = getAllUsersInteractor;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<GetAllUsersResponse>> Get()
        {
            return await _getAllUsersInteractor.Handle(new GetAllUsersRequest());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost, Route("login")]
        public async Task<ActionResult<LoginUserResponse>> Post([FromBody] LoginUserRequest request)
        {
            var token = await _loginUserInteractor.Handle(request);
            if(token.Token == null)
            {

            }

            return token;
        }

        // POST api/<UserController>
        [HttpPost, Route("register")]
        public async Task<ActionResult<RegisterUserResponse>> Post([FromBody] RegisterUserRequest request)
        {
            return await _registerUserInteractor.Handle(request);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Guid id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid || id != request.Id)
                return BadRequest(Guid.Empty);

            return await _updateUserInteractor.Handle(request);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
