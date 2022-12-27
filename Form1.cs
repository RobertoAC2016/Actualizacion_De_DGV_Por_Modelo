using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        private List<Registro> jobs;
        public Form1()
        {
            InitializeComponent();

            dgv = new DataGridView();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Edad" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pais" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Profesion" });
            dgv.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Seleccion" });

            //dt = new DataTable();
            //dt.Columns.Add("id", typeof(int));
            //dt.Columns.Add("Nombre", typeof(string));
            //dt.Columns.Add("Apellido", typeof(string));
            //dt.Columns.Add("Edad", typeof(string));
            //dt.Columns.Add("Pais", typeof(string));
            //dt.Columns.Add("Profesion", typeof(string));
            //dt.Columns.Add("Seleccion", typeof(bool));

            //dv = new DataView(ReformatDT_Type(dt));
            //dt2 = ReformatDT_Type(dt);
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

            //dgv = new DataGridView();
            dgv.Location = new Point(20, 80);
            dgv.Width = 770;
            dgv.Height = 300;

            load_data();
            dgv_update();

            this.Controls.Add(searchBox);
            this.Controls.Add(dgv);
            this.Controls.Add(DeleteRowSimple);
            this.Controls.Add(DeleteRow);
            this.Controls.Add(AnuncioEliminacionRow);
            this.Controls.Add(AnuncioBusquedaTexto);
            this.Controls.Add(DeleteRowsCheckeds);
            this.Controls.Add(ResetSources);
            #region COMENTADO
            //DataTable ReformatDT_Type(DataTable dataTable)
            //{
            //    var dtCloned = dataTable.Clone();

            //    for (int indexColumn = 0; indexColumn < dtCloned.Columns.Count; indexColumn++)
            //    {
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Int16"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Int32"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Int64"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Decimal"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Double"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.TimeSpan"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.DateTime"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //        if (dtCloned.Columns[indexColumn].DataType == Type.GetType("System.Boolean"))
            //        {
            //            dtCloned.Columns[indexColumn].DataType = typeof(String);
            //        }
            //    }
            //    for (int indexRow = 0; indexRow < dataTable.Rows.Count; indexRow++)
            //    {
            //        var newRow = dtCloned.NewRow();
            //        newRow.ItemArray = dataTable.Rows[indexRow].ItemArray;
            //        dtCloned.Rows.Add(newRow);
            //    }

            //    return dtCloned;
            //}
            //ResetSources.Click += (sender, args) => 
            //{
            //    DataTable data = dt2;
            //    dv = data.DefaultView;
            //    dgv.DataSource = dv;
            //};
            //DeleteRowSimple.Click += (sender, args) =>
            //{
            //    // Supongamos que tenemos un objeto DataView llamado "miDataView"
            //    // que contiene los datos de una tabla de la base de datos
            //    dv.Sort = "id";
            //    // Buscamos el registro con el valor "123" en la columna "ID"
            //    int index = dv.Find($"{DeleteRow.Text}");

            //    // Si el método Find encuentra el registro, lo eliminamos
            //    if (index != -1)
            //    {
            //        // Obtenemos el objeto DataRowView que representa al registro
            //        DataRowView row =dv[index];

            //        // Eliminamos el registro usando el método Delete
            //        row.Delete();
            //        dgv.DataSource = dv;

            //    }

            //};
            //searchBox.TextChanged += (sender, args) =>
            //{
            //    var salida_datos = "";

            //    string[] palabras_busqueda = searchBox.Text.Split(' ');
            //    foreach (string palabra in palabras_busqueda)
            //    {
            //        string consulta = palabra.ToUpper();

            //        if (salida_datos.Length == 0)
            //        {
            //            salida_datos = LikeLinqOR(palabra,dt );
            //        }
            //        else
            //        {
            //            salida_datos += LikeLinqAND(palabra, dt);
            //        }

            //    }

            //    dv.RowFilter = salida_datos;
            //    dgv.DataSource= dv.ToTable();
            //    string LikeLinqOR(string parametro, DataTable data)
            //    {
            //        var stringBuilder = new StringBuilder();
            //        stringBuilder.Clear();
            //        var consulta = "";

            //        for (int i = 0; i < data.Columns.Count; i++)
            //        {

            //            if (i < (data.Columns.Count - 1))
            //            {
            //                stringBuilder.Append(string.Format("[{0}] LIKE '%x_%' OR ", data.Columns[i].ColumnName));

            //            }
            //            else
            //            {
            //                stringBuilder.Append(string.Format("[{0}] LIKE '%x_%'", data.Columns[i].ColumnName));
            //                stringBuilder.Replace("x_", parametro);
            //            }
            //        }


            //        consulta = string.Format("({0})", stringBuilder.ToString()); ;

            //        return consulta;
            //    }
            //    string LikeLinqAND(string parametro, DataTable data)
            //    {
            //        var stringBuilder = new StringBuilder();
            //        stringBuilder.Clear();
            //        var consulta = "";

            //        for (int i = 0; i < data.Columns.Count; i++)
            //        {

            //            if (i < (data.Columns.Count - 1))
            //            {
            //                stringBuilder.Append(string.Format("[{0}] LIKE '%x_%' OR ", data.Columns[i].ColumnName));

            //            }
            //            else
            //            {
            //                stringBuilder.Append(string.Format("[{0}] LIKE '%x_%'", data.Columns[i].ColumnName));
            //                stringBuilder.Replace("x_", parametro);
            //            }
            //        }


            //        consulta = string.Format(" AND ({0})", stringBuilder.ToString()); ;

            //        return consulta;
            //    }

            //};
            //dgv.CellContentClick += (sender, args) =>
            //{
            //    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //};
            //dgv.CellValueChanged += (sender, args) =>
            // {
            //     try
            //     {
            //         var column = dgv.Columns[args.ColumnIndex];
            //         if (column is DataGridViewCheckBoxColumn)
            //         {
            //             var isCheckedColumn = dgv.Columns["Seleccion"] as DataGridViewCheckBoxColumn;
            //             isCheckedColumn.TrueValue = true;
            //             isCheckedColumn.FalseValue = false;
            //             if (bool.Parse(dgv.Rows[args.RowIndex].Cells["Seleccion"].Value.ToString()) == (bool)isCheckedColumn.TrueValue)
            //             {
            //                 if (!(dv is null) || (dv.Count > 0))
            //                 {
            //                     dv[args.RowIndex].Row["Seleccion"] = "True";
            //                 }
            //                 else
            //                 {
            //                     MessageBox.Show("La vista de la tabla esta vacia");
            //                 }
            //             }
            //             else if (bool.Parse(dgv.Rows[args.RowIndex].Cells["Seleccion"].Value.ToString()) == (bool)isCheckedColumn.FalseValue)
            //             {
            //                 if (!(dv is null) || (dv.Count > 0))
            //                 {
            //                     dv[args.RowIndex].Row["Seleccion"] = "False";
            //                 }
            //                 else
            //                 {
            //                     MessageBox.Show("La vista de la tabla esta vacia");
            //                 }
            //             }
            //         }
            //     }
            //     catch (Exception ex)
            //     {

            //         MessageBox.Show(ex.Message);
            //     }

            // };
            #endregion
            dgv.CellContentClick += (sender, args) => {
                if (dgv.Columns[args.ColumnIndex].Name.Equals("Seleccion") && dgv.CurrentCell is DataGridViewCheckBoxCell)
                {
                    Boolean isChecked = false;
                    if (dgv.Rows[args.RowIndex].Cells[args.ColumnIndex].Value == null)
                        isChecked = false;
                    else
                        isChecked = (Boolean)dgv.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
                    isChecked = !isChecked;
                    int id = (int)dgv.Rows[args.RowIndex].Cells["Id"].Value;
                    //Aqui recuperamos el elemento del modelo
                    var ele = jobs.Where(x => x.id == id).FirstOrDefault();
                    //Si encontramos el elemento en nuestro modelo, procedemos a aqctualizarlo
                    if (ele != null) ele.seleccion = isChecked;
                    dgv.Rows[args.RowIndex].Cells["Seleccion"].Value = isChecked;
                }
            };
            DeleteRowsCheckeds.Click += (sender, args) =>
            {
                jobs = jobs.Where(x => x.seleccion != true).ToList();
                dgv_update();
            };
        }

        private void dgv_update()
        {
            dgv.DataSource = null;
            dgv.Rows.Clear();
            foreach (var item in jobs)
            {
                //generamos un row o fila y le pasamos loa datos por columna
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(dgv);
                dr.Cells[0].Value = item.id;
                dr.Cells[1].Value = item.nombre;
                dr.Cells[2].Value = item.apellido;
                dr.Cells[3].Value = item.edad;
                dr.Cells[4].Value = item.pais;
                dr.Cells[5].Value = item.profesion;
                dr.Cells[6].Value = item.seleccion;
                dgv.Rows.Add(dr);
            }
        }

        private void load_data()
        {
            jobs = new List<Registro>
            {
                new Registro
                {
                    id          = 1,
                    nombre      = "Carlos Ivan",
                    apellido    = "Cruz Mendoza",
                    edad        = "30",
                    pais        = "Mexico",
                    profesion   = "Programador",
                    seleccion   = false
                }, new Registro
                {
                    id          = 2,
                    nombre      =        "Liliana Estrada",
                    apellido    =      "Gomez Farias",
                    edad        =          "27",
                    pais        =          "Mexico",
                    profesion   =     "Quimica",
                    seleccion   =     false
                }, new Registro
                {
                    id          = 3,
                    nombre      = "Gustavo Lobo",
                    apellido    = "Hernandez Hendandez",
                    edad        = "28",
                    pais        = "Mexico",
                    profesion   = "Programador",
                    seleccion   = false
                }, new Registro
                {
                    id          = 4,
                    nombre      =            "Huberto Maximiliano",
                    apellido    =          "Cortes Medina",
                    edad        =              "26",
                    pais        =              "Peru",
                    profesion   =         "Arquitecto",
                    seleccion   =         false
                }, new Registro
                {
                    id          = 5,
                    nombre      =                "Jose Carlos",
                    apellido    =              "Medina Medina",
                    edad        =                  "25",
                    pais        =                  "Peru",
                    profesion   =             "Programador",
                    seleccion   =             false
                }, new Registro
                {
                    id          = 6,
                    nombre      =                    "Juan Carlos",
                    apellido    =                  "Hernadez Gallegos",
                    edad        =                      "33",
                    pais        =                      "Venezuela",
                    profesion   =                 "Contador",
                    seleccion   =                 false
                }, new Registro
                {
                    id          = 7,
                    nombre      =    "Jorge Alberto",
                    apellido    =  "Capistran Ceja",
                    edad        =      "27",
                    pais        =      "Costa Rica",
                    profesion   = "Contador",
                    seleccion   = false
                }, new Registro
                {
                    id          = 8,
                    nombre      = "Aurelio Solis",
                    apellido    = "Vargas Hernandez",
                    edad        = "45",
                    pais        = "Mexico",
                    profesion   = "Arquitecto",
                    seleccion   = false
                }, new Registro
                {
                    id          = 9,
                    nombre      = "Saya",
                    apellido    = "Otonashi",
                    edad        = "18",
                    pais        = "Japon",
                    profesion   = "Mecatronica",
                    seleccion   = false
                }, new Registro
                {
                    id          = 10,
                    nombre      =    "Violet",
                    apellido    =  "Evergarden",
                    edad        =      "16",
                    pais        =      "Japon",
                    profesion   = "Mecatronica",
                    seleccion   = false
                }, new Registro
                {
                    id          = 11,
                    nombre      =    "Saeko",
                    apellido    =  "Bujima",
                    edad        =      "18",
                    pais        =      "Japon",
                    profesion   = "Mecatronica",
                    seleccion   = false
                }, new Registro
                {
                    id          = 12,
                    nombre      =    "Jose Manuel",
                    apellido    =  "Cantaros Rocha",
                    edad        =      "20",
                    pais        =      "Brasil",
                    profesion   = "Contador",
                    seleccion   = false
                }, new Registro
                {
                    id          = 13,
                    nombre      = "Jose Alberto",
                    apellido    = "Teodoro Rocha",
                    edad        = "28",
                    pais        = "Brasil",
                    profesion   = "Programador",
                    seleccion   = false
                }, new Registro
                {
                    id          = 14,
                    nombre      = "Diana Leonor",
                    apellido    = "Farias Teodora",
                    edad        = "30",
                    pais        = "Venezuela",
                    profesion   = "Arquitecto",
                    seleccion   = false
                }, new Registro
                {
                    id          = 15,
                    nombre      = "Sarabel Felicia",
                    apellido    = "Cruz Hernadez",
                    edad        = "30",
                    pais        = "Peru",
                    profesion   = "Programador",
                    seleccion =   false
                }
            };
        }
    }
    public class Registro : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int      _id {get;set;}
        public String   _nombre {get;set;}
        public String   _apellido {get;set;}
        public String   _edad {get;set;}
        public String   _pais {get;set;}
        public String   _profesion {get;set;}
        public Boolean  _seleccion { get; set; }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }
        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged("nombre");
            }
        }
        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
                OnPropertyChanged("apellido");
            }
        }
        public String edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
                OnPropertyChanged("edad");
            }
        }
        public String pais
        {
            get
            {
                return _pais;
            }
            set
            {
                _pais = value;
                OnPropertyChanged("pais");
            }
        }
        public String profesion
        {
            get
            {
                return _profesion;
            }
            set
            {
                _profesion = value;
                OnPropertyChanged("profesion");
            }
        }
        public Boolean seleccion
        {
            get
            {
                return _seleccion;
            }
            set
            {
                _seleccion = value;
                OnPropertyChanged("seleccion");
            }
        }
        private void OnPropertyChanged(String propiedad)
        {
            Console.WriteLine($"Cambio {propiedad}");
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
                Console.WriteLine($"propiedad = {propiedad}");
            }
        }
    }
}