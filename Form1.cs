using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace LSP
{
    public partial class Form1 : Form
    {
        String s;
        public Form1()
        {
            InitializeComponent();
            s = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            cargar();


        }

        private void cbxSaludo_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = cbxSaludo.SelectedItem.ToString();

        }
        private IEnumerable<Type> types()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(Persona).IsAssignableFrom(p))
                    .Where(a => !a.FullName.Equals("LSP.Persona"));
        }

        public void cargar()
        {

            var types = this.types();
            foreach (var type in types)
            {
                Persona p = this.getIntance(type);
                if (p.idioma().Equals(s))
                {
                    lblResultado.Text = txtNombre.Text +" "+txtApellidos.Text +"\n"
                        +"Saludo: "+ p.saludar();
                }


            }
        }

            private Persona getIntance(Type type)
        {
            return (Persona)Activator.CreateInstance(type);
        }
        }
    }

