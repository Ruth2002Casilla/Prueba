using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Connection.Dal;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Shared.Services
{
    public class AsociacionService
    {
        private readonly Context _context;

        public AsociacionService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int AsociacionId)
        {
            return await _context.Asociacion.AnyAsync(a => a.AsociacionId == AsociacionId);
        }

        public async Task<bool> Agregar(Asociacion Asociacion)
        {
            _context.Asociacion.Add(Asociacion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Asociacion Asociacion)
        {
            _context.Update(Asociacion);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Asociacion).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(Asociacion Asociacion)
        {
            if (!await Verificar(Asociacion.AsociacionId))
                return await Agregar(Asociacion);
            else
                return await Modificar(Asociacion);
        }

        public async Task<bool> Eliminar(Asociacion Asociacion)
        {
            var cantidad = await _context.Asociacion
                .Where(a => a.AsociacionId == Asociacion.AsociacionId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Asociacion?> Buscar(int AsociacionId)
        {
            return await _context.Asociacion
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AsociacionId == AsociacionId);
        }

        public async Task<List<Asociacion>> Listar(Expression<Func<Asociacion, bool>> criterio)
        {
            return await _context.Asociacion
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
