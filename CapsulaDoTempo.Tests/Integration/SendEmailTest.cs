using CapsulaDoTempo.Entities;
using CapsulaDoTempo.Services;
using CapsulaDoTempo.Services.Adapters;
using Microsoft.Extensions.Options;
using Xunit;

namespace CapsulaDoTempo.Tests.Units;

public class SendEmailTest
{
  [Fact]
  public async Task SuccessEmail()
  {
    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
    var settings = config.GetSection("MailJet").Get<MailJetSettings>();
    var options = Options.Create(settings);
    var sender = new EmailSender(options);
    var name = "John";
    var message = "Mensagem de teste";
    var expectPathImage = "/home/otavio/RiderProjects/CapsulaDoTempo/CapsulaDoTempo/public/upload/image/test.png";
    var emailAddress = "lugaresparairsender@gmail.com";
    var capsula = new CapsulaModel(name, message, emailAddress);
    var dateToSend = DateTime.Now.AddDays(1);
    capsula.SetDateTimeToSend(dateToSend);
    capsula.SetPathImage("test.png");
    var emailFrom = "lugaresparairsender@gmail.com";
    var res = await sender.SendCapsulaEmail(capsula, emailFrom);
    Assert.Equal("success", res.Messages[0].Status);
  }
  [Fact]
  public async Task FailureInWrongAddress()
  {
    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
    var settings = config.GetSection("MailJet").Get<MailJetSettings>();
    var options = Options.Create(settings);
    var sender = new EmailSender(options);
    var name = "John";
    var message = "Mensagem de teste";
    var expectPathImage = "/home/otavio/RiderProjects/CapsulaDoTempo/CapsulaDoTempo/public/upload/image/test.png";
    var emailAddress = "lugaresparairsender@gmail.com";
    var capsula = new CapsulaModel(name, message, emailAddress);
    var dateToSend = DateTime.Now.AddDays(1);
    capsula.SetDateTimeToSend(dateToSend);
    capsula.SetPathImage("test.png");
    var wrongEmailFrom = "lugaresparairsendergmail.com";
    await Assert.ThrowsAnyAsync<Exception>(async () => await sender.SendCapsulaEmail(capsula, wrongEmailFrom));
    }
}