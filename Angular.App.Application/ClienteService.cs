using Angular.App.Data.EntityConfig;
using Angular.App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Angular.App.Application
{
    public class ClienteService
    {
        private CelularRepository _repository = new CelularRepository();

        public CelularModel ObterPorTipoChip(string tipoChip)
        {
            return _repository.ObterPorTipoChip(tipoChip);
        }

        public CelularModel ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IQueryable<CelularModel> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Atualizar(CelularModel celular)
        {
            _repository.Atualizar(celular);
        }

        public void Incluir(CelularModel celular)
        {
            _repository.Incluir(celular);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
