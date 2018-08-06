using System.Collections;

namespace Faceit_Stats
{
    public class Players : CollectionBase
    {
        public void Adicionar(Player player)
        {
            List.Add(player);
        }

        public void Remover(Player player)
        {
            List.Remove(player);
        }

        public Player this[int idxPlayer]
        {
            get
            {
                return (Player)List[idxPlayer];
            }
            set
            {
                List[idxPlayer] = value;
            }
        }
    }
}
