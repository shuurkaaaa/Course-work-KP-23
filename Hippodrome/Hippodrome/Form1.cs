using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hippodrome
{
    public partial class Form1 : Form
    {
        Horse h;
        List <Horse> horses = new List <Horse> ();
        List<string> names = new List<string>
         {
         "Alice", "Bob", "Charlie", "David", "Eleanor", "Frank", "Grace", "Henry", "Isabella", "Jack",
         "Kate", "Liam", "Mia", "Noah", "Olivia", "Patrick", "Quinn", "Ruby", "Samuel", "Tessa"
         };
        List<HorseResult> horseResults = new List <HorseResult> ();
        int finished;
        

        public Form1()
        {
            InitializeComponent();
        }

        Bitmap b;
        Graphics g;
        Random r = new Random();

        void Start()
        {
           
            b = new Bitmap(1200,500);
            g = Graphics.FromImage(b);
            int radius;
            double angle, speed;
            horses.Clear();
            for (int i = 0; i < 5;i++)
            {
                radius = r.Next(180, 220);
                speed = 0.1 * r.Next(5, 10)*0.1;
                angle = 0;
                h = new Horse(500, 400, 50, 50, speed, Image.FromFile("1.png"),
                    names[r.Next(0, names.Count)], angle, radius);
                horses.Add(h);
            }

            horseResults.Clear();
            comboBox1.Items.Clear();
            foreach (Horse h in horses)
            {
                h.Move(600, 250, isOvertake(h));
                h.Drow(g);
                horseResults.Add(h.GetResult());
                comboBox1.Items.Add(h.name);
            }

            dataGridView2.DataSource = horseResults;
            dataGridView2.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            g.Clear(Color.White);
            horseResults.Clear();

            finished = 0;
            foreach (Horse h in horses)
            {
                h.Move(400, 200,isOvertake(h));
                h.Drow(g);
                horseResults.Add(h.GetResult());
                if (h.isFinished) finished++;
            }
 
            pictureBox1.Image = b;
            pictureBox1.Refresh();

            horseResults = horseResults.OrderBy(p => p.leftToFinish).ToList();

            if (finished == horses.Count)
            {
                timer1.Stop();
                horseResults = horseResults.OrderBy(p => p.time).ToList();
                button1.Enabled = true;
                button2.Enabled = true;
                if (comboBox1.Text == dataGridView2.Rows[0].Cells[0].Value.ToString())
                {
                    MessageBox.Show("Перемога");
                }
            }
           
            dataGridView2.DataSource = horseResults;
            dataGridView2.Refresh();
        }

        bool isOvertake(Horse myH)
        {
            Horse found = horses.Find(p=>p.rec.IntersectsWith(myH.rec) && p!=myH);
            if (found != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Start();
        }
    }

   
}
