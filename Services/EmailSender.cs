using CapsulaDoTempo.Entities;
using CapsulaDoTempo.Services.Adapters;
using Mailjet.Client.TransactionalEmails;
using Mailjet.Client.TransactionalEmails.Response;
using Microsoft.Extensions.Options;

namespace CapsulaDoTempo.Services;

public class EmailSender
{
  private MailJetSettings _settings;
  public EmailSender(IOptions<MailJetSettings> options)
  {
    _settings = options.Value;
  }
  public async Task<TransactionalEmailResponse> SendCapsulaEmail(CapsulaModel capsula, string from)
  {
    var mailJet = new MailJetAdapter(_settings);
    var subject = "Sua Cápsula do Tempo está aberta ";
    var templateRaw = "<p style=\"margin: 0 0 16px 0;\">Olá <strong>{{nome}}</strong>,</p><p style=\"margin: 0;\">Hoje é <strong>{{data_recebimento}}</strong> e esta é a mensagem que você escreveu para si mesmo em <strong>{{data_envio}}</strong>.</p>";
    var template = ProcessTemplate(templateRaw, capsula);
    var res = await mailJet.SendEmail(from, subject, capsula.Email.Address, template);
    return res;
  }

  private string ProcessTemplate(string templateRaw, CapsulaModel capsula)
  {
    return templateRaw.Replace("{{nome}}", capsula.Name)
      .Replace("{{data_recebimento}}", capsula.DateToSend.ToShortDateString())
      .Replace("{{data_envio}}", capsula.CreatedAt.ToShortDateString());
  }
}