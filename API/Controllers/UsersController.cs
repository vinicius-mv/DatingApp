using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var members = await userRepository.GetMembersAsync();

        return Ok(members);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var member = await userRepository.GetMemberByUsernameAsync(username);

        if (member == null) return NotFound();

        return member;
    }
}
