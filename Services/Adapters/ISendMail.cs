namespace CapsulaDoTempo.Services.Adapters;

public interface ISendMail<T>
{
  Task<T> SendEmail(string from, string to, string subject, string body);
}