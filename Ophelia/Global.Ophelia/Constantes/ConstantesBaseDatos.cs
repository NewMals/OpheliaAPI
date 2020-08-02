using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Ophelia.Constantes
{
    public static class ConstantesBaseDatos
    {
        public const string Schema = "OPH";
        public const string SchemaAudit = "OPH_AUDIT";
        public const string SchemaConfiguration = "OPH_SYS";

    }

    public enum UsuariosRoles
    {
        Sistema = 1,
        Cliente = 2,
        Proveedor = 3
    }
}
