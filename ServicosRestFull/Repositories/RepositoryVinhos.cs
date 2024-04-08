using Microsoft.EntityFrameworkCore;
using ServicosRestFull.Models;

namespace ServicosRestFull.Repositories
{
    public class RepositoryVinhos : IRepositoryVinhos
    {
        private readonly MeuBanco _context;
        public RepositoryVinhos(MeuBanco context)
        {
            _context = context;
        }
        public void DeleteVinhos(Vinho vinho)
        {
            _context.Vinho.Remove(vinho);
            this.Save();
        }

        public IEnumerable<Vinho> GetVinhos()
        {
            return _context.Vinho.ToList();
        }

        public Vinho GetVinhosById(int id)
        {
            return _context.Vinho.Find(id);
        }

        public void InsertVinhos(Vinho vinho)
        {
             _context.Vinho.Add(vinho);
            this.Save();

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateVinhos(Vinho vinho)
        {
            _context.Entry(vinho).State = EntityState.Modified;
            this.Save();
        }
    }
}
