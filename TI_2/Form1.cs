using System.Collections;

namespace TI_2
{
    public partial class Form1 : Form
    {
        string begin;
        public Form1()
        {
            InitializeComponent();
            begin = "111111111111111111111111";
            textBox1.Text = begin;
        }

        byte ConvertByte(BitArray bits)
        {
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        string fileName;
        string bytes;
        int[] beginInt;
        string result;
        string extension;

        private void button1_Click(object sender, EventArgs e)
        {
            result = "";
            begin = textBox1.Text;
            begin = changeKey(begin);
            beginInt = new int[24];
            for (int i = 0; i < 24; i++)
            {
                beginInt[i] = Convert.ToInt32(Convert.ToString(begin[i]));
            }
            begin = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                begin += Convert.ToString(beginInt[0]);

                int xor = beginInt[21] ^ beginInt[0] ^ beginInt[20] ^ beginInt[23];


                for (int q = 0; q < 23; q++)
                {
                    beginInt[q] = beginInt[q + 1];

                }
                beginInt[23] = xor;
            }
            textBox2.Text = begin;

            for (int i = 0; i < begin.Length; i++)
            {
                int a = Convert.ToInt32(Convert.ToString(begin[i]));
                int b = Convert.ToInt32(Convert.ToString(bytes[i]));
                int xor = a ^ b;
                result += Convert.ToString(xor);
            }
            textBox4.Text = result;
            int temp = fileName.IndexOf(extension);
            string pathout = fileName.Remove(temp, extension.Length);
            pathout = pathout + "Output" + extension;
            using (BinaryWriter writerbin1 = new BinaryWriter(File.Create(pathout)))
            {
                int j = 0;
                bool[] arr = new bool[8];
                for (int i = 0; i < result.Length; i++)
                {
                    bool buf1;
                    buf1 = result[i] == '1' ? true : false;
                    arr[i % 8] = (buf1);
                    j++;
                    if (j == 8)
                    {
                        BitArray bitarray = new BitArray(new bool[] { arr[7], arr[6], arr[5], arr[4], arr[3], arr[2], arr[1], arr[0] });
                        byte n = ConvertByte(bitarray);
                        j = 0;
                        writerbin1.Write(n);
                    }
                }
            }
        }

        private string changeKey(string begin) {
            bool isCorrect = true;
            if (begin.Length != 24)
            {
                MessageBox.Show("Ключ будет равен всем единицам", "Длина ключа неверная");
                begin = "111111111111111111111111";
                textBox1.Text = begin;
            }
            for (int i = 0; i < 24; i++) { 
                if ((begin[i] != '0') && (begin[i] != '1')){ 
                isCorrect = false;
                }
            }
            if (!isCorrect) {
                MessageBox.Show("Ключ будет равен всем единицам", "Неверные символы");
                begin = "111111111111111111111111";
                textBox1.Text = begin;
            }
            return begin;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            bytes = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            fileName = openFileDialog1.FileName;
            using (BinaryReader reader2 = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader2.BaseStream.Position != reader2.BaseStream.Length)
                {
                    // bytes = bytes + reader.ReadByte();
                    byte a = reader2.ReadByte();
                    BitArray bit2 = new BitArray(new byte[] { a });
                    for (int i = bit2.Length - 1; i >= 0; i--)
                    {
                        bytes += bit2[i] == true ? "1" : "0";
                    }
                }
            }
            textBox3.Text = bytes;
            extension = Path.GetExtension(fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = "";
            begin = textBox1.Text;
            begin = changeKey(begin);
            beginInt = new int[24];
            for (int i = 0; i < 24; i++)
            {
                beginInt[i] = Convert.ToInt32(Convert.ToString(begin[i]));
            }
            begin = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                begin += Convert.ToString(beginInt[0]);

                int xor = beginInt[21] ^ beginInt[0] ^ beginInt[20] ^ beginInt[23];


                for (int q = 0; q < 23; q++)
                {
                    beginInt[q] = beginInt[q + 1];

                }
                beginInt[23] = xor;
            }
            textBox2.Text = begin;

            for (int i = 0; i < begin.Length; i++)
            {
                int a = Convert.ToInt32(Convert.ToString(begin[i]));
                int b = Convert.ToInt32(Convert.ToString(bytes[i]));
                int xor = a ^ b;
                result += Convert.ToString(xor);
            }
            textBox4.Text = result;
            int temp = fileName.IndexOf(extension);
            string pathout = fileName.Remove(temp, extension.Length);
            pathout = pathout + "Out" + extension;
            using (BinaryWriter writerbin1 = new BinaryWriter(File.Create(pathout)))
            {
                int j = 0;
                bool[] arr = new bool[8];
                for (int i = 0; i < result.Length; i++)
                {
                    bool buf1;
                    buf1 = result[i] == '1' ? true : false;
                    arr[i % 8] = (buf1);
                    j++;
                    if (j == 8)
                    {
                        BitArray bitarray = new BitArray(new bool[] { arr[7], arr[6], arr[5], arr[4], arr[3], arr[2], arr[1], arr[0] });
                        byte n = ConvertByte(bitarray);
                        j = 0;
                        writerbin1.Write(n);
                    }
                }
            }
        }
    }
}