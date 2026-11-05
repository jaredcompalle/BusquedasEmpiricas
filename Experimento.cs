using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BusquedasEmpiricas
{
    /// <summary>
    /// Generador congruencial lineal de 64 bits. Se usa en lugar de System.Random
    /// para que el experimento sea 100% reproducible con la misma semilla.
    /// </summary>
    public sealed class Lcg
    {
        private ulong _estado;

        public Lcg(ulong semilla)
        {
            _estado = semilla;
        }

        /// <summary>Entero pseudoaleatorio en [0, maximoExclusivo).</summary>
        public int Siguiente(int maximoExclusivo)
        {
            unchecked
            {
                _estado = _estado * 6364136223846793005UL + 1442695040888963407UL;
            }
            return (int)((_estado >> 33) % (ulong)maximoExclusivo);
        }
    }

    /// <summary>
    /// Conjunto de N datos únicos aleatorios, con sus tres estructuras de búsqueda.
    /// </summary>
    public class Conjunto
    {
        public int N { get; }
        public int Semilla { get; }
        public int[] Datos { get; }          // sin ordenar (búsqueda secuencial)
        public int[] Ordenados { get; }      // ordenado (búsqueda binaria)
        public TablaHash Tabla { get; }      // tabla hash

        private Conjunto(int n, int semilla, int[] datos, int[] ordenados, TablaHash tabla)
        {
            N = n; Semilla = semilla; Datos = datos; Ordenados = ordenados; Tabla = tabla;
        }

        /// <summary>Genera N claves únicas en el rango [1, 10N].</summary>
        public static Conjunto Generar(int n, int semilla)
        {
            var rng = new Lcg((ulong)semilla);
            var vistos = new HashSet<int>();
            var datos = new int[n];
            int cuenta = 0;

            while (cuenta < n)
            {
                int v = 1 + rng.Siguiente(10 * n);
                if (vistos.Add(v))
                    datos[cuenta++] = v;
            }

            var ordenados = (int[])datos.Clone();
            Array.Sort(ordenados);

            var tabla = new TablaHash(n);
            foreach (int v in datos)
                tabla.Insertar(v);

            return new Conjunto(n, semilla, datos, ordenados, tabla);
        }
    }

    /// <summary>
    /// Fila de resultados de un método de búsqueda.
    /// </summary>
    public class FilaResultado
    {
        public string Metodo { get; set; }
        public int N { get; set; }
        public double PromCompEncontrados { get; set; }
        public double PromIterEncontrados { get; set; }
        public double PromCompNoEncontrados { get; set; }
        public double PromIterNoEncontrados { get; set; }
        public long MaxComparaciones { get; set; }
        public double TiempoMs { get; set; }
    }

    /// <summary>
    /// Ejecuta el experimento: busca T claves existentes y T claves inexistentes
    /// con cada técnica y promedia comparaciones e iteraciones.
    /// </summary>
    public static class Experimento
    {
        public static List<FilaResultado> Ejecutar(Conjunto c, int consultas)
        {
            // Generador independiente para las claves de consulta.
            var rng = new Lcg((ulong)c.Semilla + 1000003UL);
            var existentes = new int[consultas];
            var inexistentes = new int[consultas];
            var conjunto = new HashSet<int>(c.Datos);

            for (int i = 0; i < consultas; i++)
                existentes[i] = c.Datos[rng.Siguiente(c.N)];

            int k = 0;
            while (k < consultas)
            {
                int v = 1 + rng.Siguiente(10 * c.N);
                if (!conjunto.Contains(v))
                    inexistentes[k++] = v;
            }

            var filas = new List<FilaResultado>
            {
                Medir("Secuencial", c.N, existentes, inexistentes, clave => BusquedaSecuencial.Buscar(c.Datos, clave)),
                Medir("Binaria",    c.N, existentes, inexistentes, clave => BusquedaBinaria.Buscar(c.Ordenados, clave)),
                Medir("Hash",       c.N, existentes, inexistentes, clave => c.Tabla.Buscar(clave))
            };
            return filas;
        }

        private static FilaResultado Medir(string metodo, int n, int[] existentes, int[] inexistentes,
                                           Func<int, ResultadoBusqueda> buscar)
        {
            long compE = 0, iterE = 0, compN = 0, iterN = 0, maxComp = 0;
            var sw = Stopwatch.StartNew();

            foreach (int clave in existentes)
            {
                var r = buscar(clave);
                compE += r.Comparaciones;
                iterE += r.Iteraciones;
                if (r.Comparaciones > maxComp) maxComp = r.Comparaciones;
            }
            foreach (int clave in inexistentes)
            {
                var r = buscar(clave);
                compN += r.Comparaciones;
                iterN += r.Iteraciones;
                if (r.Comparaciones > maxComp) maxComp = r.Comparaciones;
            }

            sw.Stop();
            int t = existentes.Length;
            return new FilaResultado
            {
                Metodo = metodo,
                N = n,
                PromCompEncontrados = (double)compE / t,
                PromIterEncontrados = (double)iterE / t,
                PromCompNoEncontrados = (double)compN / inexistentes.Length,
                PromIterNoEncontrados = (double)iterN / inexistentes.Length,
                MaxComparaciones = maxComp,
                TiempoMs = sw.Elapsed.TotalMilliseconds
            };
        }
    }
}
