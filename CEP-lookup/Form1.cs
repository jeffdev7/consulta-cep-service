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

        private void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            using (var cep = new CepService.AtendeClienteClient())
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
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
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCEP.Text = "";
                    txtAddress.Text = "";
                    txtBairro.Text = "";
                    txtCity.Text = "";
                    txtUF.Text = "";
                }
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar);
        }
    }
}