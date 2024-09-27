using ApiGateway.User.Helpers;

namespace ApiGateway.User.Register
{
    public static class RegisterOcelot
    {
        public static IServiceCollection ServiceRegisterOcelot(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var ocelotSettings = new OcelotSetting();
            configurationManager.GetSection("OcelotSetting").Bind(ocelotSettings);
            if (ocelotSettings != null)
            {
                var currentDirectory = Environment.CurrentDirectory;
                foreach (var item in ocelotSettings.OcelotNames)
                {

                    var filePath = Path.Combine(currentDirectory, "OcelotJson", item);

                    configurationManager.AddJsonFile(filePath, optional: false, reloadOnChange: true);
                }
            }
            return services;
        }
    }
}
