using System.Text.RegularExpressions;
using Backend.Domain;
using Backend.Domain.Exception;
using Microsoft.AspNetCore.Identity.Data;

namespace Backend.Domain.Helper;

public static class EmailHelper
{
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);


    public static void ValidateEmailFormat(string email)
    {
        if (!EmailRegex.IsMatch(email)) throw new EmailFormatException("Invalid email format");
    }
    
}