using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NoelBankAppPRJ.Mocks;


namespace NoelBankAppPRJ.Repository
{
    public class MockRepository : IMockRepository
    {
        private readonly ILogger<MockRepository> _logger;

        public MockRepository(ILogger<MockRepository> logger)
        {
            _logger = logger;
        }

        public MockBankUser GetMockBankandUser(int bankID, int userID)
        {
            return new MockBankUser
            {
                Bank = GetMockBank(bankID),
                User = GetMockUser(bankID, userID),
                Transactions = GetMockTransactions(userID)
            };
        }

        #region Utility methods
        private MockBank GetMockBank(int bankID)
        {
            try
            {
                return MockData.GetMockBank(bankID);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, "GetMockBank");
            }
            return null;
        }

        private MockUser GetMockUser(int bankID, int userID)
        {
            try
            {
                return MockData.GetMockUser(bankID, userID);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, "GetMockUser");
            }
            return null;
        }

        private IEnumerable<MockTransaction> GetMockTransactions(int userPK)
        {
            try
            {
                return MockData.GetMockTransactions(userPK);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, "GetMockTransactions");
            }
            return null;
        }
        #endregion
    }
}
