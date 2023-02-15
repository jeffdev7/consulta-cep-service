using System;
using System.Windows.Forms;

namespace CEP_lookup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCEP.Text = "000000-000";
        }

        private void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            using (var cep = new CepService.AtendeClienteClient())
            {
                try
                {
                    if(e.KeyCode == Keys.Enter)
                    {
                        var result = cep.consultaCEP(txtCEP.Text);

                        txtAddress.Text = result.end;
                        txtBairro.Text = result.bairro;
                        txtCity.Text = result.cidade;
                        txtUF.Text = result.uf;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}