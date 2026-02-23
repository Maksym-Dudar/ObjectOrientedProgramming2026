public interface IEnroll
{
    void Validate();
    void Persist();
}

public interface IMailNotifier
{
    void SendEmail();
}

public interface ISmsNotifier
{
    void SendSMS();
}

class ProductEnroll : IEnroll
{
    public void Validate() { /* Check data */ }
    public void Persist() { /* Persist to DB */ }
}

class ContactEnroll : IEnroll, IMailNotifier, ISmsNotifier
{
    public void Validate() { /* Check data */ }
    public void Persist() { /* Persist to DB */ }
    public void SendEmail() { /* Send Email */ }
    public void SendSMS() { /* Send SMS */ }
}