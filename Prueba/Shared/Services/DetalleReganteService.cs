using Connection.Dal;
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
    public class DetalleReganteService
    {
        private readonly Context _context;

        public DetalleReganteService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.DetalleRegante.AnyAsync(d => d.Id == Id);
        }

        public async Task<bool> Agregar(DetalleRegante Detalle)
        {
            _context.DetalleRegante.Add(Detalle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(DetalleRegante Detalle)
        {
            _context.Update(Detalle);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Detalle).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(DetalleRegante Detalle)
        {
            if (!await Verificar(Detalle.Id))
                return await Agregar(Detalle);
            else
                return await Modificar(Detalle);
        }

        public async Task<bool> Eliminar(DetalleRegante Detalle)
        {
            var cantidad = await _context.DetalleRegante
                .Where(d => d.Id == Detalle.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<DetalleRegante?> Buscar(int Id)
        {
            return await _context.DetalleRegante
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == Id);
        }

        public async Task<List<DetalleRegante>> Listar(Expression<Func<DetalleRegante, bool>> criterio)
        {
            return await _context.DetalleRegante
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
