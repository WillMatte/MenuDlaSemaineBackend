namespace Backend.Domain.Exception;

public class EntityNotFoundException(string message) : System.Exception(message) { }
