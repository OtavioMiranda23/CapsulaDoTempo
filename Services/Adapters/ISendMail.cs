namespace CapsulaDoTempo.Services.Adapters;

public interface ISendMail
{
  Task SendAsync(string from, string to, string subject, string body, string? imagePath);
}