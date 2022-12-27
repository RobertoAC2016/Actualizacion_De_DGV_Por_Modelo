using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace busqueda_dinamica_con_checkboxs
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataTable dt2;
        DataGridView dgv;
        DataView dv;
        TextBox searchBox;
        Button DeleteRowSimple;
        public Form1()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("Edad", typeof(string));
            dt.Columns.Add("Pais", typeof(string));
            dt.Columns.Add("Profesion", typeof(string));
            dt.Columns.Add("Seleccion", typeof(bool));
            dt.Rows.Add(1, "Carlos Ivan","Cruz Mendoza","30","Mexico","Programador", false);
            dt.Rows.Add(2, "Liliana Estrada", "Gomez Farias", "27", "Mexico", "Quimica", false);
            dt.Rows.Add(3, "Gustavo Lobo", "Hernandez Hendandez", "28", "Mexico", "Programador", false);
            dt.Rows.Add(4, "Huberto Maximiliano", "Cortes Medina", "26", "Peru", "Arquitecto", false);
            dt.Rows.Add(5, "Jose Carlos", "Medina Medina", "25", "Peru", "Programador", false);
            dt.Rows.Add(6, "Juan Carlos", "Hernadez Gallegos", "33", "Venezuela", "Contador", false);
            dt.Rows.Add(7, "Jorge Alberto", "Capistran Ceja", "27", "Costa Rica", "Contador", false);
            dt.Rows.Add(8, "Aurelio Solis", "Vargas Hernandez", "45", "Mexico", "Arquitecto", false);
            dt.Rows.Add(9, "Saya", "Otonashi", "18", "Japon", "Mecatronica", false);
            dt.Rows.Add(10, "Violet", "Evergarden", "16", "Japon", "Mecatronica", false);
            dt.Rows.Add(11, "Saeko", "Bujima", "18", "Japon", "Mecatronica", false);
            dt.Rows.Add(12, "Jose Manuel", "Cantaros Rocha", "20", "Brasil", "Contador", false);
            dt.Rows.Add(13, "Jose Alberto", "Teodoro Rocha", "28", "Brasil", "Programador", false);
            dt.Rows.Add(14, "Diana Leonor", "Farias Teodora", "30", "Venezuela", "Arquitecto", false);
            dt.Rows.Add(15, "Sarabel Felicia", "Cruz Hernadez", "30", "Peru", "Programador", false);
            dv = new DataView(ReformatDT_Type(dt));
            dt2 = ReformatDT_Type(dt);
            Label AnuncioEliminacionRow = new Label();
            AnuncioEliminacionRow.Text = "Ingrese el Id del registro que desea"+ Environment.NewLine + " eliminar en el TEXBOX de abajo.";
            AnuncioEliminacionRow.AutoSize = true;
            AnuncioEliminacionRow.Location = new Point(250, 5);
            Label AnuncioBusquedaTexto = new Label();
            AnuncioBusquedaTexto.Text = "Coloque el texto en el TEXBOX de abajo"+Environment.NewLine+" que desea buscar en el DataGridView";
            AnuncioBusquedaTexto.AutoSize = true;
            AnuncioBusquedaTexto.Location = new Point(20, 3);
           
            
            TextBox DeleteRow = new TextBox();
            DeleteRow.Location = new Point(250, 38);

            searchBox = new TextBox();
            searchBox.Location = new Point(20, 35);



            Button ResetSources = new Button();
            ResetSources.Text = "Restablecer datos en DataGridView";
            ResetSources.AutoSize = true;
            ResetSources.Location = new Point(500, 8);

            Button DeleteRowsCheckeds = new Button();
            DeleteRowsCheckeds.Text = "Eliminar Registros con Casillas Marcadas";
            DeleteRowsCheckeds.AutoSize = true;
            DeleteRowsCheckeds.Location = new Point(500, 38);

            DeleteRowSimple = new Button();
            DeleteRowSimple.Text = "Eliminar Registros";
            DeleteRowSimple.AutoSize = true;
            DeleteRowSimple.Location = new Point(360, 35);

            dgv = new DataGridView();
            dgv.Location = new Point(20, 80);
            dgv.Width = 770;
            dgv.Height = 300;       
            dgv.DataSource = dt;

            this.Controls.Add(searchBox);
            this.Controls.Add(dgv);
            this.Controls.Add(DeleteRowSimple);
            this.Controls.Add(DeleteRow);
            this.Controls.Add(AnuncioEliminacionRow);
            this.Controls.Add(AnuncioBusquedaTexto);
            this.Controls.Add(DeleteRowsCheckeds);
            this.Controls.Add(ResetSources);

            DataTable ReformatDT_Type(DataTable dataTable)
            {
                var dtCloned = dataTable.Clone();

                for (int indexColumn = 0; indexColumn < dtCloned.Columns.Count; indexColumn++)
                {
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Int16"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Int32"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Int64"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Decimal"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Double"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.TimeSpan"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.DateTime"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                    if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Boolean"))
                    {
                        dtCloned.Columns[indexColumn].DataType = typeof(String);
                    }
                }
                for (int indexRow = 0; indexRow < dataTable.Rows.Count; indexRow++)
                {
                    var newRow = dtCloned.NewRow();
                    newRow.ItemArray = dataTable.Rows[indexRow].ItemArray;
                    dtCloned.Rows.Add(newRow);
                }

                return dtCloned;
            }
            ResetSources.Click += (sender, args) => 
            {
                DataTable data = dt2;
                dv = data.DefaultView;
                dgv.DataSource = dv;
            };
            DeleteRowSimple.Click += (sender, args) =>
            {
                // Supongamos que tenemos un objeto DataView llamado "miDataView"
                // que contiene los datos de una tabla de la base de datos
                dv.Sort = "id";
                // Buscamos el registro con el valor "123" en la columna "ID"
                int index = dv.Find($"{DeleteRow.Text}");

                // Si el método Find encuentra el registro, lo eliminamos
                if (index != -1)
                {
                    // Obtenemos el objeto DataRowView que representa al registro
                    DataRowView row =dv[index];

                    // Eliminamos el registro usando el método Delete
                    row.Delete();
                    dgv.DataSource = dv;
                   
                }

            };
            DeleteRowsCheckeds.Click += (sender, args) => 
            {
                var checkedRows = dv.Cast<DataRowView>()
                .Where(r => r["Seleccion"].ToString() == "True");

                // elimina los registros del DataView que cumplan la condición
                foreach (var row in checkedRows)
                {
                    row.Delete();
                }
                dgv.DataSource = dv;
            };
            searchBox.TextChanged += (sender, args) =>
            {
                var salida_datos = "";

                string[] palabras_busqueda = searchBox.Text.Split(' ');
                foreach (string palabra in palabras_busqueda)
                {
                    string consulta = palabra.ToUpper();
                  
                    if (salida_datos.Length == 0)
                    {
                        salida_datos = LikeLinqOR(palabra,dt );
                    }
                    else
                    {
                        salida_datos += LikeLinqAND(palabra, dt);
                    }

                }

                dv.RowFilter = salida_datos;
                dgv.DataSource= dv.ToTable();
                string LikeLinqOR(string parametro, DataTable data)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Clear();
                    var consulta = "";

                    for (int i = 0; i < data.Columns.Count; i++)
                    {

                        if (i < (data.Columns.Count - 1))
                        {
                            stringBuilder.Append(string.Format("[{0}] LIKE '%x_%' OR ", data.Columns[i].ColumnName));

                        }
                        else
                        {
                            stringBuilder.Append(string.Format("[{0}] LIKE '%x_%'", data.Columns[i].ColumnName));
                            stringBuilder.Replace("x_", parametro);
                        }
                    }


                    consulta = string.Format("({0})", stringBuilder.ToString()); ;

                    return consulta;
                }
                string LikeLinqAND(string parametro, DataTable data)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Clear();
                    var consulta = "";

                    for (int i = 0; i < data.Columns.Count; i++)
                    {

                        if (i < (data.Columns.Count - 1))
                        {
                            stringBuilder.Append(string.Format("[{0}] LIKE '%x_%' OR ", data.Columns[i].ColumnName));

                        }
                        else
                        {
                            stringBuilder.Append(string.Format("[{0}] LIKE '%x_%'", data.Columns[i].ColumnName));
                            stringBuilder.Replace("x_", parametro);
                        }
                    }


                    consulta = string.Format(" AND ({0})", stringBuilder.ToString()); ;

                    return consulta;
                }

            };
            dgv.CellContentClick += (sender, args) =>
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgv.CellValueChanged += (sender, args) =>
             {
                 try
                 {
                     var column = dgv.Columns[args.ColumnIndex];
                     if (column is DataGridViewCheckBoxColumn)
                     {
                         var isCheckedColumn = dgv.Columns["Seleccion"] as DataGridViewCheckBoxColumn;
                         isCheckedColumn.TrueValue = true;
                         isCheckedColumn.FalseValue = false;
                         if (bool.Parse(dgv.Rows[args.RowIndex].Cells["Seleccion"].Value.ToString()) == (bool)isCheckedColumn.TrueValue)
                         {
                             if (!(dv is null) || (dv.Count > 0))
                             {
                                 dv[args.RowIndex].Row["Seleccion"] = "True";
                             }
                             else
                             {
                                 MessageBox.Show("La vista de la tabla esta vacia");
                             }
                         }
                         else if (bool.Parse(dgv.Rows[args.RowIndex].Cells["Seleccion"].Value.ToString()) == (bool)isCheckedColumn.FalseValue)
                         {
                             if (!(dv is null) || (dv.Count > 0))
                             {
                                 dv[args.RowIndex].Row["Seleccion"] = "False";
                             }
                             else
                             {
                                 MessageBox.Show("La vista de la tabla esta vacia");
                             }
                         }
                     }
                 }
                 catch (Exception ex)
                 {

                     MessageBox.Show(ex.Message);
                 }
                   
             };
        }
    }
}