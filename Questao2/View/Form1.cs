using Questao2.ConfigDB;
using Questao2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questao2
{
    public partial class Form1 : Form
    {
        private MyStuffDbContext contex;
        public Form1()
        {
            InitializeComponent();
            contex = new MyStuffDbContext();
        }

        private void RefreshGrid()
        {
            BindingSource bi = new BindingSource();


            var query = from u in contex.Usuarios

                        select new { u.Id, u.Nome, u.Email, u.Sexo, u.Idade, u.Peso, u.Altura, u.IMC };
            bi.DataSource = query.ToList();

            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != string.Empty && txtEmail.Text != string.Empty && txtSexo.Text != string.Empty && 
                txtIdade.Text != null && txtPeso.Text != null && txtAltura.Text != null && txtIMC.Text != null)
            {
                var usuario = new Usuario()
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Sexo = txtSexo.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Peso = double.Parse(txtPeso.Text),
                    Altura = double.Parse(txtAltura.Text),
                    IMC = double.Parse(txtPeso.Text) / (double.Parse(txtAltura.Text) * double.Parse(txtAltura.Text)),
                };

                contex.Usuarios.Add(usuario);

                contex.SaveChanges();

                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Você precisa inserir todos os dados");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var t = contex.Usuarios.Find((int)dataGridView1.SelectedCells[0].Value);
            contex.Usuarios.Remove(t);
            contex.SaveChanges();
            RefreshGrid();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSexo.Text = "";
            txtIdade.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            txtIMC.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                txtNome.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtEmail.Text = dataGridView1.SelectedCells[2].Value.ToString();
                txtSexo.Text = dataGridView1.SelectedCells[3].Value.ToString();
                txtIdade.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtPeso.Text = dataGridView1.SelectedCells[5].Value.ToString();
                txtAltura.Text = dataGridView1.SelectedCells[6].Value.ToString();
                txtIMC.Text = dataGridView1.SelectedCells[7].Value.ToString();

                btnEditar.Text = "Salvar";
            }
            else
            {
                var editarPessoas = contex.Usuarios.Find((int)dataGridView1.SelectedCells[0].Value);

                editarPessoas.Nome = txtNome.Text;
                editarPessoas.Email = txtEmail.Text;
                editarPessoas.Sexo = txtSexo.Text;
                editarPessoas.Idade = int.Parse(txtIdade.Text);
                editarPessoas.Peso = double.Parse(txtPeso.Text);
                editarPessoas.Altura = double.Parse(txtAltura.Text);

                contex.SaveChanges();
                RefreshGrid();

                btnEditar.Text = "Editar";
                txtNome.Text = "";
                txtEmail.Text = "";
                txtSexo.Text = "";
                txtIdade.Text = "";
                txtPeso.Text = "";
                txtAltura.Text = "";
                txtIMC.Text = "";
            }
        }
    }
}
