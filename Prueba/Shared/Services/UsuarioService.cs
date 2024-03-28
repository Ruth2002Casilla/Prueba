using Connection.DAL;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class UsuarioService
    {
        private readonly Context _context;

        public UsuarioService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int UsuarioId)
        {
            return await _context.Usuario.AnyAsync(u => u.UsuarioId == UsuarioId);
        }

        public async Task<bool> Agregar(Usuarios Usuario)
        {
            _context.Usuario.Add(Usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Usuarios Usuario)
        {
            _context.Update(Usuario);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Usuario).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(Usuarios Usuario)
        {
            if (!await Verificar(Usuario.UsuarioId))
                return await Agregar(Usuario);
            else
                return await Modificar(Usuario);
        }

        public async Task<bool> Eliminar(Usuarios Usuario)
        {
            var cantidad = await _context.Usuario
                .Where(u => u.UsuarioId == Usuario.UsuarioId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Usuarios?> Buscar(int UsuarioId)
        {
            return await _context.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UsuarioId == UsuarioId);
        }

        public async Task<List<Usuarios>> Listar(Expression<Func<Usuarios, bool>> criterio)
        {
            return await _context.Usuario
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
