﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Ophelia.Excepciones
{

    public class DiccionarioMensajes
    {
        private DiccionarioMensajes() { }
        private static DiccionarioMensajes Instancia = null;
        public static DiccionarioMensajes Get()
        {
            Instancia = null;
            Instancia = new DiccionarioMensajes();
            return Instancia;
        }

        public static int Unauthorized = StatusCodes.Status401Unauthorized;
        public static int Forbidden = StatusCodes.Status403Forbidden;
        public static int PreconditionFailed = StatusCodes.Status412PreconditionFailed;
        private const int BadRequest = StatusCodes.Status400BadRequest;

        public readonly Excepcion AnotacionesNoControladas = Excepcion.GetExcepcion(PreconditionFailed, 100, "Excepción no controlada: {0}.");
        public readonly Excepcion ParametroRequerido = Excepcion.GetExcepcion(PreconditionFailed, 101, "Parametro no enviado.");
        public readonly Excepcion PropiedadRequerida = Excepcion.GetExcepcion(PreconditionFailed, 102, "Propiedad vacia o no enviada.");
        public readonly Excepcion PropiedadNoExiste = Excepcion.GetExcepcion(BadRequest, 103, "{0} no ha sido cread{1} o fue eliminad{1}.");
        public readonly Excepcion ExisteUsuario = Excepcion.GetExcepcion(PreconditionFailed, 104, "El usuario con identificación {0}, ya se encuentra registrado");
        

    }

}
