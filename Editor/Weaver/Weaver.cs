using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Hertzole.ALE.Editor
{
    public static partial class Weaver
    {
        public static bool WeaveAssembly(string assemblyPath, string unityEngine, string runtimeAssembly, params string[] searchPaths)
        {
            using (DefaultAssemblyResolver asmResolver = new DefaultAssemblyResolver())
            {
                using (AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyPath, new ReaderParameters { ReadWrite = true, ReadSymbols = true, AssemblyResolver = asmResolver }))
                {
                    asmResolver.AddSearchDirectory(unityEngine);
                    asmResolver.AddSearchDirectory(runtimeAssembly);

                    for (int i = 0; i < searchPaths.Length; i++)
                    {
                        asmResolver.AddSearchDirectory(searchPaths[i]);
                    }

                    (bool success, bool dirty) = ProcessAssembly(assembly);
                    if (success && dirty)
                    {
                        WriterParameters writeParams = new WriterParameters { WriteSymbols = true };
                        assembly.Write(writeParams);
                    }

                    return success;
                }
            }
        }

        private static bool WeaveAssemblies(string[] assemblies, string unityEngine, string runtimeAssembly, string[] dependencies)
        {
            try
            {
                foreach (string asm in assemblies)
                {
                    if (!WeaveAssembly(asm, unityEngine, runtimeAssembly, dependencies))
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
            return true;
        }

        public static bool Process(string unityAssembly, string runtimeAssembly, string output, string[] assemblies, string[] extraAssemblyPaths)
        {
            Validate(unityAssembly, runtimeAssembly, output, assemblies);

            return WeaveAssemblies(assemblies, unityAssembly, runtimeAssembly, extraAssemblyPaths);
        }

        private static void Validate(string unityEngine, string netDLL, string outputDirectory, string[] assemblies)
        {
            CheckDllPath(unityEngine);
            CheckDllPath(netDLL);
            CheckOutputDirectory(outputDirectory);
            CheckAssemblies(assemblies);
        }

        private static void CheckDllPath(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("dll could not be located at " + path + ".");
            }
        }

        private static void CheckAssemblies(IEnumerable<string> assemblyPaths)
        {
            foreach (string assemblyPath in assemblyPaths)
            {
                CheckAssemblyPath(assemblyPath);
            }
        }

        private static void CheckAssemblyPath(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
            {
                throw new Exception("Assembly " + assemblyPath + " does not exist.");
            }
        }

        private static void CheckOutputDirectory(string outputDir)
        {
            if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
        }
    }
}
