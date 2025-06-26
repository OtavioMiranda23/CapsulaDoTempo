using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;
using CapsulaDoTempo.Entities.ValueObjects;

namespace CapsulaDoTempo.Entities;

public class CapsulaModel
{
    public Guid Uuid { get; set; }
    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public Email Email { get; }
    public string? PathImage { get; set; }
    public bool HasSent { get; }
    public DateTime DateToSend { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private CapsulaModel(){}

    public CapsulaModel(string message, string emailAddress)
    {
      var email = new Email(emailAddress);
      Email = email;
      Message = message;
      HasSent = false;
      CreatedAt = DateTime.Now;
      
    }
    public void SetPathImage(string imageName)
    {
      var regexPattern = @"\.(gif|jpe?g|tiff?|png|webp|bmp)$";
      var match = Regex.Match(imageName, regexPattern);
      if (!match.Success)
      {
        throw new ArgumentOutOfRangeException(nameof(imageName), $"Extension image {imageName} must be gif|jpg|jpeg|tiff|png|webp|bmp");
      }
      var baseDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
      if (baseDirectory == null)
      {
        throw new DirectoryNotFoundException();
      }
      PathImage = $"{baseDirectory}/public/upload/image/{imageName}";
    }

    public void SetDateTimeToSend(DateTime dateToSend)
    {
      if (CreatedAt > dateToSend) throw new ArgumentOutOfRangeException(nameof(dateToSend), "Date to send email must be greater than the capsule creation date");
    }
}