using System;
using System.ComponentModel.DataAnnotations;

namespace NoelBankAppPRJ.Mocks
{
    public class MockTransaction
    {
        [Key]
        public int TransactionPK { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionAmount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public BankAccountTypeEnum BankAccountType { get; set; }
        public InvestmentTypeEnum InvestmentType { get; set; }
        public int UserPK { get; set; }
    }
}
