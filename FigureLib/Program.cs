using System;
using System.IO;
using System.Text;

namespace FigureLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Figures[] figcirc = new Figures[12];
            string[] temp1;


            using (StreamReader reader = new StreamReader("figureCircle.txt", Encoding.Default))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    temp1 = reader.ReadLine().Split(';');
                    if (i < 3)
                    {
                        FigureBuilder circleBuilder = new CircleBuilder(temp1[0]);
                        Figures circleFigure = circleBuilder.Create(Convert.ToDouble(temp1[1]));
                        figcirc[i] = circleFigure;                        
                        i++;
                    }
                }
            }

            using (StreamReader reader = new StreamReader("figureRectangle.txt", Encoding.Default))
            {
                int i = 3;
                while (!reader.EndOfStream)
                {
                    temp1 = reader.ReadLine().Split(';');
                    if (i < 6)
                    {
                        FigureBuilder rectangleBuilder = new RectangleBuilder(temp1[0]);
                        Figures rectangleFigure = rectangleBuilder.Create(Convert.ToDouble(temp1[1]), Convert.ToDouble(temp1[2]));
                        figcirc[i] = rectangleFigure;
                        i++;
                    }
                }
            }

            using (StreamReader reader = new StreamReader("figureSquare.txt", Encoding.Default))
            {
                int i = 6;
                while (!reader.EndOfStream)
                {
                    temp1 = reader.ReadLine().Split(';');
                    if (i < 9)
                    {
                        FigureBuilder squareBuilder = new SquareBuilder(temp1[0]);
                        Figures squareFigure = squareBuilder.Create(Convert.ToDouble(temp1[1]));
                        figcirc[i] = squareFigure;
                        i++;
                    }

                }
            }

            using (StreamReader reader = new StreamReader("figureTriangle.txt", Encoding.Default))
            {
                int i = 9;
                while (!reader.EndOfStream)
                {
                    temp1 = reader.ReadLine().Split(';');
                    if (i < 12)
                    {
                        FigureBuilder triangleBuilder = new TriangleBuilder(temp1[0]);
                        Figures triangleFigure = triangleBuilder.Create(Convert.ToDouble(temp1[1]), Convert.ToDouble(temp1[2]), Convert.ToDouble(temp1[3]));
                        figcirc[i] = triangleFigure;
                        i++;
                    }
                }
            }

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(figcirc[i]);
            }

            FigureBuilder circleBuilder1 = new CircleBuilder("CircleFigure");
            Figures circleFigure1 = circleBuilder1.Create(3);
            Console.WriteLine("Задана фигура: " + circleFigure1);

            for (int i = 0; i < 12; i++)
            {
                if (CircleFigure.Equals1(circleFigure1, figcirc[i]))
                {
                    Console.WriteLine("Фигура " + circleFigure1 + "\n" + "и фигура " + figcirc[i] + " равны ");
                }
                else
                {
                    Console.WriteLine("Фигура " + circleFigure1 + "\n" + "и фигура " + figcirc[i] + " не равны ");
                }
            }
            Console.ReadKey();
        }
    }
}
