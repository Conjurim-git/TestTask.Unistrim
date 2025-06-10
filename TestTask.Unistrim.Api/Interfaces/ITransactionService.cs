using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces;

public interface ITransactionService
{
    Task<Transaction> CreateTransaction(Transaction transaction);

    Task<Transaction> GetTransactionById(Guid id);

    Task<IReadOnlyCollection<Transaction>> GetTransaction();
}