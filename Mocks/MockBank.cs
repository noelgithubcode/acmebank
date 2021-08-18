using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoelBankAppPRJ.Mocks
{
    public class MockBank
    {
        [Key]
        public int BankID { get; set; } = 1;
        public string BankName { get; set; } = "Acme Bank";

        public IEnumerable<MockBankAccount> BankAccountList;
    }
}
