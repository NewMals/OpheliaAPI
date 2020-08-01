using Microsoft.AspNetCore.Http;
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

        public readonly Excepcion ParametroRequerido = Excepcion.GetExcepcion(PreconditionFailed, 1, "Parametro no enviado.");

    }

}
