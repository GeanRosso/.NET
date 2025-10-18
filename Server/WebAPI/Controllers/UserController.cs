using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface userInterface;

        public UserController(UserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTo>> AddUser([FromBody] CreateUserDto request)
        {
            await VerifyUserNameIsAvailableAsync(request.UserName);
            User user = new(request.UserName, request.Password);
            User created = await userInterface.AddAsync(user);
            UserDto dto = new();
            {
                id = created.Id,
                UserName = created.Username;
            }
            return created($"/users/{dto.id}", created);
        }
    }
}
