using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Praktikum_Week_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string connectionString = "server=;uid=;pwd=;db=premier_league;";
        public MySqlConnection sqlConnect = new MySqlConnection(connectionString);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;

        DataTable dtTeamAway = new DataTable();
        DataTable dtTeamHome = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlQuery = "SELECT t.team_name as 'Nama Tim' FROM team t;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTeamHome);
            sqlAdapter.Fill(dtTeamAway);
            comboBox1.DataSource = dtTeamHome;
            comboBox1.DisplayMember = "Nama Tim";
            comboBox1.ValueMember = "ID Tim";
            comboBox2.DataSource = dtTeamAway;
            comboBox2.DisplayMember = "Nama Tim";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posisiIndex = comboBox1.SelectedIndex;
            label6.Text = dtTeamHome.Rows[posisiIndex]["Nama Manager"].ToString();
            label8.Text = dtTeamHome.Rows[posisiIndex]["Nama Kapten"].ToString();
            label4.Text = dtTeamHome.Rows[posisiIndex]["Stadium"].ToString();
            label5.Text = dtTeamHome.Rows[posisiIndex]["Kapasitas"].ToString();
            label7.Text = dtTeamHome.Rows[posisiIndex]["Tanggal"].ToString();
            label10.Text = dtTeamHome.Rows[posisiIndex]["Skor"].ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int posisiIndex = comboBox1.SelectedIndex;
            label9.Text = dtTeamAway.Rows[posisiIndex]["Nama Manager"].ToString();
            label11.Text = dtTeamAway.Rows[posisiIndex]["Nama Kapten"].ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
