﻿using ProyectoEcommerceDatos;
using ProyectoEcommerceModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEcommerceNegocio
{
    public class ValidarPagoNegocios
    {
        TarjetaDatos tarjetaDatos = new TarjetaDatos();

        public bool ValidarPago(out string mensaje,
                                int tipoTarjeta,
                                string numeroTarjeta,
                                string titularTarjeta,
                                double montoConsumir,
                                string mesExpiracion,
                                string añoExpiracion,
                                string codigoSeguridad)
        {
                
            bool ValidacionCorrecta = false;
            mensaje = "";

            //Verificar que la tarjeta exista

            //LLamar a la capa de datos
           TarjetaInfo tarjetaInfo =  tarjetaDatos.ObtenerInformacionTarjeta( tipoTarjeta,
                                 numeroTarjeta,
                                 titularTarjeta,
                                 mesExpiracion,
                                 añoExpiracion,
                                 codigoSeguridad);

            //Validar que la tarjeta exista
            //validar que la tarjeta exista
            if (tarjetaInfo == null)
            {
                mensaje = "Tarjeta no Existe";
            }
            //la tarjeta existe
            else
            {
                //validar que la tarjeta este habilitada
                if (!tarjetaInfo.tarjetaHabilitada)
                {
                    mensaje = "Tarjeta No Habilitada";
                }
                //si la tarjeta no esta deshabilitada
                else
                {
                    // disponible : 99 , monto : 100
                    if (tarjetaInfo.creditoDisponible < montoConsumir)
                    {
                        mensaje = "Linea de credito insuficiente";
                    }
                    else
                    {
                        ValidacionCorrecta = true;
                    }
                }
            }

            return ValidacionCorrecta;
        }
    }
}
