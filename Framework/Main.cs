using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using Newtonsoft.Json;

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

            string path = Environment.CurrentDirectory + "\\..\\..\\..\\..\\Hotfix\\Program.cs";
            var tree = SyntaxFactory.ParseSyntaxTree(File.ReadAllText(path));
            var compilation = CSharpCompilation.Create("TestClsContent",
                new[] { tree },
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)).AddReferences(
                    // 这算是偷懒了吗？我把 .NET Core 运行时用到的那些引用都加入到引用了。
                    // 加入引用是必要的，不然连 object 类型都是没有的，肯定编译不通过。
                    AppDomain.CurrentDomain.GetAssemblies().Select(x => MetadataReference.CreateFromFile(x.Location)));

            using (MemoryStream stream = new MemoryStream()) {
                // 编译到内存流中
                var compileResult = compilation.Emit(stream);
                if (compileResult.Success) {
                    Assembly assembly = Assembly.Load(stream.GetBuffer());

                    var cls = assembly.GetType("Hotfix.Test");
                    var staticMethod = cls.GetMethod("StaticAdd", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
                    var result = staticMethod.Invoke(null, new object[] { 4 }).ToString();

                    Console.WriteLine(result);

                    var instance = cls.Assembly.CreateInstance("Hotfix.Test");
                    var instanceMethod = cls.GetMethod("InstanceAdd", BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);
                    result = instanceMethod.Invoke(instance, new object[] { 4 }).ToString();

                    Console.WriteLine(result);

                    string jsonPath = Environment.CurrentDirectory + "Json.json";
                    string json = JsonConvert.SerializeObject(instance, Formatting.Indented);
                    File.WriteAllText(jsonPath, json);
                    Console.WriteLine("Json = " + json);
                }
                else {
                    Console.WriteLine("编译失败");
                }
            }

            Console.ReadKey();
        }
    }
}