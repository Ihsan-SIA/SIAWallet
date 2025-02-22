using BankApp;
using System.Text.Json;

public class CustomerDatabase
{
    //static void SaveToJson(string path, List<CustomerDetails> customerDetails)
    //{
    //    string jsonString = JsonSerializer.Serialize(customerDetails, new JsonSerializerOptions { WriteIndented = true });
    //    File.WriteAllText(path, jsonString);
    //    Console.WriteLine("Customer details saved successfully!");
    //}
    //static List<CustomerDetails> LoadFromJson(string path)
    //{
    //    if (!File.Exists(path))
    //    {
    //        Console.WriteLine("Customer not found!");
    //        return new List<CustomerDetails>();
    //    }

    //    string jsonString = File.ReadAllText(path);
    //    return JsonSerializer.Deserialize<List<CustomerDetails>>(jsonString) ?? new List<CustomerDetails>();

    //}
}