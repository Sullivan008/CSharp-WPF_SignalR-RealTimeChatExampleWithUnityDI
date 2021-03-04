namespace Application.Client.Core.AppUser.Services.Interfaces
{
    public interface IAppUserService
    {
        void SetAppUser(string userName);

        bool IsAppUserExist();

        string GetUserName();

        void RemoveAppUser();
    }
}
