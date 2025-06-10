using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.RegularExpressions;
using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Infrustructure;
using TestTask.Unistrim.Api.Interfaces;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Repositories;

    public class UserRepository : IUserRepository
    {
    private readonly TransactionDbContext _context;

    public UserRepository(TransactionDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> CreateAsync(User newUser)
    {
        try 
        {
            var existingUser = await _context.UserModels.FindAsync(newUser.Id);

            if(existingUser is not null)
            {
                return existingUser;
            }

            UserModel newUserModel = new()
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password,
            };

            await _context.UserModels.AddAsync(newUserModel);
            await _context.SaveChangesAsync();

            return newUserModel;
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при добавлении нового пользователя {ex.Message}");
        }
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.UserModels.Select(x => new User()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Password = x.Password,
        })
        .ToListAsync();
    }
}

