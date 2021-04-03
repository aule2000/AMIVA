<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartSaver.Domain.Models;
using SmartSaver.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartSaver.Server.Controllers
{
    /// <summary>
    /// Manage spending categories
    /// </summary>
    [ApiExplorerSettings(GroupName = "client")]
    [Authorize]
    [Produces("application/json")]
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Category>>> Get(
            [FromQuery(Name = "user-id"), Required] Guid userId,
            [FromQuery(Name = "per-page"), Required] int perPage = 10,
            [FromQuery, Required] int page = 1)
        {
<<<<<<< HEAD
            User user = new User();
            HttpClient client = new HttpClient();

            var req = await client.GetAsync("https://localhost:5001/users/parser");
            Task<string> c = req.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<List<User>>(c.Result);
            foreach (var g in res)
            {
                //Console.WriteLine("sadsasda " + g.Gmail);
                if (g.Logged == true)
                {
                   // Console.WriteLine("sadasdas");
                    user = new User()
                    {
                        Id = g.Id,    //randomize
                        Gmail = g.Gmail,
                        Card = g.Card,
                        Cash = g.Cash,
                        FullName = g.FullName,
                        UserImage = g.UserImage,
                        Logged = true,
                        Password = g.Password
                    };
                }
            }
            return await _categoriesRepository.GetAllUserCategories(user.Id, perPage, page);
=======
            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            var categories = await _categoriesRepository.GetAllUserCategories(userId, perPage, page);
            return categories == null ? NotFound() : new ActionResult<IReadOnlyList<Category>>(categories);
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Store(Category category)
        {
<<<<<<< HEAD
           

            User user = new User();
            HttpClient client = new HttpClient();
=======
            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == category.UserId.ToString()))
                return Unauthorized();
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b

            var req = await client.GetAsync("https://localhost:5001/users/parser");
            Task<string> c = req.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<List<User>>(c.Result);
            foreach (var g in res)
            {
                if (g.Logged == true)
                {
                    user = new User()
                    {
                        Id = g.Id,   
                        Gmail = g.Gmail,
                        Card = g.Card,
                        Cash = g.Cash,
                        FullName = g.FullName,
                        UserImage = g.UserImage,
                        Logged = true,
                        Password = g.Password
                    };
                }
            }
            category.UserId = user.Id;
            return await _categoriesRepository.Create(category);
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = HttpContext.User;
            Category cat = await _categoriesRepository.GetById(id);
            if (cat == null)
                return NotFound();

            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == cat.UserId.ToString()))
                return Unauthorized();

            await _categoriesRepository.Delete(cat);

            return Ok();
        }

        [Route("count")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> GetCount(Guid userId)
        {
<<<<<<< HEAD
            User user = new User();
            HttpClient client = new HttpClient();

            var req = await client.GetAsync("https://localhost:5001/users/parser");
            Task<string> c = req.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<List<User>>(c.Result);
            foreach (var g in res)
            {
                if (g.Logged == true)
                {
                    user = new User()
                    {
                        Id = g.Id,
                        Gmail = g.Gmail,
                        Card = g.Card,
                        Cash = g.Cash,
                        FullName = g.FullName,
                        UserImage = g.UserImage,
                        Logged = true,
                        Password = g.Password
                    };
                }
            }
            return await _categoriesRepository.GetCount(user.Id);
=======
            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            return await _categoriesRepository.GetCount(userId);
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
        }
    }
}
