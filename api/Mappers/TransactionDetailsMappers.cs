using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TransactionDetails;
using api.Models;

namespace api.Mappers
{
    public static class TransactionDetailsMappers
    {
        public static TransDto GetTransDto(this TransactionDetails transModel)
        {
            return new TransDto
            {
                transID = transModel.transID,
                transType = transModel.transType,
                transDesc = transModel.transDesc,
                transCategory = transModel.transCategory,
                transDate = transModel.transDate,
                transAmt = transModel.transAmt,
                transUserID = transModel.transUserID
            };
        }

        public static TransactionDetails CreateTransDto(this CreateTransDto transModel)
        {
            return new TransactionDetails
            {
                transType = transModel.transType,
                transDesc = transModel.transDesc,
                transCategory = transModel.transCategory,
                transDate = transModel.transDate,
                transAmt = transModel.transAmt,
                transUserID = transModel.transUserID
            };
        }
    }
}