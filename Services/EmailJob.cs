using CapsulaDoTempo.Services.Adapters;
using Hangfire;

namespace CapsulaDoTempo.Services;

public class EmailJob
{
  private readonly ISendMail _mailJet;

  public EmailJob(ISendMail mailJet)
  {
    _mailJet = mailJet;
  }

  [JobDisplayName("Enviar e-mail da cápsula do tempo")]
  public async Task Send(string from, string to, string subject, string body)
  {
    await _mailJet.SendEmail(from, subject, to, body);
  }
}
