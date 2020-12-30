using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class TablaProcedimiento
    {
        public int TablaId { get; set; }
        public int ProcedimientoId { get; set; }

        public Procedimiento Procedimiento { get; set; }
        public Tabla Tabla { get; set; }
    }
}
