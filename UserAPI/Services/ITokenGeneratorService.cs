namespace UserAPI.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(int id, string? name, string? role);
    }
}
