namespace Backend.Domain.Exception;

public class DuplicateEntityException(string message) : System.Exception(message) { }
