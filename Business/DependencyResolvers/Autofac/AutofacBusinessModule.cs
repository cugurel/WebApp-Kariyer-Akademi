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
            //Category bağımlılıkları
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryDal>().SingleInstance();


            //Movie bağımlılıkları
            builder.RegisterType<MovieManager>().As<IMovieService>().SingleInstance();
            builder.RegisterType<EfMovieRepository>().As<IMovieDal>().SingleInstance();
        }
    }
}
