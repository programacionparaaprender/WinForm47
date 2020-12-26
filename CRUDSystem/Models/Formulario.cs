using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CRUDSystem.Models
{
    public class Formulario
    {
        public Formulario()
        {
            //this.Procedimientos = new HashSet<Procedimiento>();
            //this.Reportes = new HashSet<Reporte>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Procedimiento> Procedimientos { get; set; }
        //public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
