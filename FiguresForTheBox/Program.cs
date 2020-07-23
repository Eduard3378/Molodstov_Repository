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
    class Program
    {
        //  private static Figures[] box1 = new Figures[100];
        static void Main(string[] args)
        {
            Figures[] box = new Figures[20];
            Figures[] box2 = new Figures[4];
            const double pi = 3.1415;

            string[] temp1 = new string[7];
            string[] temp2 = new string[7];
            //Вырезаем фигуры из бумажного листа
            // Console.WriteLine("Вырезаем фигуры из листа бумаги");
            string[] lastNodeName1 = new string[3];
            string lastNodeName = "";
            double sumArea = 0.0;
            double sumPerim = 0.0;
            int i = 0;
            int y = 0;
            int p = 0;

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

            for (i = 0; i < 20; i++)
            {
                Console.WriteLine(box[i] + " " + i);
            }

            FigureBuilder circleBuilder1 = new PaperCircleBuilder("Circle", Color.Black);
            Figures circleFigure2 = circleBuilder1.Create(6.0);
            for (i = 0; i < box.Length; i++)
            {
                if (box[i] == circleFigure2)
                {
                    break;
                }
                else
                {
                    i = 3;
                    box[i] = circleFigure2;
                    break;
                }

            }

            Console.WriteLine("Коробка после добавление фигуры");
            // Figures[] box = new Figures[4];
            for (i = 0; i < 20; i++)
            {
                Console.WriteLine(box[i] + " " + i);
            }

            Console.WriteLine("Посмотреть по номеру, фигура остается в коробке(номер 3)");
            for (i = 0; i < box.Length; i++)
            {
                int n = 3; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (i == n)
                {
                    Console.WriteLine(box[i]);
                }
            }

            Console.WriteLine("Извлечь по номеру(номер 2) (при этом фигура удаляется из коробки) ");
            for (i = 0; i < box.Length; i++)
            {
                int n = 2; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (i == n)
                {
                    box[i] = null;
                }
                Console.WriteLine(box[i] + " " + i);
            }

            Console.WriteLine("Заменить по номеру ");
            for (i = 0; i < box.Length; i++)
            {
                FigureBuilder rectangleBuilder1 = new PaperRectangleBuilder("Rectangle", Color.White);
                Figures rectangleFigure2 = rectangleBuilder1.Create(7.0, 8.0);
                int n = 2; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (i == n)
                {
                    box[i] = rectangleFigure2;
                }
                Console.WriteLine(box[i] + " " + i);
            }

            Console.WriteLine("Найти фигуру по образцу (эквивалентную по своим характеристикам)  ");
            for (i = 0; i < 4; i++)
            {
                FigureBuilder circleBuilder2 = new PaperCircleBuilder("Circle", Color.Black);
                Figures circleFigure3 = circleBuilder2.Create(6.0);
                // int n = 2; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (CircleFigure.Equals1(circleFigure3, box[i]))
                {
                    Console.WriteLine(box[i]);
                }
            }

            Console.WriteLine("Показать наличное количество фигур ");
            for (i = 0; i < box.Length; i++)
            {

                if (box[i] != null)
                {
                    p++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(p);


            Console.WriteLine("Суммарную площадь  ");
            for (i = 0; i < 4; i++)
            {
                sumArea += box[i].GetArea();
            }
            Console.WriteLine(sumArea);

            Console.WriteLine("Суммарный периметр ");
            for (i = 0; i < 4; i++)
            {
                sumPerim += box[i].GetPerimeter();
            }
            Console.WriteLine(sumPerim);

            Console.WriteLine("Достать все круги  ");
            for (i = 0; i < 4; i++)
            {
                if (Convert.ToString(box[i]) == ("Окружность с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color))
                {
                    Console.WriteLine(box[i]);
                }
                else
                {
                    Console.WriteLine(box[i].Color);
                }
            }


            FigureBuilder rectangleBuilder2 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure3 = rectangleBuilder2.Create(9.0, 10.0);
            box[4] = rectangleFigure3;
            Console.WriteLine("Все фигуры");
            for (i = 0; i < 20; i++)
            {
                Console.WriteLine(box[i] + " " + i);
            }
            Console.WriteLine("Достать все Пленочные фигуры   ");
            for (i = 0; i < 5; i++)
            {
                if (Convert.ToString(box[i]) == ("Прямоугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color == "Colorless")
                {
                    Console.WriteLine(box[i]);
                }
                else
                {
                    Console.WriteLine(box[i].Color);
                }
            }

            Console.WriteLine("Cохранить все фигуры из коробки в XML-файл, используя XmlWriter ");

            XmlWriterSettings objSetting = new XmlWriterSettings();
            objSetting.Indent = true;
            objSetting.NewLineOnAttributes = true;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            // Console.WriteLine(box[0].GetPerimeter());
            using (XmlWriter objWriter = XmlWriter.Create(sb, objSetting))
            {
                objWriter.WriteStartDocument();

                objWriter.WriteStartElement("members");

                for (i = 0; i < 5; i++)
                {
                    Console.WriteLine(box[i] + " " + i);

                    if (Convert.ToString(box[i]) == ("Окружность с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color))
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
                    if (Convert.ToString(box[i]) == ("Треугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color))
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
                    if (Convert.ToString(box[i]) == ("Прямоугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color == "Colorless")
                    {
                        objWriter.WriteStartElement("member");
                        objWriter.WriteStartAttribute("FIGURE");
                        objWriter.WriteValue("RectangleFilm");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartElement("side");
                        objWriter.WriteValue(box[i].Width);
                        objWriter.WriteEndElement();
                        objWriter.WriteStartElement("side1");
                        objWriter.WriteValue(box[i].Hight);
                        objWriter.WriteEndElement();
                        objWriter.WriteEndElement(); //member
                    }
                }
            }
            File.WriteAllText("XmlFigure1.xml", sb.ToString());


            Console.WriteLine("Cохранить только бумажные фигуры из коробки в XML-файл, используя XmlWriter ");
            objSetting = new XmlWriterSettings();
            objSetting.Indent = true;
            objSetting.NewLineOnAttributes = true;
            sb = new System.Text.StringBuilder();
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

            Console.WriteLine("Cохранить только пленочные фигуры из коробки в XML-файл, используя XmlWriter ");



            objSetting = new XmlWriterSettings();
            objSetting.Indent = true;
            objSetting.NewLineOnAttributes = true;
            sb = new System.Text.StringBuilder();
            using (XmlWriter objWriter = XmlWriter.Create(sb, objSetting))
            {
                //Note the artificial, but useful, indenting
                objWriter.WriteStartDocument();

                objWriter.WriteStartElement("members");


                for (i = 0; i < 5; i++)
                {
                    Console.WriteLine(box[i] + " " + i);

                    if (Convert.ToString(box[i]) == ("Окружность с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color == "Colorless")
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
                    if (Convert.ToString(box[i]) == ("Прямоугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color == "Colorless")
                    {
                        objWriter.WriteStartElement("member");
                        objWriter.WriteStartAttribute("FIGURE");
                        objWriter.WriteValue("RectangleFilm");
                        objWriter.WriteEndAttribute();
                        objWriter.WriteStartElement("side");
                        objWriter.WriteValue(box[i].Width);
                        objWriter.WriteEndElement();
                        objWriter.WriteStartElement("side1");
                        objWriter.WriteValue(box[i].Hight);
                        objWriter.WriteEndElement();
                        objWriter.WriteEndElement(); //member
                    }
                    if (Convert.ToString(box[i]) == ("Треугольник с площадью " + box[i].GetArea() + " и периметром " + box[i].GetPerimeter() + " цвет " + box[i].Color) && box[i].Color == "Colorless")
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
            File.WriteAllText("XmlFigure3.xml", sb.ToString());

            Console.WriteLine("Загрузить все фигуры в коробку из XML-файла, используя StreamReader  ");

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
            Console.WriteLine("Cохранить все фигуры из коробки в XML-файл, используя StreamWriter ");

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

            FigureBuilder rectangleBuilder7 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure8 = rectangleBuilder7.Create(9.0, 10.0);
            box2[3] = rectangleFigure8;                

            Console.WriteLine("Все фигуры");
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine(box2[i] + " " + i);
            }


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
                        sw.WriteLine("<member FIGURE=\"Rectangle\">");
                        sw.WriteLine("<side>" + (box2[i].Width) + "</side>");
                        sw.WriteLine("<side1>" + (box2[i].Hight) + "</side1>");
                        sw.WriteLine("</member>");
                    }
                }
                sw.WriteLine("</members>");
            }


            Console.WriteLine("Cохранить только бумажные фигуры из коробки в XML-файл, используя StreamWriter ");
            using (StreamWriter sw = new StreamWriter("XmlFigure7.xml"))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
                sw.WriteLine("<members>");
                for (i = 0; i < 4; i++)
                {
                    // Console.WriteLine(box2[i] + " " + i);


                    if (Convert.ToString(box2[i]) == ("Окружность с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color != "Colorless")
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
                    if (Convert.ToString(box2[i]) == ("Треугольник с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color != "Colorless")
                    {
                        sw.WriteLine("<member FIGURE=\"EquilateralTriangle\">");
                        sw.WriteLine("<side>" + (Math.Round(box2[i].GetPerimeter() / 3, 0)) + "</side>");
                        sw.WriteLine("</member>");
                    }                   
                }
                sw.WriteLine("</members>");
            }

            Console.WriteLine("Cохранить только пленочные фигуры из коробки в XML-файл, используя StreamWriter ");
            using (StreamWriter sw = new StreamWriter("XmlFigure8.xml"))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
                sw.WriteLine("<members>");
                for (i = 0; i < 4; i++)
                {
                    // Console.WriteLine(box2[i] + " " + i);


                    if (Convert.ToString(box2[i]) == ("Окружность с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color == "Colorless")
                    {

                        sw.WriteLine("<member FIGURE=\"Circle\">");
                        sw.WriteLine("<side>" + (Math.Round(box2[i].GetPerimeter() / (2 * pi), 0)) + "</side>");
                        sw.WriteLine("</member>");
                    }
                    if (Convert.ToString(box2[i]) == ("Прямоугольник с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color == "Colorless")
                    {
                        sw.WriteLine("<member FIGURE=\"Rectangle\">");
                        sw.WriteLine("<side>" + (box2[i].Width) + "</side>");
                        sw.WriteLine("<side1>" + (box2[i].Hight) + "</side1>");
                        sw.WriteLine("</member>");
                    }
                    if (Convert.ToString(box2[i]) == ("Треугольник с площадью " + box2[i].GetArea() + " и периметром " + box2[i].GetPerimeter() + " цвет " + box2[i].Color) && box2[i].Color == "Colorless")
                    {
                        sw.WriteLine("<member FIGURE=\"EquilateralTriangle\">");
                        sw.WriteLine("<side>" + (Math.Round(box2[i].GetPerimeter() / 3, 0)) + "</side>");
                        sw.WriteLine("</member>");
                    }
                }
                sw.WriteLine("</members>");
            }
            Console.ReadKey();
        }      
    }
}
