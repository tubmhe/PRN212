using DataAccess.ViewModels;

namespace DataAccess.Repository.Service
{
    public interface IServiceRepository
    {
        public IEnumerable<ServiceViewModel> GetServices();
        public void AddService(Models.Service service);
        public void UpdateService(Models.Service service);
    }
}
