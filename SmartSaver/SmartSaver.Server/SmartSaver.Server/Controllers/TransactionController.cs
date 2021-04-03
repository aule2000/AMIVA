<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSaver.Domain.Enums;
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
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
    /// Manage user's transactions
    /// </summary>
    [ApiExplorerSettings(GroupName = "client")]
    [Authorize]
    [Produces("application/json")]
    [Route("transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public TransactionController(
            ITransactionsRepository transactionsRepository,
            IUsersRepository usersRepository,
            ICategoriesRepository categoriesRepository)
        {
            _transactionsRepository = transactionsRepository;
            _usersRepository = usersRepository;
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet("sorting/{id}")]
        public async Task<ActionResult<IReadOnlyList<Transaction>>> Get(
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
            return await _transactionsRepository.GetSortedUserTransactions(user.Id,
=======
            if (sortingColumn == null)
                return BadRequest("'sortingColumn' must be specified");

            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            var sorted = await _transactionsRepository.GetSortedUserTransactions(userId,
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
                new SortingModel { IsAscending = isAscending, SortingColumn = sortingColumn });
            return new ActionResult<IReadOnlyList<Transaction>>(sorted);
        }

        [HttpGet("last/{count}")]
        public async Task<ActionResult<IReadOnlyList<Transaction>>> GetLast(
            [FromQuery(Name = "user-id")][Required] Guid userId,
            [FromQuery][Required] int count)
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
            return await _transactionsRepository.GetLastTransactions(user.Id, count);
=======
            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            var last = await _transactionsRepository.GetLastTransactions(userId, count);
            return new ActionResult<IReadOnlyList<Transaction>>(last);
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
        }

        [HttpGet("grouped")]
        public async Task<ActionResult<IReadOnlyList<GroupedTransaction>>> GetGroupedByCategory(
            [FromQuery(Name = "user-id")][Required] Guid userId)
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
            return await _transactionsRepository.GetAmountSpentPerCategory(user.Id);
        }
=======
            var user = HttpContext.User;
            if (!user.IsInRole(UserRole.Admin) &&
                !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b

            var grouped = await _transactionsRepository.GetAmountSpentPerCategory(userId);
            return new ActionResult<IReadOnlyList<GroupedTransaction>>(grouped);
        }

        /// <summary>
        /// Add new transaction. Transaction cannot result in negative balance.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("spend")]
        public async Task<IActionResult> AddNewSpending([FromBody][Required] Transaction transaction)
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
            var user1 = await _usersRepository.GetById(user.Id);
            var balance = user1.GetType().GetProperty(transaction.BalanceType);
            var balanceAmount = (double)balance.GetValue(user1);

            transaction.UserId = user1.Id;
=======
            if (transaction == null)
                return BadRequest("'transaction' must be specified");

            var u = HttpContext.User;
            if (!u.IsInRole(UserRole.Admin) &&
                !u.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == transaction.UserId.ToString()))
                return Unauthorized();
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b

            var user = await _usersRepository.GetById(transaction.UserId);
            var balance = user.GetBalance(transaction.BalanceType);

            if (balance >= transaction.AmountDouble)
            {
<<<<<<< HEAD
                balance.SetValue(user1, balanceAmount - transaction.AmountDouble);

                await _usersRepository.Update(user1.Id, user1);
=======
                user.SetBalance(transaction.BalanceType, balance - transaction.AmountDouble);

                await _usersRepository.Update(user);
>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
                await _transactionsRepository.Create(transaction);

                return Ok();
            }

            return BadRequest("Transaction cannot result in negative balance");
        }

        [HttpPut("{userId}/{type}/{category}/{description}/{amount}")]
        public async Task<ActionResult> SpendExtension(
            [FromQuery(Name = "user-id")][Required] Guid userId,
            BalanceType type,
            [FromQuery][Required] string category,
            [FromQuery(Name = "spend-amount")][Required] double spendAmount,
            [FromQuery] string description = null)
        {
            if (category == null)
                return BadRequest("'transaction' must be specified");

            var u = HttpContext.User;
            if (!u.IsInRole(UserRole.Admin) &&
                !u.HasClaim(c => c.Type == ClaimTypes.NameIdentifier && c.Value == userId.ToString()))
                return Unauthorized();

            Category getCategory = await _categoriesRepository.GetCategoryByName(category);

            if (getCategory != null)
            {
                var user = await _usersRepository.GetById(userId);
                var balance = user.GetBalance(type);

                if (balance >= spendAmount)
                {
                    var transaction = new Transaction
                    {
                        AmountDouble = spendAmount,
                        BalanceType = type,
                        CategoryId = getCategory.Id,
                        CreatedAt = DateTime.UtcNow,
                        Description = description,
                        UserId = userId
                    };

                    user.SetBalance(type, balance - spendAmount);

                    await _transactionsRepository.Create(transaction);
                    await _usersRepository.Update(user);

                    return Ok();
                }

                return BadRequest("Transaction cannot result in negative balance");
            }

            return NotFound();
        }
    }
}
