using FiguresForTheBox.FigureCircle;
using FiguresForTheBox.FigureEquilateralTriangle;
using FiguresForTheBox.FigureRectangle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace FiguresForTheBox
{
    /// <summary>
    /// Class ReadTheStreamReader
    /// </summary>
    public class ReadTheStreamReader
    {
        /// <summary>
        /// Method ReadTheStreamReader1()
        /// </summary>
        /// <returns></returns>
        public static Figures[] ReadTheStreamReader1()
        {           
            Figures[] box2 = new Figures[4];           
            string[] temp2 = new string[7];
            //Вырезаем фигуры из бумажного листа
            // Console.WriteLine("Вырезаем фигуры из листа бумаги");            
            string lastNodeName = "";
            int i = 0;
            int y = 0;
            int j = 0;

            using (StreamReader xml = new StreamReader("XmlFigure5.xml"))
            {
                string figureString = xml.ReadToEnd();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(figureString);
                // получим корневой элемент
                XmlElement xRoot = xmlDoc.DocumentElement;
                // обход всех узлов в корневом элементе

                foreach (XmlNode xnode in xRoot)
                {
                    // получаем атрибут name
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("FIGURE");
                        if (attr != null)
                            Console.WriteLine(attr.Value);
                        temp2[j] = attr.Value;
                        j++;
                    }
                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - member
                        if (childnode.Name == "side")
                        {
                            Console.WriteLine($"Сторона1: {childnode.InnerText}");
                            temp2[j] = childnode.InnerText;
                            j++;
                        }
                        // если узел age
                        if (childnode.Name == "side1")
                        {
                            Console.WriteLine($"Сторона2: {childnode.InnerText}");
                            temp2[j] = childnode.InnerText;
                            j++;
                        }
                    }
                    Console.WriteLine();
                }
            }
            for (i = 0; i < 7; i++)
            {
                Console.WriteLine(temp2[i]);
            }

            //  Figures[] box = new Figures[3];
            for (i = 0, y = 0; y < 7; i++, y++)
            {
                if (temp2[y] == "Circle")
                {
                    FigureBuilder circleBuilder = new PaperCircleBuilder(temp2[y], Color.Green);
                    Figures circleFigure1 = circleBuilder.Create(Convert.ToDouble(temp2[y + 1]));
                    box2[i] = circleFigure1;
                }
                else if (temp2[y] == "Rectangle")
                {
                    FigureBuilder rectangleBuilder = new PaperRectangleBuilder(temp2[y], Color.Black);
                    Figures rectangleFigure1 = rectangleBuilder.Create(Convert.ToDouble(temp2[y + 1]), Convert.ToDouble(temp2[y + 2]));
                    box2[i - 2] = rectangleFigure1;
                }
                else if (temp2[i] == "EquilateralTriangle")
                {
                    FigureBuilder equilateralTriangleBuilder = new PaperEquilateralTriangleBuilder(lastNodeName, Color.Blue);
                    Figures equilateralTriangleFigure1 = equilateralTriangleBuilder.Create(Convert.ToDouble(temp2[y + 1]), Convert.ToDouble(temp2[y + 1]), Convert.ToDouble(temp2[y + 1]));
                    box2[i - 1] = equilateralTriangleFigure1;
                }
            }
            return box2;
        }         
    }
}
