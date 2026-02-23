public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class ClientValidator
{
    public (bool isValid, string errorMessage) Validate(Client client)
    {
        if (string.IsNullOrEmpty(client.Name)) return (false, "Name is invalid");
        if (!client.Email.Contains("@")) return (false, "Email is invalid");
        if (client.DateOfBirth > DateTime.Now) return (false, "Date of Birth is invalid");
        return (true, string.Empty);
    }
}

public class ClientRepository
{
    private readonly string _connectionString = "cnString";
    public void Add(Client client)
    {
        // logic
    }
}

public class EmailService
{
    public void SendWelcomeEmail(string email)
    {
        // logic

    }
}


class Program
{
    static void Main()
    {
        var client = new Client
        {
            Name = "Maksym",
            Email = "maksym@gmail.com",
            DateOfBirth = new DateTime(2006, 11, 11)
        };

        var validator = new ClientValidator();
        var (isValid, error) = validator.Validate(client);

        if (!isValid)
        {
            //error
            return;
        }

        try
        {
            var repository = new ClientRepository();
            repository.Add(client);

            var emailService = new EmailService();
            emailService.SendWelcomeEmail(client.Email);
        }
        catch (Exception ex)
        {
            //error
        }
    }
}