using Ninject.Modules;
using JsonLib;
using Ninject.Web.Common;
//using DbLib;

namespace Lab6.App_Start
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<PhoneRepository>().InTransientScope().Named("Transient");

            Bind<IPhoneDictionary>().To<PhoneRepository>().InThreadScope().Named("Thread");

            Bind<IPhoneDictionary>().To<PhoneRepository>().InRequestScope().Named("Request");
        }
    }
}