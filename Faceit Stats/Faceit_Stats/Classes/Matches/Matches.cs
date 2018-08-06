using System.Collections;

namespace Faceit_Stats
{
    public class Matches : CollectionBase
    {
        public void Adicionar(Match game)
        {
            List.Add(game);
        }

        public void Remover(Match game)
        {
            List.Remove(game);
        }

        public Match this[int idxGame]
        {
            get
            {
                return (Match)List[idxGame];
            }
            set
            {
                List[idxGame] = value;
            }
        }
    }
}
