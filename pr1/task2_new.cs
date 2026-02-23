public interface IClientRepository
{
    void Add(Client client);
}

public interface IEmailService
{
    void Send(string to, string subject, string body);
}

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }

    public bool IsValid()
    {
        if (string.IsNullOrEmpty(this.Name)) return false;
        if (!EmailHelper.IsValid(this.Email)) return false;
        if (DateOfBirth > DateTime.Now) return false;
        return true;
    }
}

public class ClientService
{
    private readonly IClientRepository _repository;
    private readonly IEmailService _emailService;

    public ClientService(IClientRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public (bool, string) AddClient(Client client)
    {
        if (!client.IsValid()) return (false, "Client data is not valid");

        _repository.Add(client);
        _emailService.Send(client.Email, "Welcome", "Congrats!");
        return (true, string.Empty);
    }
}

public class ClientRepository : IClientRepository
{
    private readonly string _connectionString = "cnString";

    public void Add(Client client)
    {
        //logic
    }
}

public class EmailService : IEmailService
{
    public void Send(string to, string subject, string body)
    {
        //logic

    }
}

class Program
{
    static void Main()
    {
        IClientRepository repository = new ClientRepository();
        IEmailService emailService = new EmailService();

        var clientService = new ClientService(repository, emailService);

        var client = new Client
        {
            Name = "Maksym",
            Email = "maksym@gmail.com",
            DateOfBirth = new DateTime(2005, 5, 12)
        };

        var (success, error) = clientService.AddClient(client);

        if (success)
        {
            // success
        }
        else
        {
            // error
        }
    }
}