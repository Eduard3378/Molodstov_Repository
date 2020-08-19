using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace FiguresForTheBox
{
    /// <summary>
    /// Class SavePaperShapesXmlWriter
    /// </summary>
    public class SavePaperShapesXmlWriter
    {
        /// <summary>
        /// Method SavePaperShapesXmlWriter1(Figures[] box1)
        /// </summary>
        /// <param name="box1"></param>
        public static void SavePaperShapesXmlWriter1(Figures[] box1)
        {
            Figures[] box = new Figures[20];
            box = box1;
            const double pi = 3.1415;
            int i = 0;
            XmlWriterSettings objSetting = new XmlWriterSettings();
            objSetting.Indent = true;
            objSetting.NewLineOnAttributes = true;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (XmlWriter objWriter = XmlWriter.Create(sb, objSetting))
            {
                objWriter.WriteStartDocument();

                objWriter.WriteStartElement("members");

                for (i = 0; i < 5; i++)
                {
                    Console.WriteLine(box[i] + " " + i);

                    if (Convert.ToString(box[i]) == ("Окружность с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color != "Colorless")
                    {
                        objWriter.WriteStartElement("member");
                        objWriter.WriteStartAttribute("FIGURE");
                        objWriter.WriteValue("Circle");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartElement("side");
                        objWriter.WriteValue(Math.Round(box[i].GetPerimeter() / (2 * pi), 0));
                        objWriter.WriteEndElement();
                        objWriter.WriteEndElement(); //member
                    }
                    if (Convert.ToString(box[i]) == ("Прямоугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color != "Colorless")
                    {
                        objWriter.WriteStartElement("member");
                        objWriter.WriteStartAttribute("FIGURE");
                        objWriter.WriteValue("Rectangle");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartElement("side");
                        objWriter.WriteValue(box[i].Width);
                        objWriter.WriteEndElement();
                        objWriter.WriteStartElement("side1");
                        objWriter.WriteValue(box[i].Hight);
                        objWriter.WriteEndElement();
                        objWriter.WriteEndElement(); //member
                    }
                    if (Convert.ToString(box[i]) == ("Треугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color != "Colorless")
                    {
                        objWriter.WriteStartElement("member");
                        objWriter.WriteStartAttribute("FIGURE");
                        objWriter.WriteValue("EquilateralTriangle");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartElement("side");
                        objWriter.WriteValue(Math.Round(box[i].GetPerimeter() / 3, 0));
                        objWriter.WriteEndElement();
                        objWriter.WriteEndElement(); //member
                    }
                }
            }
            File.WriteAllText("XmlFigure2.xml", sb.ToString());
        }
    }
}
