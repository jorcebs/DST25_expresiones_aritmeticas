using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expresiones_aritméticas
{
    public partial class Form1 : Form
    {
        private Árbol tree;

        public Form1()
        {
            InitializeComponent();
            txtExpresión.Text = "3*4/2-2*5";
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            tree = new Árbol(txtExpresión.Text);
            txtResultado.Text = tree.ResolverPreOrder().ToString() + " | " + tree.ResolverPostOrden().ToString();
        }
    }
}