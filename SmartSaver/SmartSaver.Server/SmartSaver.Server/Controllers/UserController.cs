using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSaver.Domain;
using SmartSaver.Domain.Models;
using SmartSaver.Domain.Repositories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartSaver.Server.Controllers
{
    /// <summary>
    /// Manage users
    /// </summary>
    [ApiExplorerSettings(GroupName = "client")]
    [Authorize]
    [Produces("application/json")]
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        //[HttpGet]
        //[Route("getid")]
        //public async Task<User> Get(Guid userId)
        //{
        //    return await _usersRepository.GetById(userId);
        //}

        [HttpGet]
<<<<<<< HEAD
        [Route("parser")]                           //all usershttps://localhost:5001/users/parser
        public  async Task<IReadOnlyList<User>> ParseUser()
        {
            return await _usersRepository.GetAll();
=======
        public async Task<ActionResult<User>> Get([FromQuery(Name = "user-id"), Required] Guid userId)
        {
            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            return await _usersRepository.GetById(userId);
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
        }


        [HttpPut]
<<<<<<< HEAD
        [Route("update")]
        public void Put(User user)
        {
           _usersRepository.Update(user.Id, user);
        }

        [HttpPost]
        [Route("add")]
        public async Task<Guid> CreateAsync([FromBody] User _user)
        {
               return await _usersRepository.Create(_user);
=======
        public async Task<IActionResult> Put([FromBody][Required] User user)
        {
            if (user == null)
                return BadRequest("'user' must be specified");

            var u = HttpContext.User;
            if (!u.IsInRole(UserRole.Admin) &&
                !u.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == user.Id.ToString()))
                return Unauthorized();

            user.HashedPassword = UserUtilities.EncryptPassword(user.HashedPassword, user.Email);
            await _usersRepository.Update(user);
            return Ok();
        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="value">User to be created. Guid does not need to be set (it will be ignored).
        /// "HashedPassword" is assumed to be just a plain password.
        /// Must have a unique username.</param>
        /// <returns>User that was uploaded. Will return 409 if username is not unique.</returns>
        [HttpPost("new")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<User>> Post([FromBody, Required] User value)
        {
            if (value == null)
                return BadRequest("'user' must be specified");

            if (await _usersRepository.GetByEmail(value.Email) != null)
                return Conflict();

            value.HashedPassword = UserUtilities.EncryptPassword(value.HashedPassword, value.Email);
            value.Id = Guid.Empty;

            await _usersRepository.Create(value);
            return StatusCode(201, value);
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
        }

        /// <summary>
        /// Deletes the specified user. Users can only delete themselves.
        /// </summary>
        /// <param name="username">Username of the user to delete</param>
        /// <returns></returns>
        [HttpDelete("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([Required] string username)
        {
            var user = HttpContext.User;
            if (username == null)
                return BadRequest("'username' must be specified");

            if (!user.IsInRole(UserRole.Admin) && user.Identity.Name != username)
                return Unauthorized();

            User u = await _usersRepository.GetByEmail(username);
            if (u == null)
                return NotFound();

            await _usersRepository.Delete(u);
            return Ok();
        }
    }
}
