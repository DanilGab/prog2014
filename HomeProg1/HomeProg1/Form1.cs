using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HomeProg1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ld = new PeopleData
            {
                name = textBox1.Text,
                famel = textBox3.Text,
                group = textBox2.Text,
                lang1 = checkBox1.Checked,
                lang2 = checkBox2.Checked,
                over1 = textBox5.Text,
                instrum = textBox4.Text,
                music = checkBox3.Checked,
                sport = checkBox4.Checked,
                over2 = textBox6.Text,
            };
            listBox1.Items.Add(ld);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "анкета|*.anketaml" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileName = sfd.FileName;
                AnketData ld = new AnketData();
                ld.Students = new List<PeopleData>();
                foreach (PeopleData sd in listBox1.Items)
                {
                    ld.Students.Add(sd);
                }

                XmlSerializer xs = new XmlSerializer(typeof(AnketData));
                var fileStream = File.Create(fileName);
                xs.Serialize(fileStream, ld);
                fileStream.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "анкета|*.anketaml" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var xs = new XmlSerializer(typeof(AnketData));
                var file = File.Open(ofd.FileName, FileMode.Open);
                var pd = (AnketData)xs.Deserialize(file);
                file.Close();

                listBox1.Items.Clear();
                foreach (var PeopleData in pd.Students)
                {
                    listBox1.Items.Add(PeopleData);
                }
            }
        }


        public class AnketData
        {
            public List<PeopleData> Students { get; set; }
        }

        public class PeopleData
        {
            public string name { get; set; }
            public string famel { get; set; }
            public string @group { get; set; }
            public bool lang1 { get; set; }
            public bool lang2 { get; set; }
            public string over1 { get; set; }
            public string instrum { get; set; }
            public bool music { get; set; }
            public bool sport { get; set; }
            public string over2 { get; set; }

            public override string ToString()
            {
                var a = name + " " + famel + " Группа " + group +
                        " Знает язык/языки: ";
                if (lang1) a += " Английский";
                if (lang2) a += " Немецкий";
                a += " " + over1 + " Владение муз.инст. " + instrum + " Увлечения ";
                if (music) a += " Музыкой ";
                if (sport) a += " Спортом ";
                a += over2;
                return a;
            }
        }
    }
}
