using System;
using System.Collections.Generic;

namespace Okul_Zili_Uygulaması
{
    class Bell_Prop
    {
        public int Hour;
        public int Minute;

        public Bell_Prop(int a,int b)
        {
            this.Hour = a;
            this.Minute = b;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Kaç adet Zil Olacak: ");
            int Count = Int32.Parse(Console.ReadLine());

            Bell_Prop[] Ring_Hours = new Bell_Prop[Count];
            for (int i = 0; i<Count; i++)
            {
                Console.Write("\n\n"+(i+1)+ ". Zil İçin \nSaat : ");
                int value1 = Int32.Parse(Console.ReadLine());
                Console.Write("Dakika : ");
                int value2 = Int32.Parse(Console.ReadLine());
                Ring_Hours[i] = new Bell_Prop(value1,value2);
            }

            DateTime temp = DateTime.Now,temp2 = DateTime.Now;
            while (true)
            {
                if (temp.Second != temp2.Second)
                {

                    foreach (Bell_Prop var in Ring_Hours)
                    {
                        if (var.Hour == DateTime.Now.Hour)
                        {
                            if (var.Minute == temp.Minute && temp.Second == 0)
                            {
                                while ((DateTime.Now.Second-5)<temp.Second )
                                {
                                    Console.WriteLine("Zil Çaldı Herkes Sınıfaa");
                                }
                                break;
                            }
                        }
                    }

                    Console.Clear();
                    Console.WriteLine(temp);
                    temp2 = temp;
                }
                temp = DateTime.Now;

            }
        }
    }
}
