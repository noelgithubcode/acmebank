using System.Collections.Generic;

namespace NoelBankAppPRJ.Mocks
{
    public class MockBankUser
    {
        public MockBank Bank { get; set; }
        public MockUser User { get; set; }
        public IEnumerable<MockTransaction> Transactions { get; set; }
    }
}
