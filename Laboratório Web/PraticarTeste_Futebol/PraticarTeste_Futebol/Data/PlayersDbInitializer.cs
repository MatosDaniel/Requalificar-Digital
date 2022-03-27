using PraticarTeste_Futebol.Models;

namespace PraticarTeste_Futebol.Data
{
    public static class PlayersDbInitializer
    {
        public static void InsertData(PlayersContext context)
        {
            var team_ = new Team
            {
                Name = "Sporting"
            };
            context.Teams.Add(team_);

            context.Players.Add(new Player
            {
                Name = "Daniel", 
                Age = 25,
                Number = 3,
                team = team_,
            });
        }
    }
}
