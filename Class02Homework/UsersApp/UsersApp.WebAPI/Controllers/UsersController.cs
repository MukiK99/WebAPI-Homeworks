using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsersApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Users);
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The id can not be negative or 0!");
                }
                if (id > StaticDb.Users.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no user with id: {id}");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.Users[id - 1]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
            }
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            try
            {
                if (newUser is null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "User data is null");
                }
                if (newUser.Id < 0 || StaticDb.Users.Any(u => u.Id == newUser.Id))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please enter a unique id!");
                }
                if (string.IsNullOrEmpty(newUser.FirstName) || string.IsNullOrEmpty(newUser.LastName) || string.IsNullOrEmpty(newUser.Address))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please enter valid first name, valid last name and valid address.");
                }
                StaticDb.Users.Add(newUser);
                return StatusCode(StatusCodes.Status201Created, "New user created.");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
        [HttpDelete]
        public IActionResult DeleteUser([FromBody] User user)
        {
            try
            {
                if (user is null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "User data is null.");
                }

                var userToDelete = StaticDb.Users.FirstOrDefault(u =>
                u.Id == user.Id &&
                u.FirstName == user.FirstName &&
                u.LastName == user.LastName &&
                u.Address == user.Address);
                if (userToDelete == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "User not found.");
                }

                StaticDb.Users.Remove(userToDelete);
                return StatusCode(StatusCodes.Status200OK, "User deleted successfully.");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid user ID.");
                }

                var userToDelete = StaticDb.Users.FirstOrDefault(u => u.Id == id);

                if (userToDelete == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "User not found.");
                }

                StaticDb.Users.Remove(userToDelete);

                return StatusCode(StatusCodes.Status204NoContent, "User deleted successfully.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {e.Message}");
            }
        }


    }
}
