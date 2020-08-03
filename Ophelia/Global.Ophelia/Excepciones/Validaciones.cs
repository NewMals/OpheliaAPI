using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Global.Ophelia.Excepciones
{
    public static class Validaciones
    {
        public static Excepcion ValidacionesDto(ModelStateDictionary modelState)
        {
            var validacionesDTO = modelState.First();
            //si el mensaje de error no esta personalizado lanzar el del sistema
            var errorMessage = string.IsNullOrEmpty(validacionesDTO.Value.Errors.First().ErrorMessage) ?
                                      validacionesDTO.Value.Errors.First().Exception.Message :
                                      validacionesDTO.Value.Errors.First().ErrorMessage;

            Type type = typeof(DiccionarioMensajes);
            Excepcion excepcion;
            Excepcion buscarExcepcion;

            if (type.GetField(errorMessage) != null)
                buscarExcepcion = (Excepcion)type.GetField(errorMessage).GetValue(DiccionarioMensajes.Get());
            else
                buscarExcepcion = type.GetFields().Where(w => w.FieldType == typeof(Excepcion)).Select(s => (Excepcion)s.GetValue(DiccionarioMensajes.Get())).Where(w => w.Mensaje == errorMessage).FirstOrDefault();

            if (buscarExcepcion != null)
            {
                excepcion = buscarExcepcion;
                excepcion.Mensaje = $"{validacionesDTO.Key} : {excepcion.Mensaje}";
            }
            else
            {
                excepcion = DiccionarioMensajes.Get().AnotacionesNoControladas;
                excepcion.Mensaje = excepcion.Mensaje.Replace("{0}", errorMessage);
            }
            return excepcion;
        }
    }
}
