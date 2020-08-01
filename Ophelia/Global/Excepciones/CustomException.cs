using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Ophelia.Excepciones
{
    [Serializable]
    public class CustomException : Exception
    {
        private readonly dynamic DTOException;
        public int StatusCode;
        public CustomException(Excepcion excepcion) : base(excepcion.Mensaje)
        {
            StatusCode = excepcion.StatusCode;
            DTOException = new
            {
                codigo = excepcion.Codigo,
                error = excepcion.Mensaje
            };
        }

        public dynamic GetException()
        {
            return DTOException;
        }
    }

    public class Excepcion
    {
        private static Excepcion instancia = null;
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public int StatusCode { get; set; }

        private Excepcion(int _statusCode, int _codigo, string _mensaje)
        {
            StatusCode = _statusCode;
            Codigo = _codigo;
            Mensaje = _mensaje;
        }
        public static Excepcion GetExcepcion(int _statusCode, int _codigo, string _mensaje)

        {
            instancia = null;
            instancia = new Excepcion(_statusCode, _codigo, _mensaje);
            return instancia;
        }

        public static Excepcion GetEmpty()
        {
            instancia = null;
            instancia = new Excepcion(0, 0, string.Empty);
            return instancia;
        }
    }
}
