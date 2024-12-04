using FinanceManagement.Business.Users.Services;
using FinanceManagement.Controllers.Mappers;
using FinanceManagement.Controllers.Models.Requests;
using FinanceManagement.Controllers.Models.Responses;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using BusinessModels = FinanceManagement.Business.Users.Models;

namespace FinanceManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] CreateUser request) 
        {
            BusinessModels.CreateUser createUser = request.Adapt<BusinessModels.CreateUser>();

            _userService.Save(createUser);

            Response response = ResponseMapper.Map(true);

            return Ok(response);
        }
    }
}