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
    /// Class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Figures[] box = new Figures[20];
            Figures[] box2 = new Figures[4];
            const double pi = 3.1415;         
            int i;           
            Console.WriteLine("Загрузить все фигуры в коробку из XML-файла, используя XmlReader");
            box = ReadTheXmlReader.ReadTheXmlReader1();

            Box.ViewAllShapes(box);           
            Box.AddShape(box);
            Console.WriteLine("Коробка после добавление фигуры");
            Box.ViewAllShapes(box);
            Box.ViewByNumber(box);
            Box.ExtractByNumber(box);
            Box.ReplaceByNumber(box);
            Box.FindShapeByPattern(box);
            Box.AvailableNumberFigures(box);
            Box.TotalArea(box);
            Box.TotalPerimeter(box);
            Box.GetAllCircles(box);
            FigureBuilder rectangleBuilder2 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure3 = rectangleBuilder2.Create(9.0, 10.0);
            box[4] = rectangleFigure3;
            Console.WriteLine("Все фигуры");
            Box.ViewAllShapes(box);
            Box.AllFilmFigures(box);

            //Console.WriteLine("Cохранить все фигуры из коробки в XML-файл, используя XmlWriter ");
            SaveAllShapesXmlWriter.SaveAllShapesXmlWriter1(box);

            XmlWriterSettings objSetting = new XmlWriterSettings();
            objSetting.Indent = true;
            objSetting.NewLineOnAttributes = true;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();       

            Console.WriteLine("Cохранить только бумажные фигуры из коробки в XML-файл, используя XmlWriter ");
            SavePaperShapesXmlWriter.SavePaperShapesXmlWriter1(box);

            Console.WriteLine("Cохранить только пленочные фигуры из коробки в XML-файл, используя XmlWriter ");
            SaveTheFilmShapesXmlWriter.SaveTheFilmShapesXmlWriter1(box);

            Console.WriteLine("Загрузить все фигуры в коробку из XML-файла, используя StreamReader");
            box2 = ReadTheStreamReader.ReadTheStreamReader1();

            FigureBuilder rectangleBuilder7 = new FilmRectangleBuilder("RectangleFilm", Color.Colorless);
            Figures rectangleFigure8 = rectangleBuilder7.Create(9.0, 10.0);
            box2[3] = rectangleFigure8;                

            Console.WriteLine("Все фигуры");
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine(box2[i] + " " + i);
            }

            Console.WriteLine("Cохранить все фигуры из коробки в XML-файл, используя StreamWriter ");
            SaveAllShapesStreamWriter.SaveAllShapesStreamWriter1(box2);

            Console.WriteLine("Cохранить только бумажные фигуры из коробки в XML-файл, используя StreamWriter ");
            SavePaperShapesStreamWriter.SavePaperShapesStreamWriter1(box2);

            Console.WriteLine("Cохранить только пленочные фигуры из коробки в XML-файл, используя StreamWriter ");
            SaveTheFilmShapesStreamWriter.SaveTheFilmShapesStreamWriter1(box2);
            Console.ReadKey();
        }      
    }
}
