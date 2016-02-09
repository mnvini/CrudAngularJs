using Angular.App.Data.EntityConfig;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Angular.App.Data.Repository
{
    public class CelularRepository
    {
        private readonly DataContext _context = new DataContext();
        public CelularModel ObterPorTipoChip(string tipoChip)
        {
            var sql = @"select * from celulares c" +
                "Where c.tipochip = @tipoChip";

            using (var cn = _context.Database.Connection)
            {
                cn.Open();
                var cliente = cn.Query<CelularModel>(sql);
                return cliente.FirstOrDefault();
            }
        }

        public CelularModel ObterPorMarca(string marca)
        {
            var sql = @"select * from celulares c" +
                 "Where c.marca = @marca";

            using (var cn = _context.Database.Connection)
            {
                cn.Open();
                var cliente = cn.Query<CelularModel>(sql);
                return cliente.FirstOrDefault();
            }
        }

        public CelularModel ObterPorId(int id)
        {
            var sql = @"select * from celulares c " +
                 "Where c.id = @id";

            using (var cn = _context.Database.Connection)
            {
                cn.Open();
                var cliente = cn.Query<CelularModel>(sql, new { id = id });
                return cliente.FirstOrDefault();
            }
        }

        public IQueryable<CelularModel> ObterTodos()
        {
            return _context.Celular;
        }

        public void Atualizar(CelularModel celular)
        {
            _context.Entry(celular).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Incluir(CelularModel celular)
        {
            _context.Celular.Add(celular);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            _context.Celular.Remove(_context.Celular.Find(id));
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
