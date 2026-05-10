namespace Backend.Domain.Exception;

public class DulplicateEmailException(string message) : System.Exception(message) { }
