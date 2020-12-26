using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRUDSystem.Models
{
    public class Tabla
    {
        public Tabla()
        {
            //this.Procedimientos = new HashSet<Procedimiento>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Procedimiento> Procedimientos { get; set; }
    }
}
