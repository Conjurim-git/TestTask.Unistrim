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

    public async Task<UserModel> ChangeUserAsync(Guid id, string newFirstName, string newLastName, string newEmail, string newPassword)
    {
        var existingUser = await _context.UserModels.FindAsync(id);
        if (existingUser is not null)
        {
            
            UserModel changedUserModel = existingUser;

            _context.Entry(changedUserModel).Property(x => x.FirstName).CurrentValue = newFirstName;
            _context.Entry(changedUserModel).Property(x => x.LastName).CurrentValue = newLastName;
            _context.Entry(changedUserModel).Property(x => x.Email).CurrentValue = newEmail;
            _context.Entry(changedUserModel).Property(x => x.Password).CurrentValue = newPassword;

            await _context.SaveChangesAsync();
            return changedUserModel;
        }
        else
        {
            throw new KeyNotFoundException($"Пользователь с ID: {id} не найден");
        }
    }


    public async Task DeleteUserAsync(Guid id)
    {
        var userToRemove = await _context.UserModels.FindAsync(id);
        if (userToRemove != null)
        {
            _context.UserModels.Remove(userToRemove);
            await _context.SaveChangesAsync();
        }
        
        else 
        { 
            throw new KeyNotFoundException($"Пользователь с ID: {id} не найден"); 
        }
            
    }
  
}

//bool isUpdated = false;
//if (existingUser.FirstName != )
//{

//}