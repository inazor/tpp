using System;

namespace Vjezba1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Zadatak1();
            new Zadatak2();
            new Zadatak3();
            new Zadatak4();
            new Zadatak5();
            new Zadatak6();
            new Zadatak7();
            new Zadatak8();
            new Zadatak9();
            new Zadatak10();
            new Zadatak11();
            new Zadatak12();
            new Zadatak13();
            new Zadatak14();
            new Zadatak15_16_17_18();
            new Zadatak19();
            new Zadatak20();
            new SamostalniZadatak();
        }

        class Zadatak1
        {
            public Zadatak1()
            {
                Console.WriteLine("Hello World");
            }
        }

        class Zadatak2
        {
            public Zadatak2()
            {
                int variable = 5;
                const float Constant = 3.14f;

                variable = 6;
                //Constant = 4;
            }
        }

        class Zadatak3
        {
            public Zadatak3()
            {
                int variable = 5;
                const float Constant = 3.14f;

                Console.WriteLine("Variable:{0}, constant:{1}", variable, Constant);
            }
        }

        class Zadatak4
        {
            public Zadatak4()
            {
                int integerVariable = 5;
                long longIntegerVariable = 10;
                string stringVariable = "a";

                longIntegerVariable = integerVariable;
                //integerVariable = longIntegerVariable;
                //stringVariable = integerVariable;
            }
        }

        class Zadatak5
        {
            public Zadatak5()
            {
                int integerVariable = 257;
                byte byteVariable = 6;

                byteVariable = (byte)integerVariable;
                Console.WriteLine("byteVariable:{0}", byteVariable);
            }
        }

        class Zadatak6
        {
            public Zadatak6()
            {
                float a = 3;
                float b = 4;
                Console.WriteLine("a + b:  {0} + {1} = {2}", a, b, a + b);
                Console.WriteLine("a - b:  {0} - {1} = {2}", a, b, a - b);
                Console.WriteLine("a * b:  {0} * {1} = {2}", a, b, a * b);
                Console.WriteLine("a / b:  {0} / {1} = {2}", a, b, a / b);
                Console.WriteLine("a % b:  {0} % {1} = {2}", a, b, a % b);
            }
        }

        class Zadatak7
        {
            public Zadatak7()
            {
                float a = 3;
                float b = 4;
                Console.WriteLine("a == b:  {0} == {1} = {2}", a, b, a == b);
                Console.WriteLine("a != b:  {0} != {1} = {2}", a, b, a != b);
                Console.WriteLine("a >  b:  {0} >  {1} = {2}", a, b, a > b);
                Console.WriteLine("a >= b:  {0} >= {1} = {2}", a, b, a >= b);
                Console.WriteLine("a <  b:  {0} <  {1} = {2}", a, b, a < b);
                Console.WriteLine("a <= b:  {0} <= {1} = {2}", a, b, a <= b);
            }
        }

        class Zadatak8
        {
            public Zadatak8()
            {
                bool a = true;
                bool b = false;
                Console.WriteLine("a && b:  {0} && {1} = {2}", a, b, a && b);
                Console.WriteLine("a || b:  {0} || {1} = {2}", a, b, a || b);
                Console.WriteLine("!a:      !{0} = {1}", a, !a);
            }
        }

        class Zadatak9
        {
            public Zadatak9()
            {
                int a = 0b10;
                int b = 0b100;
                Console.WriteLine("a & b:  {0} & {1} = {2}", a, b, a & b);
                Console.WriteLine("a | b:  {0} | {1} = {2}", a, b, a | b);
            }
        }

        class Zadatak10
        {
            public Zadatak10()
            {
                string[] words = new string[4];

                words[0] = "Hello";
                words[1] = ",";
                words[2] = "world";

                Console.WriteLine("First Word: {0}", words[0]);
            }
        }

        class Zadatak11
        {
            enum Statusi { Redovni = 1, Izvanredni = 2 }
            public Zadatak11()
            {
                Statusi prviStatus = Statusi.Redovni;
                Console.WriteLine("Prvi Status: {0}", prviStatus);

                string nazivStatusa = "Izvanredni";

                var drugiStatus = (Statusi)Enum.Parse(typeof(Statusi), nazivStatusa);
                Console.WriteLine("Drugi Status: {0}", drugiStatus);

                var treciStatus = 1;
                Console.WriteLine("Treći Status: {0}", (Statusi)treciStatus);
            }
        }

        class Zadatak12
        {
            public Zadatak12()
            {
                var temp = 20;

                if (temp < 0)
                {
                    Console.WriteLine("Temperatura je: {0}, Hladno", temp);
                }
                else if (temp < 20)
                {
                    Console.WriteLine("Temperatura je: {0}, Ugodno", temp);
                }
                else
                {
                    Console.WriteLine("Temperatura je: {0}, Vruće", temp);
                }
            }
        }

        class Zadatak13
        {
            public Zadatak13()
            {
                var temp = 20;

                // uvjetni operator  ? :
                var opisno = temp < 0 ? "Hladno" : temp < 20 ? "Ugodno" : "Vruće";
                Console.WriteLine("Temperatura je {0}", opisno);

            }
        }

        class Zadatak14
        {
            public Zadatak14()
            {
                var godina = 1;
                switch (godina)
                {
                    case 1:
                        Console.WriteLine("Prva godina");
                        break;
                    case 2:
                        Console.WriteLine("Druga godina");
                        break;
                    default:
                        break;
                }
            }
        }

        class Zadatak15_16_17_18
        {
            public interface IOsoba
            {
                string KakoSeZove();
            }

            public class Osoba : IOsoba
            {
                public string Ime;
                public Osoba(string ime)
                {
                    this.Ime = ime;
                }
                public string KakoSeZove()
                {
                    return this.Ime;
                }
            }

            public Zadatak15_16_17_18()
            {
                Osoba Ivo = new Osoba("Ivo");
                Console.WriteLine(Ivo.KakoSeZove());
            }
        }

        class Zadatak19
        {
            public class Programer : Zadatak15_16_17_18.Osoba
            {
                public int GodineIskustva;

                public Programer(string ime, int godineIskustva) : base(ime)
                {
                    this.GodineIskustva = godineIskustva;
                }
            }


            public Zadatak19()
            {
                Programer Ivo = new Programer("Ivo", 4);
                Console.WriteLine($"Programer {Ivo.KakoSeZove()} ima {Ivo.GodineIskustva} godina iskustva.");
            }
        }

        class Zadatak20
        {
            public Zadatak20()
            {
                Console.WriteLine("Unos:");
                string ulaz = Console.ReadLine();
                Console.WriteLine(ulaz);
            }
        }

        class SamostalniZadatak
        {
            public class Djelatnik : Zadatak15_16_17_18.Osoba
            {
                public double Placa;
                public Djelatnik(string ime, double placa) : base(ime)
                {
                    Placa = placa;
                }

                public string OpisPlace()
                {
                    if (Placa > 8000)
                    {
                        return $"Djelatnik {Ime} ima veliku plaću.";
                    }
                    else
                    {
                        return $"Djelatnik {Ime} ima malu plaću.";
                    }
                }
            }

            public SamostalniZadatak()
            {
                Console.WriteLine("Ime:");
                string ime = Console.ReadLine();
                Console.WriteLine("Plaća (decimalni broj):");
                double placa = Double.Parse(Console.ReadLine());

                var djelatnik = new Djelatnik(ime, placa);
                Console.WriteLine(djelatnik.OpisPlace());
            }
        }
    }
}