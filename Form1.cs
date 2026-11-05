using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusquedasEmpiricas
{
    /// <summary>
    /// Formulario principal. El diseño visual vive en Form1.Designer.cs
    /// (editable desde el Diseñador de Visual Studio); aquí solo está la lógica.
    /// </summary>
    public partial class Form1 : Form
    {
        private Conjunto _conjunto;   // datos y estructuras actuales

        public Form1()
        {
            InitializeComponent();
            Escribir("Bienvenido. Paso 1: elige N y pulsa 'Generar datos'.");
        }

        // ------------------------------------------------------------------
        //  Utilidades de interfaz
        // ------------------------------------------------------------------
        private void Escribir(string texto)
        {
            txtLog.AppendText(texto + Environment.NewLine);
        }

        private void AgregarFilas(IEnumerable<FilaResultado> filas)
        {
            foreach (var f in filas)
            {
                dgvResultados.Rows.Add(
                    f.Metodo,
                    f.N.ToString("N0"),
                    f.PromCompEncontrados.ToString("N2"),
                    f.PromIterEncontrados.ToString("N2"),
                    f.PromCompNoEncontrados.ToString("N2"),
                    f.PromIterNoEncontrados.ToString("N2"),
                    f.MaxComparaciones.ToString("N0"),
                    f.TiempoMs.ToString("N3"));
            }
        }

        private void ActivarControles(bool activo)
        {
            grpParametros.Enabled = activo;
            grpManual.Enabled = activo;
            UseWaitCursor = !activo;
        }

        private void GenerarConjunto()
        {
            int n = (int)nudN.Value;
            int semilla = (int)nudSemilla.Value;
            _conjunto = Conjunto.Generar(n, semilla);

            lblEstado.Text = $"Estado: {n:N0} datos únicos generados (semilla {semilla}).";
            Escribir($"[Datos] N = {n:N0}. Tabla Hash: M = {_conjunto.Tabla.Tamano:N0} cubetas, " +
                     $"factor de carga = {_conjunto.Tabla.FactorCarga:F3}, " +
                     $"cadena más larga = {_conjunto.Tabla.CadenaMasLarga()}, " +
                     $"cubetas vacías = {_conjunto.Tabla.CubetasVacias():N0}.");
        }

        private bool AsegurarDatos()
        {
            if (_conjunto == null || _conjunto.N != (int)nudN.Value || _conjunto.Semilla != (int)nudSemilla.Value)
                GenerarConjunto();
            return _conjunto != null;
        }

        // ------------------------------------------------------------------
        //  Parámetros y experimento
        // ------------------------------------------------------------------
        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            ActivarControles(false);
            await Task.Run(() => { });   // permite refrescar el cursor de espera
            GenerarConjunto();
            ActivarControles(true);
        }

        private async void btnEjecutar_Click(object sender, EventArgs e)
        {
            ActivarControles(false);
            try
            {
                int consultas = (int)nudConsultas.Value;
                int n = (int)nudN.Value, semilla = (int)nudSemilla.Value;

                var filas = await Task.Run(() =>
                {
                    var c = Conjunto.Generar(n, semilla);
                    _conjunto = c;
                    return Experimento.Ejecutar(c, consultas);
                });

                lblEstado.Text = $"Estado: {n:N0} datos únicos generados (semilla {semilla}).";
                AgregarFilas(filas);
                Escribir($"[Experimento] N = {n:N0}, {consultas:N0} búsquedas existentes + {consultas:N0} inexistentes por método.");
                Escribir($"   Hash: M = {_conjunto.Tabla.Tamano:N0}, carga = {_conjunto.Tabla.FactorCarga:F3}, " +
                         $"cadena más larga = {_conjunto.Tabla.CadenaMasLarga()}.");
                foreach (var f in filas)
                    Escribir($"   {f.Metodo,-10} comp. prom. (existe) = {f.PromCompEncontrados,10:N2} | (no existe) = {f.PromCompNoEncontrados,10:N2}");
            }
            finally
            {
                ActivarControles(true);
            }
        }

        private async void btnBarrido_Click(object sender, EventArgs e)
        {
            ActivarControles(false);
            try
            {
                int consultas = (int)nudConsultas.Value;
                int semilla = (int)nudSemilla.Value;
                int[] tamanos = { 100, 1000, 10000, 100000 };
                Escribir("[Barrido] Ejecutando N = 100, 1,000, 10,000 y 100,000 ...");

                foreach (int n in tamanos)
                {
                    var filas = await Task.Run(() =>
                    {
                        var c = Conjunto.Generar(n, semilla);
                        _conjunto = c;
                        return Experimento.Ejecutar(c, consultas);
                    });
                    AgregarFilas(filas);
                    Escribir($"   N = {n:N0} terminado.");
                }
                nudN.Value = 100000;
                lblEstado.Text = "Estado: barrido completo.";
                Escribir("[Barrido] Listo. Compara cómo crecen las comparaciones al aumentar N.");
            }
            finally
            {
                ActivarControles(true);
            }
        }

        // ------------------------------------------------------------------
        //  Búsqueda manual
        // ------------------------------------------------------------------
        private bool LeerClave(out int clave)
        {
            if (!int.TryParse(txtClave.Text.Trim(), out clave) || clave < 1)
            {
                MessageBox.Show("Escribe una clave entera positiva.", "Clave inválida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void MostrarResultado(string metodo, int clave, ResultadoBusqueda r)
        {
            string estado = r.Encontrado ? $"ENCONTRADA (posición/cubeta {r.Indice})" : "NO encontrada";
            Escribir($"[{metodo}] clave {clave}: {estado} | comparaciones = {r.Comparaciones:N0} | iteraciones = {r.Iteraciones:N0}");
        }

        private void btnSecuencial_Click(object sender, EventArgs e)
        {
            if (!LeerClave(out int clave) || !AsegurarDatos()) return;
            MostrarResultado("Secuencial", clave, BusquedaSecuencial.Buscar(_conjunto.Datos, clave));
        }

        private void btnBinaria_Click(object sender, EventArgs e)
        {
            if (!LeerClave(out int clave) || !AsegurarDatos()) return;
            MostrarResultado("Binaria", clave, BusquedaBinaria.Buscar(_conjunto.Ordenados, clave));
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            if (!LeerClave(out int clave) || !AsegurarDatos()) return;
            MostrarResultado("Hash", clave, _conjunto.Tabla.Buscar(clave));
        }

        private void btnAleatoria_Click(object sender, EventArgs e)
        {
            if (!AsegurarDatos()) return;
            var azar = new Random();
            txtClave.Text = _conjunto.Datos[azar.Next(_conjunto.N)].ToString();
        }
    }
}
