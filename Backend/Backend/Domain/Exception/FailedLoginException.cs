namespace Backend.Domain.Exception;

public class FailedLoginException(string message) : System.Exception(message) { }
