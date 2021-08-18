using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoelBankAppPRJ.Mocks
{
    public class MockUser
    {
        [Key]
        public int UserPK { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int BankFK { get; set; }
        public IEnumerable<MockUserAccount> UserAccounts { get; set; }
    }
}
