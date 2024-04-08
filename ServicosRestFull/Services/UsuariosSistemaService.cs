using Microsoft.EntityFrameworkCore;
using ServicosRestFull.Models;
using System;
using System.Linq;

namespace ServicosRestFull.Services
{
    public class UsuariosSistemaService
    {
        private readonly MeuBanco _context;

        public UsuariosSistemaService(MeuBanco context)
        {
            _context = context;
        }

        public void AddUsuario(UsuariosSistema usuario)
        {
            _context.UsuarioSistema.Add(usuario);
            _context.SaveChanges();
        }

        public UsuariosSistema GetUsuarioById(int id)
        {
            return _context.UsuarioSistema.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUsuario(UsuariosSistema usuario)
        {
            _context.UsuarioSistema.Update(usuario);
            _context.SaveChanges();
        }

        public void DeleteUsuario(int id)
        {
            var usuario = _context.UsuarioSistema.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _context.UsuarioSistema.Remove(usuario);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }
        }
    }
}
