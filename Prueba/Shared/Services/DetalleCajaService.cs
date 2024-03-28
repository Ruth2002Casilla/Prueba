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
    public class DetalleCajaService
    {
        private readonly Context _context;

        public DetalleCajaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.DetalleCaja.AnyAsync(d => d.Id == Id);
        }

        public async Task<bool> Agregar(DetalleCaja Detalle)
        {
            _context.DetalleCaja.Add(Detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(DetalleCaja Detalle)
        {
            _context.Update(Detalle);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Detalle).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(DetalleCaja Detalle)
        {
            if (!await Verificar(Detalle.Id))
                return await Agregar(Detalle);
            else
                return await Modificar(Detalle);
        }

        public async Task<bool> Eliminar(DetalleCaja Detalle)
        {
            var cantidad = await _context.DetalleCaja
                .Where(d => d.Id == Detalle.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<DetalleCaja?> Buscar(int Id)
        {
            return await _context.DetalleCaja
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == Id);
        }

        public async Task<List<DetalleCaja>> Listar(Expression<Func<DetalleCaja, bool>> criterio)
        {
            return await _context.DetalleCaja
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
