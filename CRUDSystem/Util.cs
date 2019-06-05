using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDSystem
{
    class Util
    {

        public List<NodoArbol> añadirTreeView()
        {
            List<Arbol> estructura = new List<Arbol>();
            List<NodoArbol> lista = new List<NodoArbol>();
            List<NodoArbol> lista2 = new List<NodoArbol>();
            List<NodoArbol> lista3 = new List<NodoArbol>();
            estructura.Add(new Arbol(33, "Admin1", 1));
            estructura.Add(new Arbol(34, "Admin2", 33));
            estructura.Add(new Arbol(35, "Admin3", 33));
            estructura.Add(new Arbol(36, "Admin4", 1));
            estructura.Add(new Arbol(37, "Admin5", 36));
            estructura.Add(new Arbol(38, "Admin6", 36));
            estructura.Add(new Arbol(39, "Admin7", 1));
            estructura.Add(new Arbol(40, "Admin8", 37));
            estructura.Add(new Arbol(41, "Admin9", 39));
            estructura.Add(new Arbol(42, "Admin10", 39));
            estructura.Add(new Arbol(43, "Admin11", 1));
            estructura.Add(new Arbol(44, "Admin12", 33));
            TreeNode nuevoNodo = new TreeNode();
            foreach (Arbol arbol in estructura)
            {
                NodoArbol nodo = new NodoArbol();
                nodo.Id = arbol.Id;
                nodo.Text = arbol.Text;
                lista.Add(nodo);
            }
            lista2 = lista;
            foreach (NodoArbol arbol in lista)
            {
                foreach (NodoArbol arbol2 in lista2)
                {
                    if (arbol.Id == arbol2.Id_padre)
                    {
                        arbol.Nodes.Add(arbol2);
                        arbol2.Elimina = true;
                    }
                }
            }

            foreach (NodoArbol arbol in lista2)
            {
                if (arbol.Elimina == true)
                {
                    lista3.Add(arbol);
                }
            }

            foreach (NodoArbol arbol in lista3)
            {
                lista.Remove(arbol);
            }

            return lista;
        }
    

    public List<Arbol> añadir()
        {
            List<Arbol> estructura = new List<Arbol>();
            List<Arbol> lista = new List<Arbol>();
            List<Arbol> lista2 = new List<Arbol>();
            List<Arbol> lista3 = new List<Arbol>();
            estructura.Add(new Arbol(33,"Admin1",1));
            estructura.Add(new Arbol(34, "Admin2", 33));
            estructura.Add(new Arbol(35, "Admin3", 33));
            estructura.Add(new Arbol(36, "Admin4", 1));
            estructura.Add(new Arbol(37, "Admin5", 36));
            estructura.Add(new Arbol(38, "Admin6", 36));
            estructura.Add(new Arbol(39, "Admin7", 1));
            estructura.Add(new Arbol(40, "Admin8", 37));
            estructura.Add(new Arbol(41, "Admin9", 39));
            estructura.Add(new Arbol(42, "Admin10", 39));
            estructura.Add(new Arbol(43, "Admin11", 1));
            estructura.Add(new Arbol(44, "Admin12", 33));
            foreach (Arbol arbol1 in estructura)
            {
                lista.Add(arbol1);
            }
            lista2 = lista;
            foreach(Arbol arbol in lista)
            {
                foreach (Arbol arbol2 in lista2)
                {
                    if(arbol.Id == arbol2.Id_padre)
                    {
                        arbol.Children.Add(arbol2);
                        arbol2.Elimina = true;
                    }
                }
            }

            foreach(Arbol arbol in lista2)
            {
                if(arbol.Elimina == true)
                {
                    lista3.Add(arbol);
                }
            }

            foreach(Arbol arbol in lista3)
            {
                lista.Remove(arbol);
            }

            return lista;
        }
    }
}
