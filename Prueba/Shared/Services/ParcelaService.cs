
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
    public class ParcelaService
    {
        private readonly Context _context;

        public ParcelaService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int ParcelaId)
        {
            return await _context.Parcela.AnyAsync(p => p.ParcelaId == ParcelaId);
        }

        public async Task<bool> Agregar(Parcela Parcela)
        {
            _context.Parcela.Add(Parcela);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Parcela Parcela)
        {
            _context.Update(Parcela);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Parcela).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(Parcela Parcela)
        {
            if (!await Verificar(Parcela.ParcelaId))
                return await Agregar(Parcela);
            else
                return await Modificar(Parcela);
        }

        public async Task<bool> Eliminar(Parcela Parcela)
        {
            var cantidad = await _context.Parcela
                .Where(p => p.ParcelaId == Parcela.ParcelaId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Parcela?> Buscar(int ParcelaId)
        {
            return await _context.Parcela
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ParcelaId == ParcelaId);
        }

        public async Task<List<Parcela>> Listar(Expression<Func<Parcela, bool>> criterio)
        {
            return await _context.Parcela
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
