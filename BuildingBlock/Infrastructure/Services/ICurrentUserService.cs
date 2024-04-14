namespace Infrastructure.Services;

public interface ICurrentUserService
{
    IUserSession GetCurrentUser();
}
