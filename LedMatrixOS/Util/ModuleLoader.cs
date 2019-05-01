using System;
using System.IO;
using System.Reflection;

namespace LedMatrixOS.Util
{
    public class ModuleLoader
    {
        public void LoadModules()
        {
            string[] files = Directory.GetFiles(Path.Join(Environment.CurrentDirectory, "Applications"));
            foreach (string file in files)
            {
                var fileInfo = new FileInfo(file);
                if (fileInfo.Extension != ".dll") continue;
                Assembly assembly = Assembly.LoadFile(fileInfo.FullName);
                var typeName = assembly.GetName().Name + ".MatrixMenuEntry";
                Type assemblyType = assembly.GetType(typeName);
                object obj = Activator.CreateInstance(assemblyType);

                FieldInfo nameField = assemblyType.GetField("Name");
                
                var name = nameField.GetValue(obj) as string;
                
                Console.WriteLine(name);
            }
        }
    }
}