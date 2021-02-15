using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetAssemblyInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareVersionWithCompareTo();

            CompareVersionWithOperator();
        }

        public static void CompareVersionWithCompareTo()
        {
            AssemblyName name = Assembly.GetExecutingAssembly().GetName();

            Version myVersion = name.Version;
            // myVersion : 1.0.0.0

            Version yourVersion = new Version("1.0.0.0");

            int compareResult = myVersion.CompareTo((object)yourVersion);
            // yourVersion : 2.0.0.0 -> -1
            // yourVersion : 0.1.0.0 -> 1
            // yourVersion : 1.0.0.0 -> 0

            if (compareResult > 0)
            {
                if (yourVersion == null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine("이후 버전");
                }
            }
            else if (compareResult < 0)
            {
                Console.WriteLine("이전 버전");
            }
            else
            {
                Console.WriteLine("같은 버전");
            }
        }

        public static void CompareVersionWithOperator()
        {
            AssemblyName name = Assembly.GetExecutingAssembly().GetName();

            Version myVersion = name.Version;
            // myVersion : 1.0.0.0

            Version yourVersion = new Version("1.0.0.0");

            if(myVersion != null || yourVersion != null)
            {
                // null check를 해주지 않고 비교하려 하면 ArgumentNullException이 발생한다.
                Console.WriteLine("null");
            }
            else if (myVersion < yourVersion)
            {
                Console.WriteLine("이후 버전");
            }
            else if (myVersion > yourVersion)
            {
                Console.WriteLine("이전 버전");
            }
            else
            {
                Console.WriteLine("같은 버전");
            }
        }
    }
}
