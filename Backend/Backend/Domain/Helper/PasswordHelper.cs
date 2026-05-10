using Backend.Domain.Exception;

namespace Backend.Domain.Helper;

public static class PasswordHelper
{
    private const int MIN_PASSWORD_LENGTH = 10;
    public static void ValidatePasswordFormat(string password)
    {
        if (password.Length < MIN_PASSWORD_LENGTH) throw new PasswordFormatException($"Password must be at least {MIN_PASSWORD_LENGTH} characters.");
    }

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    public static bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}