using Backend.DAL;
using Backend.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BL
{
    public class NotaBL
    {
        public async Task<int> CrearAsync(Nota pNota)
        {
            return await NotaDAL.CrearAsync(pNota);
        }


        public async Task<int> ModificarAsync(Nota pNota)
        {
            return await NotaDAL.ModificarAsync(pNota);
        }
        public async Task<int> EliminarAsync(Nota pNota)
        {
            return await NotaDAL.EliminarAsync(pNota);
        }
        public async Task<Nota> ObtenerPorIdAsync(Nota pNota)
        {
            return await NotaDAL.ObtenerPorIdAsync(pNota);
        }
        public async Task<List<Nota>> ObtenerTodosAsync()
        {
            return await NotaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Nota>> BuscarAsync(Nota pNota)
        {
            return await NotaDAL.BuscarAsync(pNota);
        }


    }
}
