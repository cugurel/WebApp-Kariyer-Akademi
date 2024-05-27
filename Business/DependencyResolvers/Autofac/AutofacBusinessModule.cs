using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Customer bağımlılıkları
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerDal>().SingleInstance();

            //Category bağımlılıkları
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryDal>().SingleInstance();


            //Movie bağımlılıkları
            builder.RegisterType<MovieManager>().As<IMovieService>().SingleInstance();
            builder.RegisterType<EfMovieRepository>().As<IMovieDal>().SingleInstance();

            //Director bağımlılıkları
            builder.RegisterType<DirectorManager>().As<IDirectorService>().SingleInstance();
            builder.RegisterType<EfDirectorRepository>().As<IDirectorDal>().SingleInstance();
        }
    }
}
