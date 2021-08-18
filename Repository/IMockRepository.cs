using NoelBankAppPRJ.Mocks;

namespace NoelBankAppPRJ.Repository
{
    public interface IMockRepository
    {
        MockBankUser GetMockBankandUser(int bankID, int userID);
    }
}