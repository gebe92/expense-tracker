using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface ITransactionDetailsRepository
    {
        Task<List<TransactionDetails>> GetAllAsync();
        Task<TransactionDetails?> GetByIdAsync(int id);
        Task<TransactionDetails> CreateAsync(TransactionDetails transModel);
    }
}