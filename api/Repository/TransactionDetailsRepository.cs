using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TransactionDetailsRepository : ITransactionDetailsRepository
    {
        private readonly AppDbContext _context;

        public TransactionDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionDetails> CreateAsync(TransactionDetails transModel)
        {
            await _context.TransactionDetails.AddAsync(transModel);
            await _context.SaveChangesAsync();
            return transModel;
        }

        public Task<List<TransactionDetails>> GetAllAsync()
        {
            var trans = _context.TransactionDetails.ToListAsync();

            return trans;
        }

        public async Task<TransactionDetails?> GetByIdAsync(int id)
        {
            return await _context.TransactionDetails.FirstOrDefaultAsync(i => i.transID == id);
        }
    }
}