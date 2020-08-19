using FiguresForTheBox.FigureCircle;
using FiguresForTheBox.FigureEquilateralTriangle;
using FiguresForTheBox.FigureRectangle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FiguresForTheBox
{
    /// <summary>
    /// Class ReadTheXmlReader
    /// </summary>
    public class ReadTheXmlReader
    {
        /// <summary>
        /// Method ReadTheXmlReader1()
        /// </summary>
        /// <returns></returns>
        public static Figures[] ReadTheXmlReader1()
        {
            Figures[] box = new Figures[20];
            Figures[] box2 = new Figures[4];
           // const double pi = 3.1415;

            string[] temp1 = new string[7];
            string[] temp2 = new string[7];
            //Вырезаем фигуры из бумажного листа
            // Console.WriteLine("Вырезаем фигуры из листа бумаги");
            string[] lastNodeName1 = new string[3];
            string lastNodeName = "";
            int i = 0;
            int y = 0;
            using (XmlReader xml = XmlReader.Create("XmlFigure.xml"))
            {
                while (xml.Read())
                {
                    switch (xml.NodeType)
                    {
                        case XmlNodeType.Element:
                            // нашли элемент member
                            if (xml.Name == "member")
                            {
                                if (xml.HasAttributes)
                                {
                                    // поиск атрибута figure
                                    while (xml.MoveToNextAttribute())
                                    {
                                        if (xml.Name == "FIGURE")
                                        {
                                            temp1[i] = xml.Value;
                                            i++;
                                            Console.WriteLine("FIGURE: {0}", xml.Value);
                                            break;
                                        }
                                    }
                                }
                            }
                            // запоминаем имя найденного элемента
                            lastNodeName = xml.Name;
                            //  lastNodeName1[i] = lastNodeName;
                            //   Console.WriteLine(lastNodeName1[i]);
                            break;
                        case XmlNodeType.Text:
                            // нашли текст, смотрим по имени элемента, что это за текст
                            if (lastNodeName == "side")
                            {
                                temp1[i] = xml.Value;
                                i++;
                                Console.WriteLine("Сторона1: {0}", xml.Value);
                            }
                            else if (lastNodeName == "side1")
                            {
                                temp1[i] = xml.Value;
                                i++;
                                Console.WriteLine("Сторона2: {0}", xml.Value);
                            }
                            break;
                        case XmlNodeType.EndElement:
                            // закрывающий элемент
                            if (xml.Name == "member")
                            {
                                Console.WriteLine("------------------------------------------");
                            }
                            break;
                    }
                }
            }
            for (i = 0; i < 7; i++)
            {
                Console.WriteLine(temp1[i]);
            }

            //  Figures[] box = new Figures[3];
            for (i = 0, y = 0; y < 7; i++, y++)
            {
                if (temp1[y] == "Circle")
                {
                    FigureBuilder circleBuilder = new PaperCircleBuilder(temp1[y], Color.Green);
                    Figures circleFigure1 = circleBuilder.Create(Convert.ToDouble(temp1[y + 1]));
                    box[i] = circleFigure1;
                }
                else if (temp1[y] == "Rectangle")
                {
                    FigureBuilder rectangleBuilder = new PaperRectangleBuilder(temp1[y], Color.Black);
                    Figures rectangleFigure1 = rectangleBuilder.Create(Convert.ToDouble(temp1[y + 1]), Convert.ToDouble(temp1[y + 2]));
                    box[i - 2] = rectangleFigure1;
                }
                else if (temp1[i] == "EquilateralTriangle")
                {
                    FigureBuilder equilateralTriangleBuilder = new PaperEquilateralTriangleBuilder(lastNodeName, Color.Blue);
                    Figures equilateralTriangleFigure1 = equilateralTriangleBuilder.Create(Convert.ToDouble(temp1[y + 1]), Convert.ToDouble(temp1[y + 1]), Convert.ToDouble(temp1[y + 1]));
                    box[i - 1] = equilateralTriangleFigure1;
                }
            }
            return box;
        }
    }
}
