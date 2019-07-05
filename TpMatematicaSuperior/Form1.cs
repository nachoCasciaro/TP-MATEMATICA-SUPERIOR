using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpMatematicaSuperior.Model.ComplexNumbers;

namespace TpMatematicaSuperior
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // -------OPERACIONES BASICAS----------

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Falta completar los campos con numeros complejos");
            }
            else
            {
                string primerNumero = textBox1.Text;
                string segundoNumero = textBox2.Text;
                if (chequearQueEsComplejo(primerNumero) && chequearQueEsComplejo(segundoNumero))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    ComplexPolar num2 = validar(segundoNumero);
                    ComplexPolar suma = num1 + num2;
                    textBox4.Text = textBox1.Text + " + " + textBox2.Text;
                    textBox3.Text = suma.ConvertToBinomicForm().GetNumber().ToString();
                    textBox5.Text = suma.GetNumber().ToString();

                }
                else
                    MessageBox.Show("No es un numero complejo ");
            }
        }

        private bool chequearQueEsComplejo(string numero)
        {
            if (verificarFormaBinomica(numero))
                return true;
            else if (verificarFormaPolar(numero))
                return true;
            else
                return false;
        }

        private bool verificarFormaBinomica(string numero)
        {
            return numero.Substring(0, 1) == "(" && numero.Contains(',') && numero.Substring(numero.Length - 1, 1) == ")";
        }

        private bool verificarFormaPolar(string numero)
        {
            return numero.Substring(0, 1) == "[" && numero.Contains(';') && numero.Substring(numero.Length - 1, 1) == "]";
        }

        private ComplexPolar validar(string numero)
        {
            if (verificarFormaBinomica(numero))
            {
                numero = numero.Replace("(", "");
                numero = numero.Replace(")", "");
                String[] partesNumeroBinomico;
                partesNumeroBinomico = numero.Split(',');

                List<double> listaTransformada = new List<double>();

                listaTransformada = transformarStringADouble(partesNumeroBinomico);

                ComplexBinomic numeroBinomico = new ComplexBinomic(listaTransformada.ElementAt(0), listaTransformada.ElementAt(1));

                return numeroBinomico.ConvertToPolarForm();
            }
            else
            {
                numero = numero.Replace("[", "");
                numero = numero.Replace("]", "");
                String[] partesNumeroPolar;
                partesNumeroPolar = numero.Split(';');

                List<double> listaTransformada = new List<double>();

                listaTransformada = transformarStringADouble(partesNumeroPolar);

                ComplexPolar numeroPolar = new ComplexPolar(listaTransformada.ElementAt(0), listaTransformada.ElementAt(1));

                return numeroPolar;


            }
        }

        private List<double> transformarStringADouble(String[] lista)
        {
            List<double> listaNueva = new List<double>();

            foreach (String numero in lista)
            {
                listaNueva.Add(Convert.ToDouble(numero, new CultureInfo("en-US")));
            }

            return listaNueva;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Falta completar los campos con numeros complejos");
            }
            else
            {
                string primerNumero = textBox1.Text;
                string segundoNumero = textBox2.Text;
                if (chequearQueEsComplejo(primerNumero) && chequearQueEsComplejo(segundoNumero))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    ComplexPolar num2 = validar(segundoNumero);
                    ComplexPolar resta = num1 - num2;
                    textBox4.Text = textBox1.Text + " - " + textBox2.Text;
                    textBox3.Text = resta.ConvertToBinomicForm().GetNumber();
                    textBox5.Text = resta.GetNumber();

                }
                else
                    MessageBox.Show("No es un numero complejo ");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Falta completar los campos con numeros complejos");
            }
            else
            {
                string primerNumero = textBox1.Text;
                string segundoNumero = textBox2.Text;
                if (chequearQueEsComplejo(primerNumero) && chequearQueEsComplejo(segundoNumero))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    ComplexPolar num2 = validar(segundoNumero);
                    ComplexPolar producto = num1 * num2;
                    textBox4.Text = textBox1.Text + " * " + textBox2.Text;
                    textBox3.Text = producto.ConvertToBinomicForm().GetNumber();
                    textBox5.Text = producto.GetNumber();

                }
                else
                    MessageBox.Show("No es un numero complejo ");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Falta completar los campos con numeros complejos");
            }
            else
            {
                string primerNumero = textBox1.Text;
                string segundoNumero = textBox2.Text;
                if (chequearQueEsComplejo(primerNumero) && chequearQueEsComplejo(segundoNumero))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    ComplexPolar num2 = validar(segundoNumero);
                    ComplexPolar division = num1 / num2;
                    textBox4.Text = textBox1.Text + " / " + textBox2.Text;
                    textBox3.Text = division.ConvertToBinomicForm().GetNumber();
                    textBox5.Text = division.GetNumber();

                }
                else
                    MessageBox.Show("No es un numero complejo ");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        // -----OPERACIONES AVANZADAS-------

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Falta completar los campos con un numero complejo o un factor");
            }
            else
            {
                string primerNumero = textBox6.Text;
                Int16 factor = new Int16();

                if (chequearQueEsComplejo(primerNumero) && Int16.TryParse(textBox7.Text, out factor))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    ComplexPolar potencia = num1.Potencia(factor);

                    textBox8.Text = potencia.ConvertToBinomicForm().GetNumber().ToString();
                    textBox9.Text = potencia.GetNumber().ToString();

                }
                else
                    MessageBox.Show("No es un numero complejo ");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Falta completar los campos con un numero complejo o un factor");
            }
            else
            {
                listView1.Items.Clear();
                
                string primerNumero = textBox6.Text;
                Int16 factor = new Int16();

                if (chequearQueEsComplejo(primerNumero) && Int16.TryParse(textBox7.Text, out factor))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    List<ComplexPolar> raicesNESIMAS = num1.Raiz(factor);

                    int i = 0;

                    foreach(ComplexPolar raiz in raicesNESIMAS)
                    {
                        ListViewItem item = new ListViewItem( "W" + i);
                        item.SubItems.Add(raiz.GetNumber());
                        listView1.Items.Add(item);
                        i++;
                    }
                }
                else
                    MessageBox.Show("No es un numero complejo o un factor correcto ");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Falta completar los campos con un numero complejo o un factor");
            }
            else
            {
                listView3.Items.Clear();

                string primerNumero = textBox6.Text;
                Int16 factor = new Int16();

                if (chequearQueEsComplejo(primerNumero) && Int16.TryParse(textBox7.Text, out factor))
                {
                    ComplexPolar num1 = validar(primerNumero);
                    List<ComplexPolar> raicesENESIMAS = num1.Raiz(factor);
                    List<ComplexPolar> raicesPrim = num1.RaicesPrimitivas(factor);

                    foreach (ComplexPolar raiz in raicesPrim)
                    {
                        int posicion = raicesENESIMAS.FindIndex(x => x.GetNumber() == raiz.GetNumber());
                        ListViewItem item = new ListViewItem("W" + posicion);
                        item.SubItems.Add(raiz.GetNumber());
                        listView3.Items.Add(item);
                        
                    }
                }
                else
                    MessageBox.Show("No es un numero complejo o un factor correcto ");
            }

        }

            private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //---------TRANSFORMACIONES--------

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Falta completar el campo con un numero complejo");
            }
            else
            {
                string primerNumero = textBox10.Text;

                if (chequearQueEsComplejo(primerNumero))
                {
                    ComplexPolar num1 = validar(primerNumero);

                    textBox11.Text = num1.ConvertToBinomicForm().GetNumber().ToString();
                    textBox12.Text = num1.GetNumber().ToString();

                }
                else
                    MessageBox.Show("No es un numero complejo ");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || textBox16.Text == "" || textBox14.Text == "" || textBox13.Text == "" || textBox17.Text == "" || textBox15.Text == "" || textBox18.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Falta completar campos");
            }
            else
            {

                if (textBox13.Text == textBox16.Text)
                {

                    Fasor fasor1 = new Fasor(Convert.ToDouble(textBox15.Text, new CultureInfo("en-US")), comboBox1.Text, Convert.ToDouble(textBox13.Text, new CultureInfo("en-US")), Convert.ToDouble(textBox14.Text, new CultureInfo("en-US") ));
                    Fasor fasor2 = new Fasor(Convert.ToDouble(textBox18.Text, new CultureInfo("en-US")), comboBox2.Text, Convert.ToDouble(textBox16.Text, new CultureInfo("en-US")), Convert.ToDouble(textBox17.Text, new CultureInfo("en-US")));

                    Fasor suma = fasor1 + fasor2;

                    textBox19.Text = suma.ObtenerFasor();
                }
                else
                    MessageBox.Show("No se puede sumar dos funciones con distinta frecuencia");
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || textBox16.Text == "" || textBox14.Text == "" || textBox13.Text == "" || textBox17.Text == "" || textBox15.Text == "" || textBox18.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Falta completar campos");
            }
            else
            {

                if (textBox13.Text == textBox16.Text )
                {

                    Fasor fasor1 = new Fasor(Convert.ToDouble(textBox15.Text, new CultureInfo("en-US")), comboBox1.Text, Convert.ToDouble(textBox13.Text, new CultureInfo("en-US")), Convert.ToDouble(textBox14.Text, new CultureInfo("en-US")));
                    Fasor fasor2 = new Fasor(Convert.ToDouble(textBox18.Text, new CultureInfo("en-US")), comboBox2.Text, Convert.ToDouble(textBox16.Text, new CultureInfo("en-US")), Convert.ToDouble(textBox17.Text, new CultureInfo("en-US")));

                    Fasor resta = fasor1 - fasor2;

                    textBox19.Text = resta.ObtenerFasor();
                }
                else
                    MessageBox.Show("No se puede restar dos funciones con distinta frecuencia");
            }
        }
    }
}
