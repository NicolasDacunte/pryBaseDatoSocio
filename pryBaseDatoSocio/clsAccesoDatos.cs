using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace pryBaseDatoSocio
{
    internal class clsAccesoDatos
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;

        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\EL_CLUB.accdb";

        public string estadoConexion="";
        public string datosTabla;

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();
                estadoConexion = "Conectado";

            }
            catch (Exception EX)
            {
                estadoConexion = "Error:" + EX.Message;
            }
        }

        public void TraerDatos(DataGridView grilla)
        {
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;
            comandoBD.CommandText = "SOCIOS";

            lectorBD = comandoBD.ExecuteReader();//
            grilla.Columns.Add("Nombre", "Nombre");
            grilla.Columns.Add("Apellido", "Apellido");
            grilla.Columns.Add("Pais", "Pais");

            if (lectorBD.HasRows)
            {
                while (lectorBD.Read())
                {
                    datosTabla += "-" + lectorBD[0];
                    grilla.Rows.Add(lectorBD[1], lectorBD[2], lectorBD[3]);
                }
            }

          

        }
        public void BuscarPorID(int codigo)
        {

            comandoBD = new OleDbCommand();


            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;  //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandText = "SOCIOS"; //Que tabla traigo

            lectorBD = comandoBD.ExecuteReader(); //abre la tabla y muestra por renglon



            if (lectorBD.HasRows) //SI TIENE FILAS
            {
                bool Find = false;
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {
                    if (int.Parse(lectorBD[0].ToString()) == codigo)
                    {

                        //datosTabla += "-" + lectorBD[0]; //dato d la comlumna 0
                        MessageBox.Show("Cliente Existente" + lectorBD[0], "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Find = true;
                        break;
                    }

                }
                if (Find = false)
                {

                    MessageBox.Show("NO Existente" + lectorBD[0], "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }
    }   
}
