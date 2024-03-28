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
    public class ParametrosOperacionalesService
    {
        private readonly Context _context;

        public ParametrosOperacionalesService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int Id)
        {
            return await _context.ParametroOperacionales.AnyAsync(pos => pos.Id == Id);
        }

        public async Task<bool> Agregar(ParametroOperacionales POS)
        {
            _context.ParametroOperacionales.Add(POS);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(ParametroOperacionales POS)
        {
            _context.Update(POS);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(POS).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(ParametroOperacionales POS)
        {
            if (!await Verificar(POS.Id))
                return await Agregar(POS);
            else
                return await Modificar(POS);
        }

        public async Task<bool> Eliminar(ParametroOperacionales POS)
        {
            var cantidad = await _context.ParametroOperacionales
                .Where(pos => pos.Id == POS.Id)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<ParametroOperacionales?> Buscar(int Id)
        {
            return await _context.ParametroOperacionales
                .AsNoTracking()
                .FirstOrDefaultAsync(pos => pos.Id == Id);
        }

        public async Task<List<ParametroOperacionales>> Listar(Expression<Func<ParametroOperacionales, bool>> criterio)
        {
            return await _context.ParametroOperacionales
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
