using System;

namespace CRUDSystem
{
    internal class Entidad
    {
        public Entidad()
        {
        }

        public Func<string> Directivo { get; internal set; }
        public Func<string> N { get; internal set; }
        public Func<string> Dni { get; internal set; }
        public Func<string> ApyNom { get; internal set; }
        public Func<string> Costos { get; internal set; }
        public Func<string> Cargo { get; internal set; }
    }
}