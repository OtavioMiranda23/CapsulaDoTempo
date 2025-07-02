using CapsulaDoTempo.Entities;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Mailjet.Client.TransactionalEmails.Response;
using Microsoft.Extensions.Options;

namespace CapsulaDoTempo.Services.Adapters;

public class MailJetAdapter : ISendMail
{
  private MailjetClient Client;
  public MailJetAdapter(MailJetSettings settings)
  {
    Client = new MailjetClient(settings.ApiKey, settings.SecretKey);
  }

  public Task SendEmail(string from, string subject, string to, string body)
  {
    var toContact = new SendContact(to);
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
    var res =  Client.SendTransactionalEmailAsync(email);
    return res;
  }  
  // public Task SendAsyncWithAttachment(string from, string subject, string to, string body, string imagePath)
  // {
  //   var toContact = new SendContact(to);
  //   //TODO: Implementar attachment
  //   // var attachment = new Attachment(filename, string contentType, string base64Content);
  //   MailjetRequest request = new MailjetRequest
  //   {
  //     Resource = Send.Resource
  //   };
  //   var email = new TransactionalEmailBuilder()
  //     .WithFrom(new SendContact(from))
  //     .WithSubject(subject)
  //     .WithHtmlPart(body)
  //     .WithTo(toContact)
  //     .Build();
  //   var res = Client.SendTransactionalEmailAsync(email);
  //   return res;
  // }
}