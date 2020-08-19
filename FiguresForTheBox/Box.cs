using FiguresForTheBox.FigureCircle;
using FiguresForTheBox.FigureRectangle;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FiguresForTheBox
{
    /// <summary>
    /// Class Box
    /// </summary>
    public class Box
    {
       static Figures[] box = new Figures[4];
        /// <summary>
        /// Method Figures[] Figures1(params Figures[] figure)
        /// </summary>
        /// <param name="figure"></param>
        /// <returns>Fill the box with shapes for BoxTests</returns>
        public static Figures[] Figures1(params Figures[] figure)
        {
            // Figures1 = figure;
            box[0] = figure[0];
            box[1] = figure[1];
            box[2] = figure[2];
            box[3] = figure[3];           
            return box;
        }
        /// <summary>
        /// Method Figures[] AddShape(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        /// <returns>Adding a shape</returns>
        public static Figures[] AddShape(Figures[] box)
        {
            FigureBuilder circleBuilder1 = new PaperCircleBuilder("Circle", Color.Black);
            Figures circleFigure2 = circleBuilder1.Create(6.0);
            for (int i = 0; i < box.Length; i++)
            {
                if (box[i] == circleFigure2)
                {
                    break;
                }
                else
                {
                    i = 3;
                    box[i] = circleFigure2;                   
                   // return box;
                    break;
                }                
            }
            return box;
        }
        /// <summary>
        /// Method ViewByNumber(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void ViewByNumber(Figures[] box)
        {
            Console.WriteLine("Посмотреть по номеру, фигура остается в коробке(номер 3)");
            for (int i = 0; i < box.Length; i++)
            {
                int n = 3; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (i == n)
                {
                    Console.WriteLine(box[i]);
                }
            }
        }
        /// <summary>
        /// Method ExtractByNumber(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void ExtractByNumber(Figures[] box)
        {
            Console.WriteLine("Извлечь по номеру(номер 2) (при этом фигура удаляется из коробки) ");
            for (int i = 0; i < box.Length; i++)
            {
                int n = 2; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (i == n)
                {
                    box[i] = null;
                }
                Console.WriteLine(box[i] + " " + i);
            }
        }
        /// <summary>
        /// Method ReplaceByNumber(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void ReplaceByNumber(Figures[] box)
        {
            Console.WriteLine("Заменить по номеру ");
            for (int i = 0; i < box.Length; i++)
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
        }
        /// <summary>
        /// Method FindShapeByPattern(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void FindShapeByPattern(Figures[] box)
        {
            Console.WriteLine("Найти фигуру по образцу (эквивалентную по своим характеристикам)  ");
            for (int i = 0; i < 4; i++)
            {
                FigureBuilder circleBuilder2 = new PaperCircleBuilder("Circle", Color.Black);
                Figures circleFigure3 = circleBuilder2.Create(6.0);
                // int n = 2; //просмотреть по номеру (при этом фигура остается в коробке) 
                if (CircleFigure.Equals1(circleFigure3, box[i]))
                {
                    Console.WriteLine(box[i]);
                }
            }
        }
        /// <summary>
        /// Method AvailableNumberFigures(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void AvailableNumberFigures(Figures[] box)
        {
            int p = 0;
            Console.WriteLine("Показать наличное количество фигур ");
            for (int i = 0; i < box.Length; i++)
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
        }
        /// <summary>
        /// Method TotalArea(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void TotalArea(Figures[] box)
        {
            double sumArea = 0.0;          
            Console.WriteLine("Суммарную площадь  ");
            for (int i = 0; i < 4; i++)
            {
                sumArea += box[i].GetArea();
            }
            Console.WriteLine(sumArea);
        }
        /// <summary>
        /// Method TotalPerimeter(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void TotalPerimeter(Figures[] box)
        {
            double sumPerim = 0.0;
            Console.WriteLine("Суммарный периметр ");
            for (int i = 0; i < 4; i++)
            {
                sumPerim += box[i].GetPerimeter();
            }
            Console.WriteLine(sumPerim);
        }
        /// <summary>
        /// Method GetAllCircles(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void GetAllCircles(Figures[] box)
        {
            Console.WriteLine("Достать все круги  ");
            for (int i = 0; i < 4; i++)
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
        }
        /// <summary>
        /// Method AllFilmFigures(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void AllFilmFigures(Figures[] box)
        {
            Console.WriteLine("Достать все Пленочные фигуры   ");
            for (int i = 0; i < 5; i++)
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
        }
        /// <summary>
        /// Method ViewAllShapes(Figures[] box)
        /// </summary>
        /// <param name="box"></param>
        public static void ViewAllShapes(Figures[] box)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(box[i] + " " + i);
            }
        }
    }
}
