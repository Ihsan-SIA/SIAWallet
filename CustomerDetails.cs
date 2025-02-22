namespace BankApp;

public class CustomerDetails
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string StateOfOrigin { get; set; } = default!;
    public string Phone1 { get; set; } = default!;
    public string? Phone2 { get; set; }
    public string? Religion { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public string? MaritalStatus { get; set; } = default!;
    public string? Email { get; set; }
    public string CustomerAccountNumber { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? Nationality { get; set; } = default!;
    public string NIN { get; set; } = default!;
    public string? BVN { get; set; } = default!;
    public string? NextOfKinName { get; set; } = default!;
    public string? NextOfKinPhone { get; set; } = default!;
    public string? NextOfKinEmail { get; set; }
    public decimal AccountBalance { get; set; } = default!;
    public string TransactionPin { get; set; } = default!;
    public string AccountPassword { get; set; } = default!;
    public AccountType AccountType { get; set; } =default!;
    public int AccountLimit {get; set;}
    public List<string> TransactionHistory {get; set;} = [];
    public CustomerDetails()
    {

    }
    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}\n" +
               $"Address: {Address}\n" +
               $"State of Origin: {StateOfOrigin}\n" +
               $"Phone 1: {Phone1}\n" +
               $"Phone 2: {Phone2}\n" +
               $"Religion: {Religion}\n" +
               $"Gender: {Gender}\n" +
               $"Marital Status: {MaritalStatus}\n" +
               $"Email: {Email}\n" +
               $"Account Number: {CustomerAccountNumber}\n" +
               $"Date of Birth: {DateOfBirth.ToShortDateString()}\n" +
               $"Nationality: {Nationality}\n" +
               $"NIN: {NIN}\n" +
               $"BVN: {BVN}\n" +
               $"Next of Kin==> (Name: {NextOfKinName} Phone no: {NextOfKinPhone}, Email: {NextOfKinEmail})\n" +
               $"Account Balance: {AccountBalance:N2}\n" +
               $"Transaction PIN: {TransactionPin}\n" +
               $"Password: {AccountPassword}\n" +
               $"Account limit: {(int)AccountLimit:N2}"
               ;
    }
}
