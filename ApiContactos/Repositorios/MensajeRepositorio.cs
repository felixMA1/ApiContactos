using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using ApiContactos.Adapters;
using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Repositorio;

namespace ApiContactos.Repositorios
{
    public class MensajeRepositorio:BaseRepositorioEntity<Mensaje,MensajeModel,MensajeAdapter>
    {
        public MensajeRepositorio(DbContext context) : base(context)
        {
        }

        //Recuperar mensajes enviados a un usuario (bandeja de entrada de un usuario).
        public ICollection<MensajeModel> GetByDestino(int idDestino)
        {
            var data = Get(o => o.idDestino == idDestino).OrderByDescending(o => o.fecha);
            return data.ToList();
        }

        //Recuperar mensajes que un usuario envia
        public ICollection<MensajeModel> GetByOrigen(int idOrigen)
        {
            var data = Get(o => o.idOrigen == idOrigen).OrderByDescending(o => o.fecha);
            return data.ToList();
        }
    }
}