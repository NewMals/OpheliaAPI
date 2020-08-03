using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs.Ophelia.Usuarios
{
    public class DTOUsuariosRoles
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }
        
        [JsonIgnore]
        public bool Interno { get; set; }

    }
}
