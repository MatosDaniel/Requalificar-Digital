using Microsoft.EntityFrameworkCore;
using PraticarTeste_Futebol.Models;

namespace PraticarTeste_Futebol.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly PlayersContext context;

        public PlayerService(PlayersContext context)
        {
            this.context = context;
        }

        public Player Create(Player player)
        {
            Team team = context.Teams.Find(player.team.ID);
            if (team == null)
            {
                throw new NullReferenceException("A equipa indicada não existe");
            }
            else
            {
                player.team = team;
                context.Players.Add(player);
                context.SaveChanges();
                return player;
            }            
        }

        public void DeleteByID(int id)
        {
            var playerToDelete = GetByID(id);
            if (playerToDelete is not null)
            {
                context.Players.Remove(playerToDelete);
                context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Jogador não encontrado");
            }
        }

        public void Download()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Player> GetAll()
        {
            var players = context.Players.Include(p => p.team);
            return players;
        }

        public Player GetByID(int id)
        {
            var player = context.Players.Include(t => t.team).SingleOrDefault(p => p.ID == id);
            return player;

        }

        public Player GetByTeam(Team team)
        {
            var player = context.Players.SingleOrDefault(p => p.team == team);
            return player;
        }

        public void Update(int id, Player player)
        {
            var playerToUpdate = context.Players.Include(t => t.team).SingleOrDefault(p => p.ID == id);
            if(playerToUpdate is not null)
            {
                playerToUpdate.Name = player.Name;
                playerToUpdate.Age = player.Age;
                playerToUpdate.Number = player.Number;
                playerToUpdate.team = player.team;
                context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Jogador não encontrado");
            }
            
        }

        public void UpdateTeam(int id, int teamid)
        {
            var bookToUpdate = context.Players.Find(id);
            var teamToUpdate = context.Teams.Find(teamid);

            if(bookToUpdate is null || teamToUpdate is null)
            {
                throw new NullReferenceException("Jogador ou equipa não existem");
            }
            else
            {
                bookToUpdate.team = teamToUpdate;
            }
            context.SaveChanges();
        }
    }
}
