using BankApp;

public class CustomerInfo
{
    public static CustomerDetails CollectDetailsNew()
    {
        CustomerDetails details = new CustomerDetails();
        Console.Write("First name: ");
        details.FirstName = Console.ReadLine()!;
        Console.Write("Last name: ");
        details.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        details.Email = Console.ReadLine()!;
        Console.Write("Address: ");
        details.Address = Console.ReadLine()!;
        Console.Write("State of Origin: ");
        details.StateOfOrigin = Console.ReadLine()!;
        Console.Write("Phone number 1: ");
        details.Phone1 = Console.ReadLine()!;
        Console.Write("Gender: ");
        details.Gender = Console.ReadLine()!;
        details.CustomerAccountNumber = GetYourAza();

        Console.WriteLine("Enter date of birth details");
        Console.Write("Month: "); int.TryParse(Console.ReadLine()!, out int month);
        Console.Write("Day: "); int.TryParse(Console.ReadLine()!, out int day);
        Console.Write("Year: "); int.TryParse(Console.ReadLine()!, out int year);
        while (month > 12 || month < 0 || day > 31 || day < 0 || year < 1800 || year > DateTime.Now.Year)
        {
            Console.WriteLine("Invalid date, please enter date of birth again!");
            Console.Write("Month: "); int.TryParse(Console.ReadLine()!, out month);
            Console.Write("Day: "); int.TryParse(Console.ReadLine()!, out day);
            Console.Write("Year: "); int.TryParse(Console.ReadLine()!, out year); ;
        }
        details.DateOfBirth = new DateTime(year, month, day);
        
        Console.Write("NIN: ");
        details.NIN = Console.ReadLine()!;
        Console.Write("Create transaction PIN: ");
        details.TransactionPin = Console.ReadLine()!;
        Console.Write("Create Password for app: ");
        details.AccountPassword = Console.ReadLine()!;
        details.AccountBalance = 0;

        Console.Write("Choose your account type below:\n1 for Sapa\n2 for On God\n3 for Manage Manage\n4 for Rich Kid\n5 for Odogwu stepper\n");
        int accountLimit = 0;

        while (!int.TryParse(Console.ReadLine()!, out accountLimit))
        {
            Console.WriteLine("Invalid option, please try again");
        }

        details.AccountType = (AccountType)accountLimit;

        switch (details.AccountType)
        {
            case AccountType.Sapa: 
                details.AccountLimit = 100_000; 
            break;
            case AccountType.OnGod: 
                details.AccountLimit = 500_000; 
            break;
            case AccountType.ManageManage: 
                details.AccountLimit = 1_000_000; 
            break;
            case AccountType.RichKid: 
                details.AccountLimit = 10_000_000; 
            break;
            case AccountType.Odogwu: 
                details.AccountLimit = 100_000_000; 
            break;
            default:
                throw new ArgumentException("Unknown account type");
        }

        return details;
    }

    private static string GetYourAza()
    {
        Random random = new Random();
        char[] azaChars = new char[10];
        for (int i = 0; i < 10; i++)
        {
            char figure = (char)('0' + (random.Next(0, 10)));
            azaChars[i] = figure;
        }
        string accountNumber = new string(azaChars);
        return accountNumber;
    }

    
    public static CustomerDetails UpdateDetails()
    {
        CustomerDetails details = new CustomerDetails();
        Console.Write("Enter Email to update or any other button to skip: ");
        details.Email = Console.ReadLine()!;
        Console.Write("Enter Phone number 1 to update or any other button to skip: : ");
        details.Phone1 = Console.ReadLine()!;
        Console.Write("Enter Phone number 2 to update or any other button to skip: ");
        details.Phone2 = Console.ReadLine()!;
        Console.Write("Enter Religion to update or any other button to skip: : ");
        details.Religion = Console.ReadLine()!;
        Console.Write("Enter Marital status to update or any other button to skip: ");
        details.MaritalStatus = Console.ReadLine()!;
        Console.Write("Enter Nationality to update or any other button to skip: ");
        details.Nationality = Console.ReadLine()!;
        Console.Write("Enter Next of kin full name to update or any other button to skip: ");
        details.NextOfKinName = Console.ReadLine()!;
        Console.Write("Enter Next of kin email to update or any other button to skip: ");
        details.NextOfKinEmail = Console.ReadLine()!;
        Console.Write("Next of kin phone to update or any other button to skip: ");
        details.NextOfKinPhone = Console.ReadLine()!;
        Console.WriteLine("Press y to update transaction pin, press any other key to skip");
        if (Console.ReadLine()!.ToLower() == "y")
        {
            Console.Write("Update transaction PIN: ");
            details.TransactionPin = Console.ReadLine()!;
        }

        Console.WriteLine("Press y to update login password, press any other key to skip");
        if (Console.ReadLine()!.ToLower() == "y")
        {
            Console.Write("Update login password: ");
            details.AccountPassword = Console.ReadLine()!;
        }

        Console.Write("Choose to upgrade your account type below:\n1 for Sapa\n2 for On God\n3 for Manage Manage\n4 for Rich Kid\n5 for Odogwu stepper\nClick any other number to skip\n");
        int accountType = 0;
        while (!int.TryParse(Console.ReadLine()!, out accountType))
        {
            Console.WriteLine("Invalid option, only numbers are valid options for this");
        }

        details.AccountType = (AccountType)accountType;

        switch (details.AccountType)
        {
            case AccountType.Sapa:
                details.AccountLimit = 100_000;
                break;
            case AccountType.OnGod:
                details.AccountLimit = 500_000;
                break;
            case AccountType.ManageManage:
                details.AccountLimit = 1_000_000;
                break;
            case AccountType.RichKid:
                details.AccountLimit = 10_000_000;
                break;
            case AccountType.Odogwu:
                details.AccountLimit = 100_000_000;
                break;
            default:
                throw new ArgumentException("Unknown account type");
        }

        return details;
    }
}