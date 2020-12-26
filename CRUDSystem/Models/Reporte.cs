using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class Reporte
    {
        public Reporte()
        {
            //this.Procedimientos = new HashSet<Procedimiento>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Procedimiento> Procedimientos { get; set; }
    }
}
