
using Newtonsoft.Json;

using System;
using System.IO;
using System.Reflection;

using UnityEngine;

namespace Hotfix {
    public class UIMgr {
        public static void Open(string uiName) {
            Debug.LogError("UImgr.Open: " + uiName);
        }
        public static void Close(string uiName) {
            Debug.LogError("UImgr.Close: " + uiName);
        }
    }

    public class FormInt3 {
        public int x;
        public int y;
        public int z;

        public FormInt3(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public class Program {
        public static void Main(string[] args) {
            // string path = Environment.CurrentDirectory + "\\..\\..\\..\\..\\HotfixUI\\Program.cs";
            //var tree = SyntaxFactory.ParseSyntaxTree(File.ReadAllText(path));
            //var compilation = CSharpCompilation.Create("TestClsContent",
            //    new[] { tree },
            //    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)).AddReferences(
            //        // 这算是偷懒了吗？我把 .NET Core 运行时用到的那些引用都加入到引用了。
            //        // 加入引用是必要的，不然连 object 类型都是没有的，肯定编译不通过。
            //        AppDomain.CurrentDomain.GetAssemblies().Select(x => MetadataReference.CreateFromFile(x.Location)));

            //using (MemoryStream stream = new MemoryStream())
            //{
            //    // 编译到内存流中
            //    var compileResult = compilation.Emit(stream);
            //    if (compileResult.Success)
            //    {
            //        Assembly assembly = Assembly.Load(stream.GetBuffer());

            //        var cls = assembly.GetType("Hotfix.Test");
            //        var staticMethod = cls.GetMethod("StaticAdd", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
            //        var result = staticMethod.Invoke(null, new object[] { 4 }).ToString();

            //        Console.WriteLine(result);

            //        var instance = cls.Assembly.CreateInstance("Hotfix.Test");
            //        var instanceMethod = cls.GetMethod("InstanceAdd", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
            //        result = instanceMethod.Invoke(instance, new object[] { 4 }).ToString();

            //        Console.WriteLine(result);

            //        string jsonPath = Environment.CurrentDirectory + "Json.json";
            //        string json = JsonConvert.SerializeObject(instance, Formatting.Indented);
            //        File.WriteAllText(jsonPath, json);
            //        Console.WriteLine("Json = " + json);
            //    }
            //    else
            //    {
            //        Console.WriteLine("编译失败");
            //    }
            //}

            // 热更工程中，引用了著工程中没有引用的a.dll., 那么此时即使在著工程中Assembly.load这个a.dll，也不会让著工程在反射执行热更工程的时候正常，因为热更引用的a.dll
            // 没有被clr正确识别
            //string path = Environment.CurrentDirectory + "\\..\\..\\..\\..\\HotfixUI\\Deps\\UnityEngine.CoreModule.dll";
            //Assembly assembly = Assembly.LoadFile(path);

            string path = Environment.CurrentDirectory + "\\..\\..\\..\\..\\HotfixUI\\bin\\Debug\\netcoreapp3.1\\HotfixUI.dll";
            Assembly assembly = Assembly.LoadFile(path);

            var cls = assembly.GetType("HotfixUI.Program");
            var staticMethod = cls.GetMethod("Main", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
            staticMethod.Invoke(null, new string[] { null});
        }
    }
}