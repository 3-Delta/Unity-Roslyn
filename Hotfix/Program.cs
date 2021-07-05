using System;
using System.Collections.Generic;

//using UnityEngine;

namespace Hotfix {
    public class Test {
        public int a;
        public float fl;
        public List<string> strs = new List<string>() { "qwe", "rty" };

        public Test() {
            a = 3;
            fl = 1f;
        }

        public static int StaticAdd(int b) {
            return 2 + b;
        }

        public int InstanceAdd(int b) {
            //Vector2 v2 = new Vector2(1, 4);
            //Console.WriteLine(v2);

            return a + b;
        }
    }

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}