using System.Net;
using cw.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CW.Controllers;

[ApiController]
[Route("api/v1/")]

public class UserController: ControllerBase{
    private readonly CWDbContext _cWDbContext;

    public UserController(CWDbContext cWDbContext){
        _cWDbContext = cWDbContext;
    }

[HttpGet("users")]
public async Task<ActionResult<List<UserRequest>>> Get()
{
    var List = await _cWDbContext.users.Select(
        s => new UserRequest
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            EmailAddress = s.EmailAddress,
            Age = s.Age,
            BirthDate = s.BirthDate
        }
    ).ToListAsync();

    if (List.Count < 0)
    {
        return NotFound();
    }
    else
    {
        return List;
    }
}

[HttpPost("users")]
public async Task < HttpStatusCode > InsertUser(UserRequest userRequest) {
    var entity = new User() {
        Id = userRequest.Id,
        FirstName = userRequest.FirstName,
            LastName = userRequest.LastName,
            EmailAddress = userRequest.EmailAddress,
            BirthDate =  userRequest.BirthDate,
            Age = userRequest.Age
    };
    _cWDbContext.users.Add(entity);
    await _cWDbContext.SaveChangesAsync();
    return HttpStatusCode.Created;
}

[HttpPut("users/{id}")]
public async Task <HttpStatusCode> updateUser(int id, UserRequest userRequest)
{
    var existingUser = await _cWDbContext.users.FindAsync(id);
    if(existingUser==null){
        return HttpStatusCode.NotFound;
    }
    existingUser.FirstName = userRequest.FirstName;
    existingUser.LastName = userRequest.LastName;
    existingUser.EmailAddress = userRequest.EmailAddress;
    existingUser.Age = userRequest.Age;
    existingUser.BirthDate = userRequest.BirthDate;
    _cWDbContext.users.Update(existingUser);
    await _cWDbContext.SaveChangesAsync();
    return HttpStatusCode.OK;
 }

 [HttpDelete("users/{id}")]
 public async Task<HttpStatusCode> deleteUser(int id)
 {
    var existingUser = await _cWDbContext.users.FindAsync(id);
    if(existingUser== null){
        return HttpStatusCode.NotFound;
    }

    _cWDbContext.users.Remove(existingUser);
    await _cWDbContext.SaveChangesAsync();

    return HttpStatusCode.NoContent;
 }

 [HttpGet("users/{id}")]
 public async Task<UserResponse> getUserById(int id){
    var user = await _cWDbContext.users.FindAsync(id);
    var response = new UserResponse();
    if(user == null){
        return response;
    }

    response.Id = user.Id;
    response.FirstName = user.FirstName;
    response.LastName = user.LastName;
    response.EmailAddress = user.EmailAddress;
    response.Age = user.Age;
    response.BirthDate = user.BirthDate;

    return response;
 }

    
}