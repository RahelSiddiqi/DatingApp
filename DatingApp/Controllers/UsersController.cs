using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Data;
using DatingApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository repo;
        private readonly IMapper mapper;
        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await repo.GetUsersAsync();
            var userToReturn = mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await repo.GetUserAsync(id);
            var userToReturn = mapper.Map<UserForDetailesDto>(user);
            return Ok(userToReturn);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdatenDto userUpdateDto)
        {
            if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var userRepo = await repo.GetUserAsync(id);
            mapper.Map(userUpdateDto, userRepo);

            if (await repo.SaveAllAsync())
                return NoContent();

            throw new Exception(message: $"User {id} Updating Failed");
        }

    }
}