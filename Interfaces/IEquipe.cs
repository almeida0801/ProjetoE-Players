using System.Collections.Generic;
using ProjetoE_Players.Models;

namespace ProjetoE_Players.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

         List<Equipe> ReadAll();

         void Update (Equipe e);

         void Delete(int IdEquipe);
    }
}