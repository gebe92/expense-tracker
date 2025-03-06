using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TransactionDetails;
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

        public async Task<TransactionDetails?> DeleteAsync(int id)
        {
            var findTrans = await _context.TransactionDetails.FirstOrDefaultAsync(x => x.transID == id);

            if (findTrans == null)
            {
                return null;
            }

            _context.TransactionDetails.Remove(findTrans);
            await _context.SaveChangesAsync();

            return findTrans;
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

        public async Task<TransactionDetails?> UpdateAsync(int id, UpdateTransDto transDto)
        {
            var findTrans = await _context.TransactionDetails.FirstOrDefaultAsync(x => x.transID == id);

            if (findTrans == null)
            {
                return null;
            }

            findTrans.transType = transDto.transType;
            findTrans.transDesc = transDto.transDesc;
            findTrans.transCategory = transDto.transCategory;
            findTrans.transDate = transDto.transDate;
            findTrans.transAmt = transDto.transAmt;

            await _context.SaveChangesAsync();

            return findTrans;
        }
    }
}