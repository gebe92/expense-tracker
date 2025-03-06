using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TransactionDetails;
using api.Helpers;
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

        public async Task<List<TransactionDetails>> GetAllAsync(TransQueryObject query)
        {
            var trans = _context.TransactionDetails.AsQueryable();
            trans = Filter(trans, query);

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await trans.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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

        public async Task<List<TransactionDetails>> GetByUserIdAsync(int userId, TransQueryObject query)
        {
            var trans = _context.TransactionDetails.Where(i => i.transUserID == userId);
            trans = Filter(trans, query);

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await trans.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        private IQueryable<TransactionDetails> Filter(IQueryable<TransactionDetails> trans, TransQueryObject query)
        {
            if (query != null && HasFilterValues(query))
            {
                if (!string.IsNullOrWhiteSpace(query.transType))
                {
                    trans = trans.Where(t => t.transType.Equals(query.transType));
                }

                if (!string.IsNullOrWhiteSpace(query.transCategory))
                {
                    trans = trans.Where(t => t.transCategory.Equals(query.transCategory));
                }

                if (query.transDate != null)
                {
                    trans = trans.Where(t => t.transDate.Date.Equals(query.transDate.Value.Date));
                }

                if (query.transMonth != null && query.transYear != null)
                {
                    trans = trans.Where(t => t.transDate.Month.Equals(query.transMonth) && t.transDate.Year.Equals(query.transYear));
                }
                else if (query.transMonth == null && query.transYear != null)
                {
                    trans = trans.Where(t => t.transDate.Year.Equals(query.transYear));
                }

                if (!string.IsNullOrWhiteSpace(query.SortBy))
                {
                    switch (query.SortBy)
                    {
                        case "transType":
                            trans = query.IsDecsending ? trans.OrderByDescending(t => t.transType) : trans.OrderBy(t => t.transType);
                            break;
                        case "transDesc":
                            trans = query.IsDecsending ? trans.OrderByDescending(t => t.transDesc) : trans.OrderBy(t => t.transDesc);
                            break;
                        case "transCategory":
                            trans = query.IsDecsending ? trans.OrderByDescending(t => t.transCategory) : trans.OrderBy(t => t.transCategory);
                            break;
                        case "transDate":
                            trans = query.IsDecsending ? trans.OrderByDescending(t => t.transDate) : trans.OrderBy(t => t.transDate);
                            break;
                        case "transAmt":
                            trans = query.IsDecsending ? trans.OrderByDescending(t => t.transAmt) : trans.OrderBy(t => t.transAmt);
                            break;
                    }
                }
            }

            return trans;
        }

        private bool HasFilterValues(TransQueryObject query)
        {
            return !string.IsNullOrWhiteSpace(query.transType) ||
                !string.IsNullOrWhiteSpace(query.transCategory) ||
                query.transDate != null ||
                query.transMonth != null ||
                query.transYear != null ||
                !string.IsNullOrWhiteSpace(query.SortBy);
        }
    }
}