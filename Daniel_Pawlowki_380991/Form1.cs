using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Daniel_Pawlowki_380991
{
    public partial class Form1 : Form
    {
        private const string filtr = "Format kompresji wysoko stratnej|*.fks|JPEG|*.jpg|BMP|*.bmp|PNG|*.png|TIFF|*.tif|Wszystkie pliki|*.*";
        Bitmap bmp = null;
        public Form1()
        {
            InitializeComponent();
        }

        
        

        /*----WIDOK----*/

        //STANDARD
        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = bmp.Size;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Refresh();
        }

        //DOPASUJ
        private void dopasujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = panel1.ClientSize;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 1:2
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width / 2, bmp.Height / 2);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 1:4
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width / 4, bmp.Height / 4);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 1:8
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width / 8, bmp.Height / 8);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 1:16
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width / 16, bmp.Height / 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        /*--------*/
        // 2x
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width * 2, bmp.Height * 2);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 4x
        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width * 4, bmp.Height * 4);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 8x
        private void xToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width * 8, bmp.Height * 8);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        // 16x
        private void xToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(bmp.Width * 16, bmp.Height * 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }

        /*JASNOŚĆ*/

        //ŚCIEMNIJ
        private void ściemnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = y * 100 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(c.R / 2, c.G / 2, c.B / 2));
                }
            }

            pictureBox1.Refresh();
            progressBar1.Visible = false;
        }

        private void rozjaśnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = y * 100 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(255 - (255 - c.R) / 2, 255 - (255 - c.G) / 2, 255 - (255 - c.B) / 2));
                }
            }

            pictureBox1.Refresh();
            progressBar1.Visible = false;
        }

        /*Ustawienia*/

        /*Personalizuj*/
        //JASNY MOTYW
        private void jasnyMotywToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.White;
            panel1.BackColor = Color.WhiteSmoke;
        }

        //CZARNY MOTYW
        private void czarnyMotywToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.DarkGray;
            panel1.BackColor = Color.DimGray;
        }

       

        void zapiszNasząMetodą(string fn)
        {
            {
                if (bmp == null)
                    return;

                int bmp_width = bmp.Width, bmp_height = bmp.Height;

                int[,,] bmp_tbl = new int[bmp_width, bmp_height, 3];

                Color c;
                int err;
                progressBar1.Visible = true;
                for (int y = 0; y < bmp_height; y++)
                {
                    progressBar1.Value = y * 15 / bmp_height;

                    for (int x = 0; x < bmp_width; x++)
                    {
                        c = bmp.GetPixel(x, y);
                        bmp_tbl[x, y, 0] = c.R;
                        bmp_tbl[x, y, 1] = c.G;
                        bmp_tbl[x, y, 2] = c.B;
                    }
                }

                int[,,] bmp_wyn = new int[bmp_width, bmp_height, 3];


                for (int y = 0; y < bmp_height; y++)
                {
                    progressBar1.Value = 15 + y * 15 / bmp_height;

                    for (int x = 0; x < bmp_width; x++)
                    {
                        for (int s = 0; s < 3; s++)
                        {
                            if (bmp_tbl[x, y, s] < 128)
                                bmp_wyn[x, y, s] = 0;
                            else
                                bmp_wyn[x, y, s] = 255;

                            err = bmp_tbl[x, y, s] - bmp_wyn[x, y, s];

                            if (x < bmp_width - 1)
                                bmp_tbl[x + 1, y, s] += err / 4;
                            if (y < bmp_height - 1)
                            {
                                if (x > 0)
                                    bmp_tbl[x - 1, y + 1, s] += err / 4;

                                bmp_tbl[x, y + 1, s] += err / 4;

                                if (x < bmp.Width - 1)
                                    bmp_tbl[x + 1, y + 1, s] += err / 4;


                            }
                        }


                    }
                }

                #region ZAPIS
                int pixels = bmp_width * bmp_height;
                int bytes = pixels * 3 / 8;
                if (bytes * 8 < pixels * 3)
                    bytes++;
                byte[] tbl = new byte[bytes];
                for (int i = 0; i < tbl.Length; i++)
                    tbl[i] = 0;

                for (int y = 0; y < bmp_height; y++)
                {
                    progressBar1.Value = 30 + y * 15 / bmp_height;

                    for (int x = 0; x < bmp_width; x++)
                    {
                        for (int s = 0; s < 3; s++)
                        {
                            int bit_nr = y * bmp_width * 3 + x * 3 + s;
                            int byte_nr = bit_nr / 8;
                            int bit_in_byte_nr = bit_nr % 8;

                            if (bmp_wyn[x, y, s] > 128)
                                tbl[byte_nr] += (byte)Math.Pow(2, bit_in_byte_nr);
                        }
                    }
                }
                FileStream fs = new FileStream(fn, FileMode.Create, FileAccess.ReadWrite);
                fs.WriteByte((byte)(bmp_width / 256));
                fs.WriteByte((byte)(bmp_width % 256));
                fs.WriteByte((byte)(bmp_height / 256));
                fs.WriteByte((byte)(bmp_height % 256));

                fs.Write(tbl, 0, tbl.Length);

                fs.Close();

                #endregion

                int blur = 2;
                for (int y = 0; y < bmp.Height; y++)
                {
                    progressBar1.Value = 45 + y * 35 / bmp.Height;

                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int[] suma = { 0, 0, 0 };
                        int i = 0;
                        for (int x1 = x - blur; x1 <= x + blur; x1++)
                        {
                            for (int y1 = y - blur; y1 <= y + blur; y1++)
                            {
                                if (x1 < 0 || x1 >= bmp_width || y1 < 0 || y1 >= bmp_height)
                                    continue;
                                i++;
                                for (int s = 0; s < 3; s++)
                                    suma[s] += bmp_wyn[x1, y1, s];
                            }
                        }

                        for (int s = 0; s < 3; s++)
                            bmp_wyn[x, y, s] = suma[s] / i;

                    }
                }
            }
        }

        /*KOLORY*/
        //3 KOLORY
        private void koloryToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (bmp == null)
                return;

            int[,,] bmp_tbl = new int[bmp.Width, bmp.Height, 3];

            Color c;
            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = y * 20 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    bmp_tbl[x, y, 0] = c.R;
                    bmp_tbl[x, y, 1] = c.G;
                    bmp_tbl[x, y, 2] = c.B;
                }
            }

            int[,,] bmp_wyn = new int[bmp.Width, bmp.Height, 3];

            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = 20 + y * 60 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int s = 0; s < 3; s++)
                    {
                        if (bmp_tbl[x, y, s] < 128)
                            bmp_wyn[x, y, s] = 0;
                        else
                            bmp_wyn[x, y, s] = 255;

                        //
                    }


                }
            }

            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = 80 + y * 20 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                    bmp.SetPixel(x, y, Color.FromArgb(bmp_wyn[x, y, 0], bmp_wyn[x, y, 1], bmp_wyn[x, y, 2]));
            }

            pictureBox1.Refresh();
            progressBar1.Visible = false;
        }

        //3 KOLORY F/S
        private void koloryFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bmp == null)
                return;

            int bmp_width = bmp.Width, bmp_hieght = bmp.Height;

            int[,,] bmp_tbl = new int[bmp_width, bmp_hieght, 3];

            Color c;
            int err;
            progressBar1.Visible = true;
            for (int y = 0; y < bmp_hieght; y++)
            {
                progressBar1.Value = y * 20 / bmp_hieght;

                for (int x = 0; x < bmp_width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    bmp_tbl[x, y, 0] = c.R;
                    bmp_tbl[x, y, 1] = c.G;
                    bmp_tbl[x, y, 2] = c.B;
                }
            }

            int[,,] bmp_wyn = new int[bmp_width, bmp_hieght, 3];


            for (int y = 0; y < bmp_hieght; y++)
            {
                progressBar1.Value = 20 + y * 40 / bmp_hieght;

                for (int x = 0; x < bmp_width; x++)
                {
                    for (int s = 0; s < 3; s++)
                    {
                        if (bmp_tbl[x, y, s] < 128)
                            bmp_wyn[x, y, s] = 0;
                        else
                            bmp_wyn[x, y, s] = 255;

                        err = bmp_tbl[x, y, s] - bmp_wyn[x, y, s];

                        if (x < bmp_width - 1)
                            bmp_tbl[x + 1, y, s] += err / 4;
                        if (y < bmp_hieght - 1)
                        {
                            if (x > 0)
                                bmp_tbl[x - 1, y + 1, s] += err / 4;

                            bmp_tbl[x, y + 1, s] += err / 4;

                            if (x < bmp.Width - 1)
                                bmp_tbl[x + 1, y + 1, s] += err / 4;


                        }
                    }


                }
            }

            int blur = 2;


            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = 60 + y * 20 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    int[] suma = { 0, 0, 0 };
                    int i = 0;
                    for (int x1 = x - blur; x1 <= x + blur; x1++)
                    {
                        for (int y1 = y - blur; y1 <= y + blur; y1++)
                        {
                            if (x1 < 0 || x1 >= bmp_width || y1 < 0 || y1 >= bmp_hieght)
                                continue;
                            i++;
                            for (int s = 0; s < 3; s++)
                                suma[s] += bmp_wyn[x1, y1, s];
                        }
                    }

                    for (int s = 0; s < 3; s++)
                        bmp_wyn[x, y, s] = suma[s] / i;

                }
            }


            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = 80 + y * 20 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                    bmp.SetPixel(x, y, Color.FromArgb(bmp_wyn[x, y, 0], bmp_wyn[x, y, 1], bmp_wyn[x, y, 2]));
            }

            pictureBox1.Refresh();
            progressBar1.Visible = false;
        }

        private void koloryFSBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (bmp == null)
                    return;

                int bmp_width = bmp.Width, bmp_hieght = bmp.Height;

                int[,,] bmp_tbl = new int[bmp_width, bmp_hieght, 3];

                Color c;
                int err;
                progressBar1.Visible = true;
                for (int y = 0; y < bmp_hieght; y++)
                {
                    progressBar1.Value = y * 20 / bmp_hieght;

                    for (int x = 0; x < bmp_width; x++)
                    {
                        c = bmp.GetPixel(x, y);
                        bmp_tbl[x, y, 0] = c.R;
                        bmp_tbl[x, y, 1] = c.G;
                        bmp_tbl[x, y, 2] = c.B;
                    }
                }

                int[,,] bmp_wyn = new int[bmp_width, bmp_hieght, 3];


                for (int y = 0; y < bmp_hieght; y++)
                {
                    progressBar1.Value = 20 + y * 40 / bmp_hieght;

                    for (int x = 0; x < bmp_width; x++)
                    {
                        for (int s = 0; s < 3; s++)
                        {
                            if (bmp_tbl[x, y, s] < 128)
                                bmp_wyn[x, y, s] = 0;
                            else
                                bmp_wyn[x, y, s] = 255;

                            err = bmp_tbl[x, y, s] - bmp_wyn[x, y, s];

                            if (x < bmp_width - 1)
                                bmp_tbl[x + 1, y, s] += err / 4;
                            if (y < bmp_hieght - 1)
                            {
                                if (x > 0)
                                    bmp_tbl[x - 1, y + 1, s] += err / 4;

                                bmp_tbl[x, y + 1, s] += err / 4;

                                if (x < bmp.Width - 1)
                                    bmp_tbl[x + 1, y + 1, s] += err / 4;


                            }
                        }


                    }
                }

                int blur = 2;


                for (int y = 0; y < bmp.Height; y++)
                {
                    progressBar1.Value = 60 + y * 20 / bmp.Height;

                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int[] suma = { 0, 0, 0 };
                        int i = 0;
                        for (int x1 = x - blur; x1 <= x + blur; x1++)
                        {
                            for (int y1 = y - blur; y1 <= y + blur; y1++)
                            {
                                if (x1 < 0 || x1 >= bmp_width || y1 < 0 || y1 >= bmp_hieght)
                                    continue;
                                i++;
                                for (int s = 0; s < 3; s++)
                                    suma[s] += bmp_wyn[x1, y1, s];
                            }
                        }

                        for (int s = 0; s < 3; s++)
                            bmp_wyn[x, y, s] = suma[s] / i;

                    }
                }


                for (int y = 0; y < bmp.Height; y++)
                {
                    progressBar1.Value = 80 + y * 20 / bmp.Height;

                    for (int x = 0; x < bmp.Width; x++)
                        bmp.SetPixel(x, y, Color.FromArgb(bmp_wyn[x, y, 0], bmp_wyn[x, y, 1], bmp_wyn[x, y, 2]));
                }

                pictureBox1.Refresh();
                progressBar1.Visible = false;
            }
        }


        /*BLUR*/
        int th_width, th_height;
        int[,,] th_bmp_i, th_bmp_wyn;
        Thread[] threads = null;
        int th_rows_for_thread;
        int[] th_row_start, th_row_end;
        int[] th_proc;

        //BLUR
        private void blurToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bmp == null)
                return;


            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = y * 100 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    int sr = 0, sg = 0, sb = 0, i = 0;

                    for (int x1 = x - 1; x1 <= x + 1; x1++)
                        for (int y1 = y - 1; y1 <= y + 1; y1++)
                        {
                            if (x1 >= bmp.Width || x1 < 0 || y1 < 0 || y1 >= bmp.Height)
                                continue;
                            Color c = bmp.GetPixel(x1, y1);
                            sr += c.R;
                            sg += c.G;
                            sb += c.B;
                            i++;
                        }

                    bmp.SetPixel(x, y, Color.FromArgb(sr / i, sg / i, sb / i));


                }
            }

            pictureBox1.Refresh();
            progressBar1.Visible = false;
        }

        // TIMER

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool fin = true;
            foreach (bool b in th_fin)
                if (!b)
                    fin = false;

            int proc = 100;
            foreach (int p in th_proc)
                if (p < proc)
                    proc = p;

            progressBar1.Value = 30 + (proc * 40) / 100;

            if (fin)
            {
                timer1.Enabled = false;
                threads = null;

                progressBar1.Visible = true;
                for (int y = 0; y < th_height; y++)
                {
                    progressBar1.Value = 70 + y * 30 / th_height;

                    for (int x = 0; x < th_width; x++)
                    {
                        bmp.SetPixel(x, y, Color.FromArgb(th_bmp_wyn[x, y, 0], th_bmp_wyn[x, y, 1], th_bmp_wyn[x, y, 2]));
                    }
                }

                pictureBox1.Refresh();
                progressBar1.Visible = false;

                MessageBox.Show("Wszystkie watki zakończyły pracę");
            }


        }

        bool[] th_fin;
        // BLUR THREADS
        private void blurThreadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bmp == null)
                return;

            th_width = bmp.Width; th_height = bmp.Height;
            th_bmp_i = new int[th_width, th_height, 3];
            th_bmp_wyn = new int[th_width, th_height, 3];


            Color c;
            progressBar1.Visible = true;
            for (int y = 0; y < th_height; y++)
            {
                progressBar1.Value = y * 30 / th_height;

                for (int x = 0; x < th_width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    th_bmp_i[x, y, 0] = c.R;
                    th_bmp_i[x, y, 1] = c.G;
                    th_bmp_i[x, y, 2] = c.B;
                }
            }

            threads = new Thread[Environment.ProcessorCount];
            th_rows_for_thread = th_height / threads.Length;
            while (th_rows_for_thread * threads.Length < th_height)
                th_rows_for_thread++;
            th_row_start = new int[threads.Length];
            th_row_end = new int[threads.Length];
            th_proc = new int[threads.Length];
            th_fin = new bool[threads.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(th_func);
                if (i == 0)
                    th_row_start[i] = 0;
                else
                    th_row_start[i] = th_row_end[i - 1] + 1;

                if (i < threads.Length - 1)
                    th_row_end[i] = th_rows_for_thread * i - 1;
                else
                    th_row_end[i] = th_height - 1;

                th_proc[i] = 0;
                th_fin[i] = false;

                threads[i].Start();


            }

            timer1.Enabled = true;

        }

        // ODWÓRCENIE
        private void odwrócenieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bmp == null)
                return;

            progressBar1.Visible = true;
            for (int y = 0; y < bmp.Height; y++)
            {
                progressBar1.Value = y * 100 / bmp.Height;

                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }

            pictureBox1.Refresh();
            progressBar1.Visible = false;
        }


        //CZERWONY MOTYW
        private void czerwonyMotywToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.DarkRed;
            panel1.BackColor = Color.LightSalmon;
        }

        private void zmianaCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        float currentSize;
        //Powiększanie
        private void dużaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* if (menuStrip1.Font.Style != FontStyle.Bold)
                 menuStrip1.Font = new Font(FontFamily.GenericSerif,
                 12.0F, FontStyle.Bold); */
            currentSize = menuStrip1.Font.Size;
            currentSize += 2.0F;
            menuStrip1.Font = new Font(menuStrip1.Font.Name, currentSize,
                menuStrip1.Font.Style, menuStrip1.Font.Unit);
        }

        //Pomiejszanie
        private void małaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            currentSize = menuStrip1.Font.Size;
            currentSize -= 2.0F;
            menuStrip1.Font = new Font(menuStrip1.Font.Name, currentSize,
                menuStrip1.Font.Style, menuStrip1.Font.Unit);
        }

        
        //Domyślna
        private void domyślnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentSize = menuStrip1.Font.Size;
            currentSize = 9.0F;
            menuStrip1.Font = new Font(menuStrip1.Font.Name, currentSize,
                menuStrip1.Font.Style, menuStrip1.Font.Unit);

        }

        

        void th_func()
        {
            int th_nr = -1; 
            for (int i = 0; i < threads.Length; i++)
                if (threads[i].ManagedThreadId == Thread.CurrentThread.ManagedThreadId)
                    th_nr = i;

            int start = th_row_start[th_nr];
            int stop = th_row_end[th_nr];


            for (int y = start; y <= stop; y++)
            {
                th_proc[th_nr] = (y - start) * 100 / (stop - start);

                for (int x = 0; x < th_width; x++)
                {
                    int sr = 0, sg = 0, sb = 0, i = 0;

                    for (int x1 = x - 4; x1 <= x + 4; x1++)
                        for (int y1 = y - 4; y1 <= y + 4; y1++)
                        {
                            if (x1 >= th_width || x1 < 0 || y1 < 0 || y1 >= th_height)
                                continue;

                            sr += th_bmp_i[x1, y1, 0];
                            sg += th_bmp_i[x1, y1, 1];
                            sb += th_bmp_i[x1, y1, 2];
                            i++;
                        }

                    th_bmp_wyn[x, y, 0] = sr / i;
                    th_bmp_wyn[x, y, 1] = sg / i;
                    th_bmp_wyn[x, y, 2] = sb / i;


                }
            }

            th_fin[th_nr] = true;

        }

        /*PLIK*/

        //Otwórz
        private void otwórzToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    OpenFileDialog d = new OpenFileDialog();
                    d.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|TIFF|*.tif|Wszystkie pliki|*.*";
                    d.FileName = "";
                    d.Title = "Wybierz plik mapy bitowej";
                    if (d.ShowDialog() != DialogResult.OK)
                        return;
                    bmp = new Bitmap(d.FileName);
                    pictureBox1.Image = bmp;
                    pictureBox1.Size = bmp.Size;
                    pictureBox1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się załadować obrazu.\n" + ex.Message);
                }
            }
        }


        //Zapisz
        private void zapiszToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = filtr;
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string ext = sfd.FileName.Substring(sfd.FileName.Length - 3, 3).ToLower();
            ImageFormat f = ImageFormat.Emf;

            if (ext == "png")
                f = ImageFormat.Png;
            if (ext == "gif")
                f = ImageFormat.Gif;
            if (ext == "tif")
                f = ImageFormat.Tiff;
            if (ext == "jpg")
                f = ImageFormat.Jpeg;
            if (ext == "bmp")
                f = ImageFormat.Bmp;
            if (ext == "fks")
            {
                zapiszNasząMetodą(sfd.FileName);
                return;
            }

            bmp.Save(sfd.FileName, f);
        }


    }
}
        