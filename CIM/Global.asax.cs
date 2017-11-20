using Aplicacao;
using Aplicacao.Interface;
using Dominio.Interface.Servico;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Servico;
using Dominio.Servicos;
using Infraestrutura.Repositorios;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CIM
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            container.RegisterSingleton(typeof(IAplicacaoBase<>), typeof(AplicacaoBase<>));
            container.RegisterSingleton(typeof(IServicoBase<>), typeof(ServicoBase<>));
            container.RegisterSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

            container.Register<IEquipamentoAplicacao, EquipamentoAplicacao>(Lifestyle.Singleton);
            container.Register<IEquipamentoServico, EquipamentoServico>(Lifestyle.Singleton);
            container.Register<IEquipamentoRepositorio, EquipamentoRepositorio>(Lifestyle.Singleton);

            container.Register<IAndarAplicacao, AndarAplicacao>(Lifestyle.Singleton);
            container.Register<IAndarServico, AndarServico>(Lifestyle.Singleton);
            container.Register<IAndarRepositorio, AndarRepositorio>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}