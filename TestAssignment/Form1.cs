using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAssignment
{
    public partial class Form1 : Form
    {
        private MyDB myDB = new MyDB();

        private SqlDataAdapter cheklistAdapter = null;
        
        private SqlDataAdapter positionAdapter = null;

        private DataTable cheklistTable = null;

        private DataTable positionTable = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myDB.OpenConnection();

            cheklistAdapter = new SqlDataAdapter("SELECT * FROM cheklist", myDB.GetConnection());

            positionAdapter = new SqlDataAdapter("SELECT * FROM positions", myDB.GetConnection());

            cheklistTable = new DataTable();

            positionTable = new DataTable();

            cheklistAdapter.Fill(cheklistTable);

            dataGridView1.DataSource = cheklistTable;

            positionAdapter.Fill(positionTable);

            dataGridView2.DataSource = positionTable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not in our
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                var vals = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();

                int i = Convert.ToInt32(vals);

                string request = $"SELECT DISTINCT positions.pos_id, positions.product, positions.packing_date, positions.chek_id FROM cheklist , positions WHERE positions.chek_id = {i}";

                positionAdapter = new SqlDataAdapter(request, myDB.GetConnection());

                positionTable = new DataTable();

                positionAdapter.Fill(positionTable);

                dataGridView2.DataSource = positionTable;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            cheklistTable.Clear();

            cheklistAdapter.Fill(cheklistTable);

            dataGridView1.DataSource = cheklistTable;
            
            positionTable.Clear();

            positionAdapter = new SqlDataAdapter("SELECT * FROM positions", myDB.GetConnection());

            positionAdapter.Fill(positionTable);

            dataGridView2.DataSource = positionTable;
        }

    }
}
