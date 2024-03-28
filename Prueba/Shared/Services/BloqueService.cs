﻿using Connection.DAL;
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
    public class BloqueService
    {
        private readonly Context _context;

        public BloqueService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int BloqueId)
        {
            return await _context.Bloque.AnyAsync(b => b.BloqueId == BloqueId);
        }

        public async Task<bool> Agregar(Bloques Bloques)
        {
            _context.Bloque.Add(Bloques);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Bloques Bloques)
        {
            _context.Update(Bloques);
            int cantidad = await _context.SaveChangesAsync();
            _context.Entry(Bloques).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Guardar(Bloques Bloques)
        {
            if (!await Verificar(Bloques.BloqueId))
                return await Agregar(Bloques);
            else
                return await Modificar(Bloques);
        }

        public async Task<bool> Eliminar(Bloques Bloques)
        {
            var cantidad = await _context.Bloque
                .Where(b => b.BloqueId == Bloques.BloqueId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Bloques?> Buscar(int BloqueId)
        {
            return await _context.Bloque
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BloqueId == BloqueId);
        }

        public async Task<List<Bloques>> Listar(Expression<Func<Bloques, bool>> criterio)
        {
            return await _context.Bloque
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
