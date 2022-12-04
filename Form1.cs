using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalJulia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //функция зарисовки фрактала
        public void DrawFractal(int w, int h, Graphics g, Pen pen) 
        {
            // при каждой итерации, вычисляется znew = zold² + С

            // вещественная  и мнимая части постоянной C
            double cRe, cIm;
            // вещественная и мнимая части старой и новой
            double newRe, newIm, oldRe, oldIm;
            // Можно увеличивать и изменять положение
            double zoom = 1, moveX = 0, moveY = 0;
            //Определяем после какого числа итераций функция должна прекратить свою работу
            int maxIterations = 300;

            //выбираем несколько значений константы С, это определяет форму фрактала Жюлиа
            cRe = -0.70176;
            cIm = -0.3842;

            //"перебираем" каждый пиксель
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    //вычисляется реальная и мнимая части числа z
                    //на основе расположения пикселей,масштабирования и значения позиции
                    newRe = 1.5 * (x - w / 2) / (0.5 * zoom * w) + moveX;
                    newIm = (y - h / 2) / (0.5 * zoom * h) + moveY;
                    //i представляет собой число итераций 
                    int i;

                    //начинается процесс итерации
                    for (i = 0; i < maxIterations; i++)
                    {

                        //Запоминаем значение предыдущей итерации
                        oldRe = newRe;
                        oldIm = newIm;

                        // в текущей итерации вычисляются действительная и мнимая части 
                        newRe = oldRe * oldRe - oldIm * oldIm + cRe;
                        newIm = 2 * oldRe * oldIm + cIm;

                        // если точка находится вне круга с радиусом 2 - прерываемся
                        if ((newRe * newRe + newIm * newIm) > 4) break;
                    }

                    //определяем цвета
                    //pen.Color = Color.FromArgb(255, (i * 9) % 255, 0, (i * 9) % 255);
                    pen.Color = Color.FromArgb(255, (i * 50) % 255, 0, (i * 50) % 255);
                    //рисуем пиксель
                    g.DrawRectangle(pen, x, y, 1, 1);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Выбираем перо "myPen" черного цвета Black
            //толщиной в 1 пиксель:
            Pen myPen = new Pen(Color.Black, 1);
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //вызываем функцию рисования фрактала
            DrawFractal(840, 620, g, myPen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
