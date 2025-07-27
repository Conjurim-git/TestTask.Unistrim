using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.RegularExpressions;
using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Infrustructure;
using TestTask.Unistrim.Api.Interfaces;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Repositories;

public class UserDiscountRepository : IUserDiscountRepository
{
    private readonly TransactionDbContext _context;

    public UserDiscountRepository(TransactionDbContext context)
    {
        _context = context;
    }
    public async Task<List<DiscountPropertiesModel>> CreateDiscountByListAsync(List<Guid> discountIds)
    {
        var newDiscounts = new List<DiscountPropertiesModel>();
        foreach (var discountId in discountIds)
        {
            DiscountPropertiesModel newDiscount = new()
            {
                Id = discountId,
                IsDiscount = true,
                ValueOfDiscount = 0.8M,
            };
            newDiscounts.Add(newDiscount);
            await _context.DiscountPropertiesModels.AddAsync(newDiscount);
        }
        await _context.SaveChangesAsync();
        return newDiscounts;
    }

    public async Task<DiscountPropertiesModel> CreateDiscountByIdAsync(Guid discountId)
    {
        DiscountPropertiesModel newDiscount = new()
        {
            Id = discountId,
            IsDiscount = true,
            ValueOfDiscount = 0.8M,
        };
        await _context.DiscountPropertiesModels.AddAsync(newDiscount);
        await _context.SaveChangesAsync();
        return newDiscount;
    }
}

