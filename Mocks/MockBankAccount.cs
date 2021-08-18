using System.ComponentModel.DataAnnotations;

namespace NoelBankAppPRJ.Mocks
{
    public class MockBankAccount
    {
        [Key]
        public int BankAccountPK { get; set; }
        public int BankFK { get; set; }
        public string BankAccountName { get; set; }
    }
}
