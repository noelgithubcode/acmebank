using System.ComponentModel.DataAnnotations;

namespace NoelBankAppPRJ.Mocks
{
    public class MockUserAccount
    {
        [Key]
        public int UserAccountPK { get; set; }
        public int UserFK { get; set; }
        public decimal UserBalance { get; set; }
        public BankAccountTypeEnum BankAccountType { get; set; }
    }
}
