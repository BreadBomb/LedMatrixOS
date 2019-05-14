using LedMatrixOSUtils;
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
                var programTypeName = assembly.GetName().Name + ".Program";
                Console.WriteLine(assembly.GetName().Name + ".menulogo.png");
                Stream imageStream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".menulogo.png");
                Type assemblyType = assembly.GetType(typeName);
                Type programAssemblyType = assembly.GetType(programTypeName);
                object obj = Activator.CreateInstance(assemblyType);
                object programObj = Activator.CreateInstance(programAssemblyType);

                FieldInfo nameField = assemblyType.GetField("Name");

                MethodInfo loadProgram = programAssemblyType.GetMethod("LoadProgramAsync");
                MethodInfo startProgram = programAssemblyType.GetMethod("StartProgram");
                MethodInfo updateProgram = programAssemblyType.GetMethod("UpdateProgram");

                PropertyInfo viewField = programAssemblyType.GetProperty("View");

                var name = nameField.GetValue(obj) as string;

                yield return new MenuEntry()
                {
                    Name = name,
                    Stream = imageStream,
                    ProgramInstance = programObj,
                    _View = viewField,
                    _LoadProgram = loadProgram,
                    _StartProgram = startProgram,
                    _UpdateProgram = updateProgram
                };
            }
        }
    }
}