using System;

namespace Chess
{
    class Program
    {


        static int[] input(string promptx, string prompty)
        {

            Console.Write(promptx);
            int x = Convert.ToByte(Console.ReadLine());
            Console.Write(prompty);
            int y = Convert.ToByte(Console.ReadLine());
            int[] a = { x, y };
            return a;
        }
        static void draw(int[] Korol, int[] Slon, int[] Ladya)
        {
            Console.WriteLine();
            Console.WriteLine(" 1  2  3  4  5  6  7  8");
            for (int i = 8; i > 0; i--)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (j == 9)
                    {
                        Console.Write("|" + i);
                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                        {
                            if (Korol[0] == i && Korol[1] == j)
                            {
                                Console.Write(' ');
                                Console.Write('K');
                                Console.Write(' ');
                            }
                            else if (Ladya[0] == i && Ladya[1] == j)
                            {
                                Console.Write(' ');
                                Console.Write('R');
                                Console.Write(' ');



                            }
                            else if (Slon[0] == i && Slon[1] == j)
                            {
                                    Console.Write(" ");
                                    Console.Write("B");
                                    Console.Write(" ");
                            }

                            else
                            {
                                Console.Write('▓');
                                Console.Write('▓');
                                Console.Write('▓');
                            }
                        }
                        else
                        {
                            if (Korol[0] == i && Korol[1] == j)
                            {
                                Console.Write(' ');
                                Console.Write('K');
                                Console.Write(' ');
                            }
                            else if (Ladya[0] == i && Ladya[1] == j)
                            {
                                Console.Write(' ');
                                Console.Write('R');
                                Console.Write(' ');
                            }
                            else if (Slon[0] == i && Slon[1] == j)
                            {
                                Console.Write(' ');
                                Console.Write('B');
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write('░');
                                Console.Write('░');
                                Console.Write('░');
                            }
                        }
                    }

                }
                Console.WriteLine();
            }

        }


        static void Main()
        {
            int[] Korol = new int[2] { 0, 0 };
            int[] Slon = new int[2] { 0, 0 };
            int[] Ladya = new int[2] { 0, 0 };
            Console.Write("Шахматная задача с определением угрозы королю, шахматное поле представляет собой поле 8 x 8 клеток,\n так что числа в вводе вводите от 1 до 8 включительно \n");
            draw(Korol, Slon, Ladya);
            Console.WriteLine("введите позиции для Короля, сначала по оси x - горизонтали, потом по оси y - вертикали");
            Korol = input("Король по горизонтали= ", "Король по вертикали= ");
            while (Korol[0] <= 0 || Korol[0] >= 9 || Korol[1] <= 0 || Korol[1] >= 9) // король за полем или на неположеном месте
            {
                Console.WriteLine("Ошибка! Фигура за полем! Введите позицию короля снова.");
                Console.WriteLine("введите позиции для Короля, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Korol = input("Король по горизонтали= ", "Король по вертикали= ");
            }
            draw(Korol, Slon, Ladya);
            Console.WriteLine("введите позиции для Слона, сначала по оси x - горизонтали, потом по оси y - вертикали");
            Slon = input("Слон по горизонтали= ", "Слон по вертикали= ");
            while (Slon[0] <= 0 || Slon[0] >= 9 || Slon[1] <= 0 || Slon[1] >= 9) // слон за полем или на неположеном месте
            {
                Console.WriteLine("Ошибка! Фигура за полем!");
                Console.WriteLine("введите позиции для Слона, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Slon = input("Слон по горизонтали= ", "Слон по вертикали= ");
            }
            while (Slon[0] == Korol[0] && Slon[1] == Korol[1])
            {
                Console.WriteLine("Ошибка! Поле занято!");
                Console.WriteLine("введите позиции для Слона, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Slon = input("Слон по горизонтали= ", "Слон по вертикали= ");
            }
            draw(Korol, Slon, Ladya);
            Console.WriteLine("введите позиции для Ладьи, сначала по оси x - горизонтали, потом по оси y - вертикали");
            Ladya = input("Ладья по горизонтали= ", "Ладья по вертикали= ");
            while (Ladya[0] <= 0 || Ladya[0] >= 9 || Ladya[1] <= 0 || Ladya[1] >= 9) // ладья за полем или на неположеном месте
            {
                Console.WriteLine("Ошибка! Фигура за полем!");
                Console.WriteLine("введите позиции для Ладьи, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Ladya = input("Ладья по горизонтали= ", "Ладья по вертикали= ");
            }
            while ((Ladya[0] == Korol[0] && Ladya[1] == Korol[1]) || (Slon[0] == Ladya[0] && Slon[1] == Ladya[1]))
            {
                Console.WriteLine("Ошибка! Поле занято!");
                Console.WriteLine("введите позиции для Ладьи, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Ladya = input("Ладья по горизонтали= ", "Ладья по вертикали= ");
            }
            draw(Korol, Slon, Ladya);
            /*// если слон совпадает обеими координатами с другой фигурой выдаст ошибку
            if ((Slonx == KorolX && Slony == KorolY) || (Slonx == Ladyax && Slony == LadyaY))
            {
                Console.WriteLine("Ошибка! Фигура на фигуре!");
                return;
            }*/
            Console.WriteLine("Фигуры раставлены");
            Console.WriteLine("Король [{0},{1}], Слон [{2},{3}], Ладья [{4},{5}]", Korol[0], Korol[1], Slon[0], Slon[1], Ladya[0], Ladya[1]);
            Console.WriteLine("угроза такова:");
            bool Slonperedladya = false, ladyaperedslon = false, s = false, l = false, k = false;
            if ((Ladya[0] == Slon[0]) || (Ladya[1] == Slon[1]))
            {
                if (((Slon[0] > Korol[0] && Slon[0] < Ladya[0]) || (Slon[0] < Korol[0] && Slon[0] > Ladya[0])) ||
                ((Slon[1] > Korol[1] && Slon[1] < Ladya[1]) || (Slon[1] < Korol[1] && Slon[1] > Ladya[1])))
                {
                    Slonperedladya = true; // слон перед ладьей и преграждает ей шах
                }
            }
            if (Math.Abs(Ladya[0] - Slon[0]) == Math.Abs(Ladya[1] - Slon[1]))
            {
                if (Math.Abs(Ladya[0] - Slon[0]) < Math.Abs(Korol[0] - Slon[0]))
                {
                    ladyaperedslon = true; // ладья на пути шаха слона, нет шаха
                }
            }
            if (Math.Abs(Korol[0] - Slon[0]) == Math.Abs(Korol[1] - Slon[1]))
            {
                s = true;
            }
            if (Korol[0] == Ladya[0] || Korol[1] == Ladya[1])
            {
                l = true;
            }
            // нет угрозы королю
            if (Math.Abs(Korol[0] - Slon[0]) != Math.Abs(Korol[1] - Slon[1]) && (Korol[0] != Ladya[0] && Korol[1] != Ladya[1]))
            {
                k = true;
            }
            if ((Slonperedladya)) { Console.WriteLine("слон закрывает короля от шаха ладьи, шаха нет"); }
            if ((ladyaperedslon)) { Console.WriteLine("ладья закрывает короля от шаха слона, шаха нет"); }
            if (((l & !s) && (!Slonperedladya))) { Console.WriteLine("шах от ладьи"); }
            if (((s & !l) && (!ladyaperedslon))) { Console.WriteLine("шах от слона"); }
            if ((l && s)) { Console.WriteLine("шах от слона и ладьи одновременно"); }
            if ((k)) { Console.WriteLine("нет шаха"); }
        }
    }
}
