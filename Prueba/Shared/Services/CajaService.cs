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
    public class CajaService
    {
        private readonly Context _context;

        public CajaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int CajaId)
        {
            return await _context.Caja.AnyAsync(c => c.CajaId == CajaId);
        }

        public async Task<bool> Agregar(Caja Caja)
        {
            _context.Caja.Add(Caja);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Caja Caja)
        {
            _context.Update(Caja);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Caja).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(Caja Caja)
        {
            if (!await Verificar(Caja.CajaId))
                return await Agregar(Caja);
            else
                return await Modificar(Caja);
        }

        public async Task<bool> Eliminar(Caja Caja)
        {
            var cantidad = await _context.Caja
                .Where(c => c.CajaId == Caja.CajaId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Caja?> Buscar(int CajaId)
        {
            return await _context.Caja
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CajaId == CajaId);
        }

        public async Task<List<Caja>> Listar(Expression<Func<Caja, bool>> criterio)
        {
            return await _context.Caja
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
