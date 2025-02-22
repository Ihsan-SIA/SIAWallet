namespace BankApp;

public partial class Menu
{
    private readonly IAllMenu _allMenu;

    public Menu()
    {
        _allMenu = new AppFunctionality();
    }


    public void MainMenu()
    {
        bool endApp = false;
        string accountNo;
        string accountPassword = default!;


        while (!endApp)
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO SIAWALLET! Type exit to exit app or any other button to continue.");
            string enter = Console.ReadLine()!;
            if (enter.ToLower() == "exit")
                return;
            Console.WriteLine("WELCOME TO SIAWALLET! Create your account below.");
            var customerDetails = CustomerInfo.CollectDetailsNew();
            _allMenu.CreateAccount(customerDetails);
            bool frontPage = true;
            while (frontPage)
            {
                Console.Clear();
                Console.WriteLine("Thank you for choosing SIAWALLET. Login to continue! Type exit to exit app.");

                Console.Write("Enter your account number: ");
                accountNo = Console.ReadLine()!;
                if (accountNo.ToLower() == "exit")
                {
                    return;
                }
                Console.Write("Enter your password: ");
                accountPassword = Console.ReadLine()!;
                bool login = _allMenu.Login(accountNo, accountPassword);
                int option = 0;
                while (login)
                {
                    Console.Clear();
                    DisplayOptions();
                    int.TryParse(Console.ReadLine()!, out option);
                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter your account number: ");
                            accountNo = Console.ReadLine()!;
                            Console.Write("Enter your account password: ");
                            accountPassword = Console.ReadLine()!;
                            Console.Write("Enter your transaction PIN: ");
                            string accountPin;
                            accountPin = Console.ReadLine()!;
                            _allMenu.DeleteAccount(accountNo, accountPin, accountPassword);
                            break;
                        case 2:
                            Console.Write("Enter your password: ");
                            accountPassword = Console.ReadLine()!;
                            Console.Write("Enter your transaction PIN: ");
                            accountPin = Console.ReadLine()!;
                            decimal amount;
                            Console.Write("Enter amount: ");

                            while (!(decimal.TryParse(Console.ReadLine()!, out amount)))
                            {
                                Console.WriteLine("Invalid Amount! Check the numbers you input again.");
                                decimal.TryParse(Console.ReadLine()!, out amount);
                            }
                            _allMenu.SendMoney(amount, accountPin, accountPassword);
                            break;
                        case 3:
                            Console.Write("Enter your account number: ");
                            accountNo = Console.ReadLine()!;
                            Console.Write("Enter the amount you want to add: ");
                            decimal.TryParse(Console.ReadLine()!, out amount);
                            Console.Write("Enter your transaction PIN: ");
                            accountPin = Console.ReadLine()!;
                            _allMenu.AddMoney(amount, accountPin, accountNo);
                            break;
                        case 4:
                            Console.Write("Enter your password: ");
                            string password = Console.ReadLine()!;
                            Console.Write("Enter your transaction PIN: ");
                            accountPin = Console.ReadLine()!;
                            _allMenu.DisplayCustomerInfo(password, accountPin); break;

                        case 5:
                            var testDetails = CustomerInfo.UpdateDetails();
                            _allMenu.UpdateAccountDetails(testDetails);
                            break;
                        case 6:
                            login = false; frontPage = false; break;
                        default: return;
                    }
                }

            }


        }
    }
    private void DisplayOptions()
    {
        Console.WriteLine("Click 1 to Delete an existing account");
        Console.WriteLine("Click 2 to Send Money");
        Console.WriteLine("Click 3 to Add Money to your wallet");
        Console.WriteLine("Click 4 to Display your account details");
        Console.WriteLine("Click 5 to Update Account Details");
        Console.WriteLine("Click 6 to Log out of app");
        Console.WriteLine("Click any other button to exit app completely");

    }
}