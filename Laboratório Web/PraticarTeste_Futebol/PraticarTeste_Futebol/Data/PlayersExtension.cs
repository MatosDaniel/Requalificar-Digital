using PraticarTeste_Futebol.Models;

namespace PraticarTeste_Futebol.Data
{
    public static class PlayersExtension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using(var scope= host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<PlayersContext>();
                    if(context.Database.EnsureCreated())
                    {
                        PlayersDbInitializer.InsertData(context);
                    }
                }
            }
        }
    }
}
