namespace BusquedasEmpiricas
{
    /// <summary>
    /// Resultado de una búsqueda individual.
    /// </summary>
    public readonly struct ResultadoBusqueda
    {
        /// <summary>Posición (o cubeta) donde se encontró la clave; -1 si no existe.</summary>
        public int Indice { get; }

        /// <summary>Número de comparaciones de claves realizadas.</summary>
        public long Comparaciones { get; }

        /// <summary>Número de iteraciones del ciclo principal.</summary>
        public long Iteraciones { get; }

        /// <summary>Indica si la clave fue encontrada.</summary>
        public bool Encontrado => Indice >= 0;

        public ResultadoBusqueda(int indice, long comparaciones, long iteraciones)
        {
            Indice = indice;
            Comparaciones = comparaciones;
            Iteraciones = iteraciones;
        }
    }
}
