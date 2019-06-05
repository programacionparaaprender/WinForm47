using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSystem
{
    class Arbol
    {
        private List<Arbol> children;
        private int id;
        private string text;
        private int id_padre;
        private Boolean elimina;
        public Arbol(int id, string text, int id_padre)
        {
            this.id = id;
            this.text = text;
            this.id_padre = id_padre;
            this.elimina = false;
            this.children = new List<Arbol>();
        }
        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }
        public int Id_padre { get => id_padre; set => id_padre = value; }
        public bool Elimina { get => elimina; set => elimina = value; }
        internal List<Arbol> Children { get => children; set => children = value; }
    }
}
