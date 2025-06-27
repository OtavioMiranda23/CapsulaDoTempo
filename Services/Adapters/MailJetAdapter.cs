using CapsulaDoTempo.Entities;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Options;

namespace CapsulaDoTempo.Services.Adapters;

public class MailJetAdapter : ISendMail
{
  private MailjetClient Client;
  public MailJetAdapter(IOptions<MailJetSettings> settings)
  {
    Client = new MailjetClient(settings.Value.ApiKey, settings.Value.SecretKey);
  }

  public Task SendAsync(string from, string subject, string to, string body, string? imagePath)
  {
    var toContact = new SendContact(to);
    //TODO: Implementar attachment
    // var attachment = new Attachment(filename, string contentType, string base64Content);
    MailjetRequest request = new MailjetRequest
    {
      Resource = Send.Resource
    };
    var email = new TransactionalEmailBuilder()
      .WithFrom(new SendContact(from))
      .WithSubject(subject)
      .WithHtmlPart(body)
      .WithTo(toContact)
      .Build();
    return Client.SendTransactionalEmailAsync(email);
  }
}