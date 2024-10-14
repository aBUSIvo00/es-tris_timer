using System.Drawing;

namespace tris
{
    public partial class Form1 : Form
    {
        private string turno;
        private int cont;
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
                timer1.Stop ();
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
                timer1.Start();  
                cont++;
                timer1.Start();


            }



            //turno = "X" ? "0" : "X";
        }

        private void Form1_Load(object sender, EventArgs e) //nuova partita
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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Sono scaduti i 3 secondi");
            if (turno == "X") turno = "0";
            else turno = "X";  
            labelTurno.Text = turno;
            timer1.Start();
        }
    }
}
