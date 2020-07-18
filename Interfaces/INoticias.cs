using System.Collections.Generic;
using ProjetoE_Players.Models;

namespace ProjetoE_Players.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);

         List<Noticias> ReadAll();

         void Update (Noticias n);

         void Delete(int IdNoticias);
    }
}