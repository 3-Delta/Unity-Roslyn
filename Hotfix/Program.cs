using System;
using System.Collections.Generic;

using Framework;

//using UnityEngine;

namespace Hotfix {
    public class Test {
        public int a;
        public float fl;
        public List<string> strList = new List<string>() { "qwe", "rty" };
        public List<FormInt2> formList = new List<FormInt2>() { new FormInt2(6, 6), new FormInt2(9, 9) };

        public Test() {
            a = 3;
            fl = 1f;
            formList.Add(new FormInt2(8, 8));
        }

        public static int StaticAdd(int b) {
            return 2 + b;
        }

        public int InstanceAdd(int b) {
            //Vector2 v2 = new Vector2(1, 4);
            //Console.WriteLine(v2.x.ToString());

            return a + b;
        }
    }

    class Program {
        // 将Hotfix弄成工程，并且非库，还有Main函数，主要是为了模拟Unity下热更层的环境， 同时为了独立热更工程可以快速模块测试，所以提供main函数
        static void Main(string[] args) {
            int rlt = new Test().InstanceAdd(4);

            Console.WriteLine("Hotfix: " + rlt);

            Console.ReadKey();
        }
    }
}