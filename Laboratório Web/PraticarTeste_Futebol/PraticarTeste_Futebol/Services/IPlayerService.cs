using PraticarTeste_Futebol.Models;

namespace PraticarTeste_Futebol.Services
{
    public interface IPlayerService
    {
        public abstract IEnumerable<Player> GetAll();
        public abstract Player Create(Player player);
        public abstract void DeleteByID(int id);
        public abstract Player GetByID(int id);
        public abstract void Update(int id, Player player);
        public abstract Player GetByTeam(Team team);
        public abstract void Download();
        public abstract void UpdateTeam(int id, int teamid); 
    }
}
