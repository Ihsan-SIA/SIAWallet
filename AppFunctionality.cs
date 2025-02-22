using BankApp;
using System.Text;

public class AppFunctionality : IAllMenu
{
    private List<CustomerDetails> _customerDetails;
    public AppFunctionality()
    {
        _customerDetails = [];
    }
    public void CreateAccount(CustomerDetails customer)
    {
        var checkCustomer = _customerDetails.FirstOrDefault(x => x.CustomerAccountNumber == customer.CustomerAccountNumber)!;
        if (checkCustomer != null)
        {
            Console.WriteLine("An error occured! It's not your fault and it won't repeat itself. Please try again.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }
        
        _customerDetails.Add(customer!);
        Console.WriteLine($"Account created successfully! Your account number is {customer!.CustomerAccountNumber}");
        Console.Write("Enter your account number to copy it: ");
        string copyAccount = Console.ReadLine()!;
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

    }
    public void DeleteAccount(string accountNo, string transactionPin, string password)
    {
        var customer = _customerDetails.Find(x => x.CustomerAccountNumber == accountNo);

        if (customer is null || customer.TransactionPin != transactionPin)
        {
            Console.WriteLine($"Incorrect Account number, Password or transaction PIN");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Customer with Account Number {customer.CustomerAccountNumber} deleted successfully!");
        _customerDetails.Remove(customer);
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    public void SendMoney(decimal amount, string transactionPin, string accountPassword)
    {

        var customer = _customerDetails.Find(x => x.TransactionPin == transactionPin);
        if (customer is null || customer.AccountPassword != accountPassword)
        {
            Console.WriteLine("Incorrect PIN, password or account number");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }

        if (customer.AccountBalance < amount)
        {
            Console.WriteLine("Ah ah no be gadus be dis wey want withdraw so??? Insufficient funds joor!");
            Console.WriteLine("Press any key to continue, no waste my time abeg");
            Console.ReadKey();
            return;
        }

        customer.AccountBalance -= amount;
        Console.WriteLine($"{amount:N2} sent to destination account");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    public void AddMoney(decimal amount, string transactionPin, string accountNumber)
    {

        var customer = _customerDetails.Find(x => x.TransactionPin == transactionPin);
        if (customer is null || customer.CustomerAccountNumber != accountNumber)
        {
            Console.WriteLine("Incorrect transaction PIN or account number");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }
        if (customer.AccountBalance + amount > (int)customer.AccountLimit)
        {
            Console.WriteLine("Sorry you can't make this transaction because you will exceed your account limit");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }

        customer.AccountBalance += amount;
        Console.WriteLine($"{amount:N2} added successfully to user {customer.CustomerAccountNumber}!");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
    public void DisplayCustomerInfo(string accountPassword, string transactionPin)
    {
        var customer = _customerDetails.Find(x => x.AccountPassword == accountPassword);
        if (customer is null || customer.TransactionPin != transactionPin)
        {
            Console.WriteLine("Incorrect PIN or password!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }

        Console.WriteLine(customer);
        Console.Write("Press any key to continue: ");
        Console.ReadKey();

    }

    public static string ValidateUpdated(string userInput, string detailsInput)
    {
        return string.IsNullOrWhiteSpace(detailsInput) ? userInput : detailsInput; 
    }

    public static T UpValidate<T>(T userInput, T detailsInput)
    {
        if (detailsInput is null || userInput is string str && string.IsNullOrWhiteSpace(str))
        {
            return userInput;
        }

        return detailsInput;
    }


    public void UpdateAccountDetails(CustomerDetails details)
    {
        var customer = _customerDetails.Find(x => x.CustomerAccountNumber != null);
        if (customer is null)
        {
            Console.WriteLine("Invalid transaction PIN");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
        }

        customer.Email = ValidateUpdated(customer.Email!, details.Email!);
        customer.StateOfOrigin = ValidateUpdated(customer.StateOfOrigin, details.StateOfOrigin);
        customer.Phone1 = ValidateUpdated(customer.Phone1, details.Phone1);
        customer.Phone2 = ValidateUpdated(customer.Phone2!, details.Phone2!);
        customer.Religion = ValidateUpdated(customer.Religion!, details.Religion!);
        customer.MaritalStatus = ValidateUpdated(customer.MaritalStatus!, details.MaritalStatus!);
        customer.Nationality = ValidateUpdated(customer.Nationality!, details.Nationality!);
        customer.NextOfKinName = ValidateUpdated(customer.NextOfKinName!, details.NextOfKinName!);
        customer.NextOfKinPhone = ValidateUpdated(customer.NextOfKinPhone!, details.NextOfKinPhone!);
        customer.NextOfKinEmail = ValidateUpdated(customer.Phone2, details.NextOfKinEmail!);
        customer.AccountLimit = UpValidate(customer.AccountLimit, details.AccountLimit);
        Console.WriteLine("Account updated successfully!");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();

    }
    public bool Login(string accountNumber, string accountPassword)
    {
        var customer = _customerDetails.Find(x => x.AccountPassword == accountPassword);

        if (customer is null || customer.CustomerAccountNumber != accountNumber)
        {
            Console.WriteLine("Incorrect account number or password");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return false!;
        }
        else
            return true;
    }
}