﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDSystem.Models
{
    public class Procedimiento
    {
        //public Procedimiento()
        //{
        //    this.TablaProcedimientos = new HashSet<Tabla>();
        //    this.Reportes = new HashSet<Reporte>();
        //    this.Formularios = new HashSet<Formulario>();
        //}
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TablaProcedimiento> TablaProcedimientos { get; set; }
        //public virtual ICollection<Reporte> Reportes { get; set; }
        //public virtual ICollection<Formulario> Formularios { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
