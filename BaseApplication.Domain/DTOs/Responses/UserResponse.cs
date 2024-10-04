namespace BaseApplication.Domain.DTOs.Responses;

public record UserResponse(int Id, string Name, string Gender, int Age, string Cpf, string PhoneNumber)
{
    
}