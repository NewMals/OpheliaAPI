using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs.Ophelia.General
{
    public class DTOResultado
    {
        public int Codigo { get; set; }

        public string Mensaje { get; set; }

    }
}
