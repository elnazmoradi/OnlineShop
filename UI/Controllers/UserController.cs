using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService userService;
    public UserController(IUserService userService)
    {
      this.userService = userService;
    }
    [HttpPost]
    [ActionName("Register")]
    [Route("/Register")]
    public IActionResult Register(User user)
    {
      var result = userService.InsertUserInfo(user);
      return Ok(result);
    }
  }
}
