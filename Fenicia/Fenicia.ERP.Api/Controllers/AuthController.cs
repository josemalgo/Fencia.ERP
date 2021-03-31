using Fenicia.Application.Common.Interfaces.UseCases.Users;
using Fenicia.Application.UseCases.Users.Login;
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

        public AuthController(ILoginUserInteractor loginUserInteractor)
        {
            _loginUserInteractor = loginUserInteractor;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
