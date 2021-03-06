﻿using ProyectoEcommerceModelos;
using ProyectoEcommerceNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoEcommerceApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MarcaProdController : ApiController
    {
        MarcaProdNegocio negocios = new MarcaProdNegocio();

        [HttpGet]
        public List<MarcaProducto> listarComboMarcaProd()
        {
            var lista = negocios.listarComboMarcaProd();
            return lista;
        }

        [HttpGet]
        public MarcaProducto obtenerMarca(int codProdMar)
        {
            var marca = negocios.obtenerMarca(codProdMar);
            return marca;
        }
    }
}
