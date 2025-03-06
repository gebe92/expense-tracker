using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TransactionDetails;
using api.Models;

namespace api.Interface
{
    public interface ITransactionDetailsRepository
    {
        Task<List<TransactionDetails>> GetAllAsync();
        Task<TransactionDetails?> GetByIdAsync(int id);
        Task<TransactionDetails> CreateAsync(TransactionDetails transModel);
        Task<TransactionDetails?> UpdateAsync(int id, UpdateTransDto transDto);
        Task<TransactionDetails?> DeleteAsync(int id);
    }
}