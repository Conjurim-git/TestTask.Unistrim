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

    public async Task<UserModel> ChangeUserAsync(UserForUpdate user)
    {

        var existingUser = await _context.UserModels.FindAsync(user.Id);
        if (existingUser is not null)
        {
            
           foreach (var property in _context.Entry(existingUser).Properties)
            {
                property.IsModified = false;
            }

            if (existingUser.FirstName == null || existingUser.FirstName == "string" )
            {
                if (existingUser.FirstName != user.FirstName)
                {
                    existingUser.FirstName = user.FirstName;
                    _context.Entry(existingUser).Property(u => u.FirstName).IsModified = true;
                }    
            }

            if (existingUser.LastName == null || existingUser.LastName == "string")
            {
                if (existingUser.LastName != user.LastName)
                {
                    existingUser.LastName = user.LastName;
                    _context.Entry(existingUser).Property(u => u.LastName).IsModified = true;
                }
            }

            if (existingUser.Email == null || existingUser.Email == "string")
            {
                if (existingUser.Email != user.Email)
                {
                    existingUser.Email = user.Email;
                    _context.Entry(existingUser).Property(u => u.Email).IsModified = true;
                }
            }

            if (existingUser.Password == null || existingUser.Password == "string")
            {
                if (existingUser.Password != user.Password)
                {
                    existingUser.Password = user.Password;
                    _context.Entry(existingUser).Property(u => u.Password).IsModified = true;
                }
            }
            await _context.SaveChangesAsync();
            return existingUser;
        }
        else
        {
            throw new KeyNotFoundException($"Пользователь с ID: {user.Id} не найден");
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