using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace CapsulaDoTempo.Entities.ValueObjects;
[Owned]
public class Email
{
  protected Email() {}
  public string Address { get; }
  public Email(string address)
  {
    if (string.IsNullOrEmpty(address) || address.Length < 5)
    {
      throw new ValidationException();
    }

    Address = address.ToLower().Trim();
    const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    if (!Regex.IsMatch(Address, pattern))
    {
      throw new ValidationException("The email address does not follow the email standard");
    }
  }
}