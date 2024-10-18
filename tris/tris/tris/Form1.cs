using System;
using System.Drawing;
using System.Threading;

namespace tris
{
    public partial class Form1 : Form
    {
        private string turno;
        private int cont;
        private int countdown;
        private Thread threadTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button pulsante = (Button)sender;
            if (pulsante.Text == "")
            {
                pulsante.Text = turno;
                timer1.Stop();
                if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "" ||
                   button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "" ||
                   button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "" ||
                   button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "" ||
                   button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "" ||
                   button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "" ||
                   button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "" ||
                   button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "")
                {
                    MessageBox.Show("Ha vinto " + turno);
                    Form1_Load(this, e);
                }
                else if (cont == 9)
                {
                    MessageBox.Show("Pareggio");
                    Form1_Load(this, e);
                }

                if (turno == "X") turno = "0";
                else turno = "X";

                labelTurno.Text = turno;
                cont++;

                if (int.TryParse(textBoxCountdown.Text, out countdown) && countdown > 0)
                {
                    threadTimer = new Thread(new ThreadStart(RunCountdown));
                    threadTimer.Start();
                }
                else
                {
                    MessageBox.Show("Inserisci un valore valido per il conto alla rovescia.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cont = 0;
            Random generatore = new Random();
            if (generatore.Next(2) == 0) turno = "X";
            else turno = "0";
            labelTurno.Text = turno;

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            textBoxCountdown.Text = ""; // Campo per inserire il conto alla rovescia
        }

        private void RunCountdown()
        {
            while (countdown > 0)
            {
                Thread.Sleep(1000);
                countdown--;
            }

            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Il tempo è scaduto!");
                if (turno == "X") turno = "0";
                else turno = "X";
                labelTurno.Text = turno;
            });
        }
    }
}