using System.Text;

namespace BankApp
{
    public interface IAllMenu
    {
        void CreateAccount(CustomerDetails details);
        void DeleteAccount(string accountNo, string accountPin, string password);
        void UpdateAccountDetails(CustomerDetails details);
        void SendMoney(decimal amount, string transactionPin, string accountPassword);
        void DisplayCustomerInfo(string customerPassword, string transactionPin);
        void AddMoney(decimal amount, string transactionPin, string accountNumber);
        bool Login(string accountNumber, string password);
    }
}
