using System;
using System.Reflection;

namespace Framework {
    public class FormInt2 {
        public int x;
        public int y;

        public FormInt2(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    internal class Program {
        // https://blog.csdn.net/WPwalter/article/details/80545207
        private static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            Assembly hotfix = Assembly.LoadFile(Environment.CurrentDirectory + "\\..\\..\\..\\..\\Hotfix\\bin\\Debug\\netcoreapp3.1\\Hotfix.dll");
            var hotfixMainType = hotfix.GetType("Hotfix.Program");
            var mainMethod = hotfixMainType.GetMethod("Main", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
            mainMethod.Invoke(null, new string[] {null });

            Console.WriteLine("Main end");

            Console.ReadKey();
        }
    }
}