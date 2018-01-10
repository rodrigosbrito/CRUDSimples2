using CRUDSimples2.Data.Context;
using CRUDSimples2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUDSimples2.Controllers
{
    public class ClientesController : Controller
    {
        private Context db = new Context();

        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            List<Cliente> clientes = null;

            clientes = db.Clientes.OrderBy(c => c.Nome).ToList();

            return new JsonResult { Data = clientes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetById(int id)
        {
            Cliente cliente = null;
            cliente = db.Clientes.Find(id);

            return new JsonResult { Data = cliente, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Cliente cliente)
        {
            string mensagem = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    mensagem = "Sucesso";
                }
                else
                {
                    mensagem = "Preencha os campos corretamente!";
                }
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return new JsonResult { Data = mensagem, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult Delete(int clienteId)
        {
            Cliente cliente = db.Clientes.Find(clienteId);
            db.Clientes.Remove(cliente);

            return new JsonResult { Data = "Cliente Deletado", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}