using System;
using System.Collections.Generic;

namespace BusquedasEmpiricas
{
    /// <summary>
    /// Búsqueda secuencial (lineal) sobre un arreglo sin ordenar.
    /// Complejidad: O(n).
    /// </summary>
    public static class BusquedaSecuencial
    {
        public static ResultadoBusqueda Buscar(int[] datos, int clave)
        {
            long comparaciones = 0, iteraciones = 0;
            for (int i = 0; i < datos.Length; i++)
            {
                iteraciones++;
                comparaciones++;               // datos[i] == clave
                if (datos[i] == clave)
                    return new ResultadoBusqueda(i, comparaciones, iteraciones);
            }
            return new ResultadoBusqueda(-1, comparaciones, iteraciones);
        }
    }

    /// <summary>
    /// Búsqueda binaria sobre un arreglo ORDENADO de menor a mayor.
    /// Complejidad: O(log n).
    /// Cada iteración cuenta 1 comparación de igualdad y, si no es igual,
    /// otra comparación de orden (menor que).
    /// </summary>
    public static class BusquedaBinaria
    {
        public static ResultadoBusqueda Buscar(int[] ordenado, int clave)
        {
            long comparaciones = 0, iteraciones = 0;
            int inicio = 0, fin = ordenado.Length - 1;

            while (inicio <= fin)
            {
                iteraciones++;
                int medio = inicio + (fin - inicio) / 2;

                comparaciones++;               // igualdad
                if (ordenado[medio] == clave)
                    return new ResultadoBusqueda(medio, comparaciones, iteraciones);

                comparaciones++;               // orden
                if (ordenado[medio] < clave)
                    inicio = medio + 1;
                else
                    fin = medio - 1;
            }
            return new ResultadoBusqueda(-1, comparaciones, iteraciones);
        }
    }

    /// <summary>
    /// Tabla Hash con encadenamiento separado (listas por cubeta).
    /// Función de dispersión: método de la división, h(k) = k mod M,
    /// con M primo y factor de carga objetivo de 0.75.
    /// </summary>
    public class TablaHash
    {
        private readonly List<int>[] _cubetas;

        /// <summary>Número de cubetas (M).</summary>
        public int Tamano { get; }

        /// <summary>Cantidad de claves almacenadas.</summary>
        public int Cantidad { get; private set; }

        /// <summary>Factor de carga = Cantidad / Tamano.</summary>
        public double FactorCarga => (double)Cantidad / Tamano;

        public TablaHash(int elementosEsperados, double factorCargaObjetivo = 0.75)
        {
            Tamano = SiguientePrimo((int)Math.Ceiling(elementosEsperados / factorCargaObjetivo));
            _cubetas = new List<int>[Tamano];
        }

        /// <summary>Función de dispersión (método de la división).</summary>
        public int Dispersion(int clave)
        {
            return (int)((uint)clave % (uint)Tamano);
        }

        public void Insertar(int clave)
        {
            int h = Dispersion(clave);
            if (_cubetas[h] == null)
                _cubetas[h] = new List<int>();
            _cubetas[h].Add(clave);
            Cantidad++;
        }

        public ResultadoBusqueda Buscar(int clave)
        {
            long comparaciones = 0, iteraciones = 0;
            int h = Dispersion(clave);
            List<int> cubeta = _cubetas[h];

            if (cubeta != null)
            {
                for (int i = 0; i < cubeta.Count; i++)
                {
                    iteraciones++;
                    comparaciones++;
                    if (cubeta[i] == clave)
                        return new ResultadoBusqueda(h, comparaciones, iteraciones);
                }
            }
            return new ResultadoBusqueda(-1, comparaciones, iteraciones);
        }

        /// <summary>Longitud de la cadena más larga.</summary>
        public int CadenaMasLarga()
        {
            int max = 0;
            foreach (var c in _cubetas)
                if (c != null && c.Count > max) max = c.Count;
            return max;
        }

        /// <summary>Cubetas sin ningún elemento.</summary>
        public int CubetasVacias()
        {
            int vacias = 0;
            foreach (var c in _cubetas)
                if (c == null || c.Count == 0) vacias++;
            return vacias;
        }

        private static int SiguientePrimo(int n)
        {
            if (n <= 2) return 2;
            if (n % 2 == 0) n++;
            while (!EsPrimo(n)) n += 2;
            return n;
        }

        private static bool EsPrimo(int n)
        {
            if (n < 2) return false;
            if (n % 2 == 0) return n == 2;
            for (int i = 3; (long)i * i <= n; i += 2)
                if (n % i == 0) return false;
            return true;
        }
    }
}
