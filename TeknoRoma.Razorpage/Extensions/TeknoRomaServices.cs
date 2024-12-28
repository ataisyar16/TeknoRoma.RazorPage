using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.BL.BL.Managers.Concrete;
using TeknoRoma.DAL.DAL.GenericRepository.Abstract;
using TeknoRoma.DAL.DAL.GenericRepository.Concrete;

namespace TeknoRoma.Razorpage.Extensions
{
    public static class TeknoRomaServices
    {
        public static IServiceCollection AddTeknoRomaServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IManager<>), typeof(Manager<>));

            return services;
        }
    }
}
