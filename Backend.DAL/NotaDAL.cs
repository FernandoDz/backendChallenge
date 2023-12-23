using Backend.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class NotaDAL
    {
        public static async Task<int> CrearAsync(Nota pNota)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pNota);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Nota pNota)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var nota = await bdContexto.Notas.FirstOrDefaultAsync(s => s.Id == pNota.Id);
                nota.Nombre = pNota.Nombre;
                bdContexto.Update(nota);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Nota pNota)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var nota = await bdContexto.Notas.FirstOrDefaultAsync(s => s.Id == pNota.Id);
                bdContexto.Notas.Remove(nota);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Nota> ObtenerPorIdAsync(Nota pNota)
        {
            var nota = new Nota();
            using (var bdContexto = new BDContexto())
            {
                nota = await bdContexto.Notas.FirstOrDefaultAsync(s => s.Id == pNota.Id);
            }
            return nota;
        }

        public static async Task<List<Nota>> ObtenerTodosAsync()
        {
            var notas = new List<Nota>();
            using (var bdContexto = new BDContexto())
            {
                notas = await bdContexto.Notas.ToListAsync();
            }
            return notas;
        }

        internal static IQueryable<Nota> QuerySelect(IQueryable<Nota> pQuery, Nota pNota)
        {
            if (pNota.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pNota.Id);

            if (!string.IsNullOrWhiteSpace(pNota.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pNota.Nombre));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pNota.Top_Aux > 0)
                pQuery = pQuery.Take(pNota.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Nota>> BuscarAsync(Nota pNota)
        {
            var notas = new List<Nota>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Notas.AsQueryable();
                select = QuerySelect(select, pNota);
                notas = await select.ToListAsync();
            }
            return notas;
        }
    }
}
