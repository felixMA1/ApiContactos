using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using ApiContactos.Adapters;
using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Repositorio;

namespace ApiContactos.Repositorios
{
    public class UsuarioRepositorio:BaseRepositorioEntity<Usuario,UsuarioModel,UsuarioAdapter>
    {
        public UsuarioRepositorio(DbContext context) : base(context)
        {
        }

        public UsuarioModel Validar(String login, String password)
        {
            var data = Get(o => o.login == login && o.password == password);
            return data.Any() ? data.First() : null;
        }

        public bool isUnico(String login)
        {
            var data = Get(o => o.login == login);
            return !data.Any();
        }

        public override UsuarioModel Add(UsuarioModel model)
        {
            if (isUnico(model.login))
                return base.Add(model);
            return null;
        }
    }
}