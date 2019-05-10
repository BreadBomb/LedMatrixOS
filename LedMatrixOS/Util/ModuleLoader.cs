using LedMatrixOS.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LedMatrixOS.Util
{
    public class ModuleLoader
    {
        public IEnumerable<MenuEntry> LoadModules()
        {
            IList<MenuEntry> menuEntries = new List<MenuEntry>();

            string[] files = Directory.GetFiles(Path.Join(Environment.CurrentDirectory, "Applications"));
            foreach (string file in files)
            {
                var fileInfo = new FileInfo(file);
                if (fileInfo.Extension != ".dll") continue;
                Assembly assembly = Assembly.LoadFile(fileInfo.FullName);
                var typeName = assembly.GetName().Name + ".MatrixMenuEntry";
                Console.WriteLine(assembly.GetName().Name + ".menulogo.png");
                Stream imageStream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".menulogo.png");
                Type assemblyType = assembly.GetType(typeName);
                object obj = Activator.CreateInstance(assemblyType);

                FieldInfo nameField = assemblyType.GetField("Name");
                
                var name = nameField.GetValue(obj) as string;

                yield return new MenuEntry()
                {
                    Name = name,
                    Stream = imageStream
                };
            }
        }
    }
}