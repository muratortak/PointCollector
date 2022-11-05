namespace PointCollector.Contracts.Authentication;

public record RegistrationRequest(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password);