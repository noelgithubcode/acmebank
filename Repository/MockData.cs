using System;
using System.Collections.Generic;
using System.Linq;
using NoelBankAppPRJ.Mocks;

namespace NoelBankAppPRJ.Repository
{
    public static class MockData
    {
        #region Bank
        public static MockBank GetMockBank(int bankID)
        {
            MockBank bank = new MockBank()
            {
                BankAccountList = GetMockBankAccountList(bankID)
            };
            return bank;
        }
        #endregion

        #region BankUsers
        public static MockUser GetMockUser(int bankID, int userID)
        {
            int accountPK = 0;
            List<MockUser> users = new List<MockUser>();
            for (int i = 0; i < 20; i++)
            {
                var user = new MockUser()
                {
                    UserPK = i,
                    UserName = $"user{i}",
                    Password = $"user{i}",
                    BankFK = bankID
                };
                IEnumerable<MockTransaction> mockTransactions = GetMockTransactions(userID);
                user.UserAccounts = new List<MockUserAccount>()
                {
                    new MockUserAccount
                    {
                        BankAccountType = BankAccountTypeEnum.Investment,
                        UserAccountPK = ++accountPK,
                        UserBalance = 10000  - mockTransactions
                                      .Where(x => x.TransactionType == TransactionTypeEnum.Withdraw)
                                      .Sum(x => x.TransactionAmount),
                        UserFK = i
                    },
                    new MockUserAccount
                    {
                        BankAccountType = BankAccountTypeEnum.Checking,
                        UserAccountPK = ++accountPK,
                        UserBalance = 10000 + mockTransactions
                                      .Where(x => x.TransactionType == TransactionTypeEnum.Deposit)
                                      .Sum(x => x.TransactionAmount),
                        UserFK = i
                    }
                };
                users.Add(user);
            }

            return users.Single(x => x.UserPK == userID);

        }
        #endregion

        #region Utility

        public static IEnumerable<MockTransaction> GetMockTransactions(int userPK)
        {
            int numberMock = 1;
            List<MockTransaction> transactions = new List<MockTransaction>();
            for (int i = 0; i < 20; i++)
            {

                transactions.Add(
                    new MockTransaction
                    {
                        UserPK = userPK,
                        TransactionType = TransactionTypeEnum.Deposit,
                        BankAccountType = BankAccountTypeEnum.Checking,
                        TransactionAmount = numberMock * 100,
                        TransactionDate = DateTime.Now.AddDays(-i).AddHours(i + 1),
                        TransactionPK = numberMock * i
                    }
               );
                transactions.Add(
                   new MockTransaction
                   {
                       UserPK = numberMock,
                       TransactionType = TransactionTypeEnum.Withdraw,
                       BankAccountType = BankAccountTypeEnum.Investment,
                       InvestmentType = InvestmentTypeEnum.Individual,
                       TransactionAmount = ((numberMock + 1) * 100) < 501 ? ((numberMock + 1) * 100) : 0,
                       TransactionDate = DateTime.Now.AddDays(i).AddHours(i + 1),
                       TransactionPK = numberMock * 100
                   }
              );
            }
            return transactions.OrderByDescending(x => x.TransactionDate);
        }

        private static List<MockBankAccount> GetMockBankAccountList(int bankPK)
        {
            return new List<MockBankAccount>
            {
                new MockBankAccount{
                    BankAccountName = BankAccountTypeEnum.Checking.ToString(),
                    BankAccountPK = 1,
                    BankFK = bankPK
                },
                 new MockBankAccount{
                    BankAccountName = BankAccountTypeEnum.Investment.ToString(),
                    BankAccountPK = 2,
                    BankFK = bankPK
                }
            };
        }
        #endregion

    }
}
