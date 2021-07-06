using System;
using System.Collections.Generic;

using Framework;

using Hotfix;

using UnityEngine;

namespace HotfixUI {
    public class Test {
        public int a;
        public float fl;
        public List<string> strList = new List<string>() { "qwe", "rty" };
        //public List<FormInt2> formList = new List<FormInt2>() { new FormInt2(6, 6), new FormInt2(9, 9) };

        public Test() {
            a = 3;
            fl = 1f;
            //formList.Add(new FormInt2(8, 8));
        }

        public static int StaticAdd(int b) {
            return 2 + b;
        }

        public int InstanceAdd(int b) {
            Vector2 v2 = new Vector2(1, 4);
            Console.WriteLine("框架层 引用的 当前工程引用的 类型： " + v2.x.ToString());

            Hotfix.UIMgr.Open("UITask");
            return a + b;
        }
    }

    public class Program {
        // 将Hotfix弄成工程，并且非库，还有Main函数，主要是为了模拟Unity下热更层的环境， 同时为了独立热更工程可以快速模块测试，所以提供main函数
        public static void Main(string[] args) {
            Test t = new Test();
            int rlt = t.InstanceAdd(4);

            Console.WriteLine("HotfixUI: " + rlt);

            Console.ReadKey();
        }
    }
}