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

            Console.Write("Kaç adet Zil Olacak: ");
            int Count = Int32.Parse(Console.ReadLine());

            Bell_Prop[] Ring_Hours = new Bell_Prop[Count];
            for (int i = 0; i<Count; i++)
            {
                Console.Write("\n\n"+(i+1)+ ". Zil İçin \nSaat : ");
                int value1 = Int32.Parse(Console.ReadLine());
                while(value1<0 || value1 > 24)
                {
                    Console.Write("Hatalı giriş yaptınız lütfen tekrar giriniz: ");
                    value1 = Int32.Parse(Console.ReadLine());
                }
                Console.Write("Dakika : ");
                int value2 = Int32.Parse(Console.ReadLine());
                while (value2<0 || value2>60)
                {
                    Console.Write("Hatalı giriş yaptınız lütfen tekrar giriniz: ");
                    value2 = Int32.Parse(Console.ReadLine());
                }
                Ring_Hours[i] = new Bell_Prop(value1,value2);
            }

            int temp3 = -1;
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
                                    if(DateTime.Now.Second != temp3)
                                    {
                                        Console.WriteLine("Zil Çaldı Herkes Sınıfaa");
                                        temp3 = DateTime.Now.Second;
                                    }
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
