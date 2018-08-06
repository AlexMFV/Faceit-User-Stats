using System.Collections;

namespace Faceit_Stats
{
    public class Teams : CollectionBase
    {
        public void Adicionar(Team team)
        {
            List.Add(team);
        }

        public void Remover(Team team)
        {
            List.Remove(team);
        }

        public Team this[int idxTeam]
        {
            get
            {
                return (Team)List[idxTeam];
            }
            set
            {
                List[idxTeam] = value;
            }
        }
    }
}
