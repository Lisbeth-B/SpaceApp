using SpaceApp.Entity;

namespace SpaceApp.Models
{
    public interface IUserService
    {
        User Register(RegisterModel user);
        User Login(LoginModel model);
        void UpdateIsMarried(UpdateIsMarriedModel model);
        void UpdateIsWorker(UpdateIsWorkerModel model);
        void UpdateAddress(UpdateAddressModel model);
        void Delete(int id);

    }
}
