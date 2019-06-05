using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDSystem
{
    class NodoArbol: TreeNode
    {
        private int id_padre;
        private int id;
        private Boolean elimina = false;
        public NodoArbol()
        {

        }

        public int Id_padre { get => id_padre; set => id_padre = value; }
        public int Id { get => id; set => id = value; }
        public bool Elimina { get => elimina; set => elimina = value; }
    }
}
