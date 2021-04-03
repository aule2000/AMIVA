<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
=======
﻿using Microsoft.AspNetCore.Authorization;
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
    /// Manage user's saving goals
    /// </summary>
    [ApiExplorerSettings(GroupName = "client")]
    [Authorize]
    [Produces("application/json")]
    [Route("savings")]
    [ApiController]
    public class SavingGoalController : ControllerBase
    {
        private readonly ISavingGoalsRepository _savingGoalsRepository;

        public SavingGoalController(ISavingGoalsRepository savingGoalsRepository)
        {
            _savingGoalsRepository = savingGoalsRepository;
        }

        [HttpGet("sorting/{id}")]
        public async Task<ActionResult<IReadOnlyList<SavingGoal>>> Get(
            [FromQuery(Name = "user-id")][Required] Guid userId,
            [FromQuery][Required] string sortingColumn,
            [FromQuery][Required] bool isAscending)
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
            return await _savingGoalsRepository.GetSortedGoals(user.Id,
=======
            if (sortingColumn == null)
                return BadRequest("'sortingColumn' must be specified");

            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            var sorted = await _savingGoalsRepository.GetSortedGoals(userId,
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
                new SortingModel { IsAscending = isAscending, SortingColumn = sortingColumn });
            return new ActionResult<IReadOnlyList<SavingGoal>>(sorted);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Store([FromBody][Required] SavingGoal goal)
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
            goal.UserId = user.Id;
=======
            if (goal == null)
                return BadRequest("'goal' must be specified");

            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == goal.UserId.ToString()))
                return Unauthorized();

>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
            return await _savingGoalsRepository.Create(goal);
        }

        [Route("goaledit/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = HttpContext.User;
            SavingGoal goal = await _savingGoalsRepository.GetById(id);

            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == goal.UserId.ToString()))
                return Unauthorized();

            await _savingGoalsRepository.Delete(goal);
            return Ok();
        }

        [Route("savings/goaledit")]
        [HttpPut]
        public async void Update(SavingGoal goal)
        {
            await _savingGoalsRepository.Update(goal);
        }
       


    }
}
