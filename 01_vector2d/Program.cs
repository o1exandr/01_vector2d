/*
 1. Визначити клас Вектор На Площині(Vector2D), що містить координати вектора (х, у).
Визначити у класі 
	необхідні конструктор(и)
	перевизначити(override) метод ToString()
	властивіть обчислення довжини вектора(корінь квадратний(х*х + у*у)
	
Оператори
	 + додавання двох векторів(результатом  є вектор : (x1 + x2, y1 + y2))
	 - віднімання двох векторів(результатом  є вектор : (x1 - x2, y1 - y2))
	 * множення  вектора на скаляр(дробове число) (результатом  є вектор : (x1 *num, y1 * num))
	 * множення  вектора на вектор(результатом  є дробове число x1*y1 + x2 * y2)
	  ==,  != операції порівняння двох векторів(попередньо перевизначити Equals(), GetHashCode(), 		використати Equals())
	 приведення типів
		явне перетворення до типу double (повертати довжину  вектора)
		неявне перетворення  від типу double до типу Вектор  (дробове число - х координата, 0 - у 		координата)
	 ++, --  збільшувати(зменшувати) обидві координати на 1
 	- унарний (змінювати знак обох  координат вектора) 
	 оператори true, false ( false - вектор (0;0), true - хоч одна координата не нуль)
	- одновимірний індексатор, який за індексом 0 повертає х -координату, за індексом  1 - у координату 	
 		
Перевірити роботу операцій, включно з +=, -=, *=
 */

using System;


namespace _01_vector2d
{
    class Program
    {
        class Vector2D
        {
            double x, y;
            #region Property
            public double X
            {
                get => x;
                set
                {
                    x = value;
                }
            }

            public double Y
            {
                get => y;
                set
                {
                    y = value;
                }
            }

            //властивіть обчислення довжини вектора(корінь квадратний(х*х + у*у)
            public double Length
            {
                get => Math.Sqrt(X * X + Y * Y);
            }
            #endregion

            //необхідні конструктор(и)
            public Vector2D(double x_, double y_)
            {
                X = x_;
                Y = y_;
            }

            public Vector2D()
            {
                X = 0;
                Y = 1;
            }

            // - віднімання двох векторів(результатом  є вектор : (x1 - x2, y1 - y2))
            public static Vector2D operator -(Vector2D a, Vector2D b)
            {
                Vector2D res = new Vector2D();
                res.X = a.X - b.X;
                res.Y = a.Y - b.Y;
                return res;
            }

            // + додавання двох векторів(результатом  є вектор : (x1 + x2, y1 + y2))
            public static Vector2D operator +(Vector2D a, Vector2D b)
            {
                Vector2D res = new Vector2D();
                res.X = a.X + b.X;
                res.Y = a.Y + b.Y;
                return res;
            }

            //* множення вектора на вектор(результатом є дробове число x1* y1 + x2* y2)
            public static double operator *(Vector2D a, Vector2D b)
            {
                double res = a.X * a.Y + b.X * b.Y;
                return res;
            }

            // * множення  вектора на скаляр(дробове число) (результатом  є вектор : (x1 *num, y1 * num))
            public static Vector2D operator *(Vector2D a, double num)
            {
                Vector2D res = new Vector2D();
                res.X = a.X * num;
                res.Y = a.Y * num;
                return res;
            }

            // перевизначити(override) метод ToString()
            public override string ToString()
            {
                return $"({X}, {Y})";
            }

            //==,  != операції порівняння двох векторів(попередньо перевизначити Equals(), GetHashCode(), використати Equals()) приведення типів
            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is Vector2D))
                    return false;
                Vector2D ob = obj as Vector2D;

                if (this.X == ob.X && this.Y == ob.Y)
                    return true;

