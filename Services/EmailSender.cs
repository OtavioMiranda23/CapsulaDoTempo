using CapsulaDoTempo.Entities;
using CapsulaDoTempo.Services.Adapters;

namespace CapsulaDoTempo.Services;

public class EmailSender
{
  private readonly IJobScheduler _scheduler;

  public EmailSender(IJobScheduler scheduler)
  {
    _scheduler = scheduler;
  }
  public void SendCapsulaEmail(CapsulaModel capsula, string from, TimeSpan delayDate)
  {
    var subject = "Sua Cápsula do Tempo está aberta ";
    var templateRaw = "<p style=\"margin: 0 0 16px 0;\">Olá <strong>{{nome}}</strong>,</p><p style=\"margin: 0;\">Hoje é <strong>{{data_recebimento}}</strong> e esta é a mensagem que você escreveu para si mesmo em <strong>{{data_envio}}</strong>.</p>";
    var template = ProcessTemplate(templateRaw, capsula);
    _scheduler.Schedule<EmailJob>(job => job.Send(from, capsula.Email.Address, subject, template), DateTime.UtcNow.Add(delayDate));
  }
  private string ProcessTemplate(string templateRaw, CapsulaModel capsula)
  {
    return templateRaw.Replace("{{nome}}", capsula.Name)
      .Replace("{{data_recebimento}}", capsula.DateToSend.ToShortDateString())
      .Replace("{{data_envio}}", capsula.CreatedAt.ToShortDateString());
  }
}