using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace pr_32_prakt15_5_OAP_ZhuravlevTimofeyVasilievich
{
    class Program
    {
        public struct people
        {
            public string f;
            public string i;
            public string o;
            public int age;
            public float massa;
        }

        public class Sort : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                people t1 = (people)x;
                people t2 = (people)y;
                if (t1.age > t2.age) return 1;
                if (t1.age < t2.age) return -1;
                return 0;
            }
        }

        static void ArrayPrint(string s, ArrayList a)
        {
            Console.WriteLine(s);
            foreach (people x in a)
                Console.WriteLine(x.f + "\t" + x.i + "\t" + x.o + "\t" + x.age + "\t" + x.massa);
        }

        static void Main(string[] args)
        {
            StreamReader fileIn = new StreamReader("t.txt", Encoding.GetEncoding(1251));
            string line;
            people a;
            ArrayList people = new ArrayList();
            string[] temp = new string[5];
            while ((line = fileIn.ReadLine()) != null)
            {
                temp = line.Split(' ');
                a.f = temp[0];
                a.i = temp[1];
                a.o = temp[2];
                a.age = int.Parse(temp[3]);
                a.massa = float.Parse(temp[4]);
                people.Add(a);
            }
            fileIn.Close();
            people.Sort(new Program.Sort());
            ArrayPrint("Отсортированные данные: ", people);
            Console.ReadLine();
        }
    }
}