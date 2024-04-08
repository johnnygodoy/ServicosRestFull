using ServicosRestFull.Models;

namespace ServicosRestFull.Repositories
{
    public interface IRepositoryVinhos
    {
        IEnumerable<Vinho> GetVinhos();
        Vinho GetVinhosById(int id);

        void InsertVinhos(Vinho vinho);        

        void UpdateVinhos(Vinho vinho);

        void DeleteVinhos(Vinho vinho);

        void Save();
    }
}
