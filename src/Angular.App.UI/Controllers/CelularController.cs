using Angular.App.Application;
using Angular.App.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angular.App.UI.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class CelularController : ApiController
    {
        private ClienteService _db = new ClienteService();

        [HttpGet]
        [Route("celulares")]
        public IQueryable<CelularModel> ObterTodosCelulares()
        {
            return _db.ObterTodos();
        }
        [HttpGet]
        [Route("celular/{id:int}")]
        public HttpResponseMessage ObterCelularPorId(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, _db.ObterPorId(id));
        }

        [HttpPut]
        [Route("putCelular")]
        public HttpResponseMessage AtualizarCelular(CelularModel celular)
        {
            if (celular == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Atualizar(celular);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("postCelular")]
        public HttpResponseMessage AdicionarCelular(CelularModel celular)
        {
            if (celular == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Incluir(celular);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("deleteCelular/{id:int}")]
        public HttpResponseMessage RemoverCelular(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _db.Excluir(id); 
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
