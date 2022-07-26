using System;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Delivery.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private static int _senha = 0;
        private static List<Pedido> _pedidos = new List<Pedido>();

        [HttpGet]
        public List<Pedido> Get()
        {   
            if(!string.IsNullOrEmpty(_pedidos)){
                return _pedidos;
            }

            return Problem("Nenhum pedido realizado");
            
        }

        [HttpPost]
        public ActionResult<Pedido> Post(string origem)
        {
            if (!string.IsNullOrEmpty(origem))
            {
                var pedido = new Pedido()
                {
                    Origem = origem, 
                    Senha = ++_senha

                }; 

                _pedidos.Add(pedido);
                return Ok(pedido);
            }

            return BadRequest("Origem vazia");

        }
     
    }
}
