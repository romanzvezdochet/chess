using System;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            byte KorolX;
            byte KorolY;
            byte Slonx;
            byte Slony;
            byte Ladyax;
            byte LadyaY;

            Console.Write("Шахматная задача с определением угрозы королю, шахматное поле представляет собой поле 8 x 8 клеток,\n так что числа в вводе вводите от 1 до 8 включительно \n");
            Console.WriteLine("1  2  3  4  5  6  7  8");
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
                            Console.Write('■' + "  ");
                        }
                        else
                        {
                            Console.Write('■' + "  ");
                        }
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("введите позиции для Короля, сначала по оси x - горизонтали, потом по оси y - вертикали");
            Console.Write("KorolX= ");
            KorolX = Convert.ToByte(Console.ReadLine());
            Console.Write("KorolY= ");
            KorolY = Convert.ToByte(Console.ReadLine());
            while (KorolX < 1 || KorolX > 8 || KorolY < 1 || KorolY > 8) // король за полем или на неположеном месте
            {
                Console.WriteLine("Ошибка! Фигура за полем! Введите позицию короля снова.");
                Console.WriteLine("введите позиции для Короля, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Console.Write("KorolX= ");
                KorolX = Convert.ToByte(Console.ReadLine());
                Console.Write("KorolY= ");
                KorolY = Convert.ToByte(Console.ReadLine());

            }

            Console.WriteLine("введите позиции для Слона, сначала по оси x - горизонтали, потом по оси y - вертикали");
            Console.Write("SlonX= ");
            Slonx = Convert.ToByte(Console.ReadLine());
            Console.Write("SlonY= ");
            Slony = Convert.ToByte(Console.ReadLine());
            while (Slonx < 1 || Slonx > 8 || Slony < 1 || Slony > 8) // слон за полем или на неположеном месте
            {
                Console.WriteLine("Ошибка! Фигура за полем!");
                Console.WriteLine("введите позиции для Слона, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Console.Write("SlonX= ");
                Slonx = Convert.ToByte(Console.ReadLine());
                Console.Write("SlonY= ");
                Slony = Convert.ToByte(Console.ReadLine());
            }
            Console.WriteLine("введите позиции для Ладьи, сначала по оси x - горизонтали, потом по оси y - вертикали");
            Console.Write("LadyaX= ");
            Ladyax = Convert.ToByte(Console.ReadLine());
            Console.Write("LadyaY= ");
            LadyaY = Convert.ToByte(Console.ReadLine());
            while (Ladyax < 1 || Ladyax > 8 || LadyaY < 1 || LadyaY > 8) // ладья за полем или на неположеном месте
            {
                Console.WriteLine("Ошибка! Фигура за полем!");
                Console.WriteLine("введите позиции для Ладьи, сначала по оси x - горизонтали, потом по оси y - вертикали");
                Console.Write("LadyaX= ");
                Ladyax = Convert.ToByte(Console.ReadLine());
                Console.Write("LadyaY= ");
                LadyaY = Convert.ToByte(Console.ReadLine());
            }
            // если король совпадает обеими координатами с другой фигурой выдаст ошибку
            if ((KorolX == Slonx && KorolY == Slony) || (KorolX == Ladyax && KorolY == LadyaY))
            {
                Console.WriteLine("Ошибка! Фигура на фигуре!");
                return;
            }
            // если слон совпадает обеими координатами с другой фигурой выдаст ошибку
            if ((Slonx == KorolX && Slony == KorolY) || (Slonx == Ladyax && Slony == LadyaY))
            {
                Console.WriteLine("Ошибка! Фигура на фигуре!");
                return;
            }
            Console.WriteLine("Фигуры раставлены");
            Console.WriteLine("Король [{0},{1}], Слон [{2},{3}], Ладья [{4},{5}]", KorolX, KorolY, Slonx, Slony, Ladyax, LadyaY);
            Console.WriteLine("угроза такова:");
            bool Slonperedladya = false, ladyaperedslon = false, s = false, l = false, k = false;
            if ((Ladyax == Slonx) || (LadyaY == Slony))
            {
                if (((Slonx > KorolX && Slonx < Ladyax) || (Slonx < KorolX && Slonx > Ladyax)) ||
                ((Slony > KorolY && Slony < LadyaY) || (Slony < KorolY && Slony > LadyaY)))
                {
                    Slonperedladya = true; // слон перед ладьей и преграждает ей шах
                }
            }
            if (Math.Abs(Ladyax - Slonx) == Math.Abs(LadyaY - Slony))
            {
                if (Math.Abs(Ladyax - Slonx) < Math.Abs(KorolX - Slonx))
                {
                    ladyaperedslon = true; // ладья на пути шаха слона, нет шаха
                }
            }
            if (Math.Abs(KorolX - Slonx) == Math.Abs(KorolY - Slony))
            {
                s = true;
            }
            if (KorolX == Ladyax || KorolY == LadyaY)
            {
                l = true;
            }
            // нет угрозы королю
            if (Math.Abs(KorolX - Slonx) != Math.Abs(KorolY - Slony) && (KorolX != Ladyax && KorolY != LadyaY))
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
