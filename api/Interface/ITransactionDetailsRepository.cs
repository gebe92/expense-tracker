using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TransactionDetails;
using api.Helpers;
using api.Models;

namespace api.Interface
{
    public interface ITransactionDetailsRepository
    {
        Task<List<TransactionDetails>> GetAllAsync(TransQueryObject queryObject);
        Task<TransactionDetails?> GetByIdAsync(int id);
        Task<TransactionDetails> CreateAsync(TransactionDetails transModel);
        Task<TransactionDetails?> UpdateAsync(int id, UpdateTransDto transDto);
        Task<TransactionDetails?> DeleteAsync(int id);
        Task<List<TransactionDetails>> GetByUserIdAsync(int userId, TransQueryObject queryObject);
    }
}