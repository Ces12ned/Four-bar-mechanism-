using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Mecanismo_de_4_Barras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

          
            label5.Text = "Bienvenido\nPor favor ingresa los valores solicitados en los recuadros ubicados en la parte inferior izquierda\nPosteriormente desliza el recuadro azul que se encuentra en la barra del lado derecho para comenzar la simulación y modificar el ángulo de rotación.";
            label6.Text = "Universidad Nacional Autónoma De México\n\n                  Facultad de Ingeniería\n\n        Simulador Mecanismo de 4 barras";
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                Graphics papel = pictureBox1.CreateGraphics();
                Pen LápizRojo = new Pen(Color.Red, 6);
                Pen LápizAzul = new Pen(Color.Blue, 6);
                Pen LápizVerde = new Pen(Color.Green, 6);
                Pen LápizBlanco = new Pen(Color.White, 6);
                papel.Clear(Color.Black);
                papel.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);

                if (double.Parse(textBox1.Text)<90&double.Parse(textBox2.Text)<120&double.Parse(textBox3.Text)<120)
                {
                    papel.DrawEllipse(LápizAzul, 0, 0, 2, 2);
                    label4.Text = "Ángulo de Rotación: " + trackBar1.Value.ToString() + "°";

                    #region EslabónA
                    double Xc = -(double.Parse(textBox1.Text) / 2);
                    const double Yc = 0;
                    double X = double.Parse(textBox2.Text) + Xc;
                    double Y = 0;

                    Articulación EslabónA = new Articulación(trackBar1.Value, Xc, Yc, X, Y);
                    double Px = (double)EslabónA.Rotaciónx(EslabónA);
                    double Py = (double)EslabónA.Rotacióny(EslabónA);


                    EslabónA._Ang = (double)trackBar1.Value;


                    papel.DrawEllipse(LápizRojo, (-2 - (float.Parse(textBox1.Text) / 2)), -2, 5, 5);
                    papel.DrawLine(LápizRojo, (float)Xc, (float)Yc, (float)Px, (float)Py);

                    #endregion


                    #region EslabónB
                    double Xc2 = (double.Parse(textBox1.Text) / 2);
                    const double Yc2 = 0;
                    double X2 = double.Parse(textBox3.Text) + Xc2;
                    double Y2 = 0;


                    Articulación EslabónB = new Articulación(trackBar1.Value, Xc2, Yc2, X2, Y2);
                    double Px2 = EslabónB.Rotaciónx(EslabónB);
                    double Py2 = EslabónB.Rotacióny(EslabónB);

                    EslabónB._Ang = trackBar1.Value;


                    papel.DrawEllipse(LápizVerde, (-2 + (float.Parse(textBox1.Text) / 2)), -2, 5, 5);
                    papel.DrawLine(LápizVerde, (float)Xc2, (float)Yc2, (float)Px2, (float)Py2);


                    #endregion


                    #region EslabónC
                    papel.DrawLine(LápizAzul, (float)Px, (float)Py, (float)Px2, (float)Py2);
                    papel.DrawEllipse(LápizAzul, (float)Px - 2, (float)Py - 2, 5, 5);
                    papel.DrawEllipse(LápizAzul, (float)Px2 - 2, (float)Py2 - 2, 5, 5);

                                        
                    #endregion

                }

                else
                {
                    MessageBox.Show("El valor ingresado para las distancias es muy grande, los valores permitidos son:\n\nDistancia entre tierras < a 90\n\nLongitud de los Eslabones < 120");
                }




            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error en el ingreso de datos, verifique su error con los mensajes siguientes...");
                MessageBox.Show("No se pueden ingresar caracteres especiales ni alfabéticos");
                MessageBox.Show("Es necesario que ingrese todos los valores solicitados...\n\nDistancia entre tierras\nLongitud del Eslabón A\nLongitud del Eslabón B");
            }
           
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
