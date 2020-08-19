using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FiguresForTheBox
{
    /// <summary>
    /// Class SaveAllShapesStreamWriter
    /// </summary>
    public class SaveAllShapesStreamWriter
    {
        /// <summary>
        /// Method SaveAllShapesStreamWriter1(Figures[] box2)
        /// </summary>
        /// <param name="box2"></param>
        public static void SaveAllShapesStreamWriter1(Figures[] box2)
        {
            Figures[] box = new Figures[20];
            box = box2;
            const double pi = 3.1415;
            int i = 0;
            //Console.WriteLine("Cохранить все фигуры из коробки в XML-файл, используя XmlWriter ");
            //XmlWriterSettings objSetting = new XmlWriterSettings();
            //objSetting.Indent = true;
            //objSetting.NewLineOnAttributes = true;
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (StreamWriter sw = new StreamWriter("XmlFigure6.xml"))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
                sw.WriteLine("<members>");
                for (i = 0; i < 4; i++)
                {
                    // Console.WriteLine(box2[i] + " " + i);


                    if (Convert.ToString(box2[i]) == ("Окружность с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color))
                    {

                        sw.WriteLine("<member FIGURE=\"Circle\">");
                        sw.WriteLine("<side>" + (Math.Round(box2[i].GetPerimeter() / (2 * pi), 0)) + "</side>");
                        sw.WriteLine("</member>");
                    }
                    if (Convert.ToString(box2[i]) == ("Прямоугольник с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color != "Colorless")
                    {
                        sw.WriteLine("<member FIGURE=\"Rectangle\">");
                        sw.WriteLine("<side>" + (box2[i].Width) + "</side>");
                        sw.WriteLine("<side1>" + (box2[i].Hight) + "</side1>");
                        sw.WriteLine("</member>");
                    }
                    if (Convert.ToString(box2[i]) == ("Треугольник с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color))
                    {
                        sw.WriteLine("<member FIGURE=\"EquilateralTriangle\">");
                        sw.WriteLine("<side>" + (Math.Round(box2[i].GetPerimeter() / 3, 0)) + "</side>");
                        sw.WriteLine("</member>");
                    }
                    if (Convert.ToString(box2[i]) == ("Прямоугольник с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color == "Colorless")
                    {
                        sw.WriteLine("<member FIGURE=\"RectangleFilm\">");
                        sw.WriteLine("<side>" + (box2[i].Width) + "</side>");
                        sw.WriteLine("<side1>" + (box2[i].Hight) + "</side1>");
                        sw.WriteLine("</member>");
                    }
                }
                sw.WriteLine("</members>");
            }
        }
    }
}