                return false;
            }

            public override int GetHashCode()
            {
                return x.GetHashCode() ^ y.GetHashCode();

            }

            // ==
            public static bool operator ==(Vector2D a, Vector2D b)
            {
                if (Equals(a, b))
                    return true;

                if ((object)a == null)
                    return false;

                return a.Equals(b);
            }

            // !=
            public static bool operator !=(Vector2D a, Vector2D b)
            {
                return !(a == b);
            }

            //оператори true, false ( false - вектор(0;0), true - хоч одна координата не нуль)
            public static bool operator true(Vector2D obj)
            {
                return (obj.X != 0 || obj.Y != 0);
            }

            public static bool operator false(Vector2D obj)
            {
                return (obj.X == 0 && obj.Y == 0);
            }

            //неявне перетворення  від типу double до типу Вектор  (дробове число - х координата, 0 - у 		координата)
            public static implicit operator Vector2D(double d)
            {
                Vector2D res = new Vector2D(d, 0);
                return res;
            }

            //явне перетворення до типу double (повертати довжину  вектора)
            public static explicit operator double(Vector2D v)
            {
                return v.Length;
            }

            //++, --  збільшувати(зменшувати) обидві координати на 1
            // ++
            public static Vector2D operator ++(Vector2D obj)
            {
                Vector2D res = new Vector2D();
                res.X = obj.X + 1;
                res.Y = obj.Y + 1;
                return res;
            }

            // --
            public static Vector2D operator --(Vector2D obj)
            {
                Vector2D res = new Vector2D();
                res.X = obj.X - 1;
                res.Y = obj.Y - 1;
                return res;
            }

            //- унарний(змінювати знак обох координат вектора)
            public static Vector2D operator -(Vector2D obj)
            {
                Vector2D res = new Vector2D();
                res.X = -obj.X;
                res.Y = -obj.Y;
                return res;
            }

            // - одновимірний індексатор, який за індексом 0 повертає х -координату, за індексом  1 - у координату 	
            public double this[int index] 
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return X;
                        case 1:
                            return Y;
                        default:
                            return double.MinValue;
                    }
                }
                set
                {
                    if (index == 0)
                        X = value;
                    else
                        if (index == 1)
                        Y = value;

                }
            }


        }
        static void Main(string[] args)
        {
            Vector2D a = new Vector2D(1, 2);
            Vector2D b = new Vector2D(1, 3);
            Vector2D c = new Vector2D(1, 3);
            Vector2D d = new Vector2D(0, 0);

            Console.WriteLine($"{a} + {b} = {a + b }");
            Console.WriteLine($"{a} - {b} = {a - b }");
            Console.WriteLine($"{a} x {b} = {a * b }");
            Console.WriteLine($"{a} x 10 = {a * 10 }\n");

            if (a)
                Console.WriteLine($"bool\t{a} : True");
            else
                Console.WriteLine($"bool\t{a} : False");

            if (d)
                Console.WriteLine($"bool\t{d} : True");
            else
                Console.WriteLine($"bool\t{d} : False");

            if (a != b)
                Console.WriteLine($"!=\t{a} != {b} : {a != b }");
            else
                Console.WriteLine($"!=\t{a} != {b} : {a != b }");

            if (b == c)
                Console.WriteLine($"==\t{b} == {c} : {b == c }\n");
            else
                Console.WriteLine($"==\t{b} == {c} : {b == c }\n");

            double num = 3;
            a = (Vector2D)num;
            Console.WriteLine($"double --> vector\t{num} = {a}");
            num = (double)b;
            Console.WriteLine($"vector --> double\t{b} = {num}\n");
            Console.WriteLine($"++\t{d} = {++d}");
            Console.WriteLine($"--\t{c} = {--c}");
            Console.WriteLine($"-\t{b} = {-b}\n");
            Console.WriteLine($"indexator get\tb{b} :\tb[0] = {b[0]};\tb[1] = {b[1]};\tb[2] = {b[2]};");
            Console.Write($"indexator set\tbefore a{a} :\t");
            Console.WriteLine($"a[0] = {a[0] = 1};\ta[1] = {a[1] = 2};\tafter a{a};\n");
            Console.WriteLine($"{a} += {b} = {a += b }");
            Console.WriteLine($"{b} -= {c} = {b -= c }");
            Console.WriteLine($"{a} *= {c} = {a *= c }");
            Console.ReadKey();

        }
    }
}
