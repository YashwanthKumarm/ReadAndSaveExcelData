using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReadAndSaveExcelData.Startup))]
namespace ReadAndSaveExcelData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
