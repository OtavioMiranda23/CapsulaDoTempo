namespace CapsulaDoTempo.Services.Adapters;

public interface ISendMail
{
  Task SendEmail(string from, string to, string subject, string body);
}