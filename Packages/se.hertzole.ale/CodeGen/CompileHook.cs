using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using Stopwatch = System.Diagnostics.Stopwatch;
using UAssembly = UnityEditor.Compilation.Assembly;

namespace Hertzole.ALE.Editor
{
    public static class CompileHook
    {
        private static readonly Stopwatch stopwatch = new Stopwatch();

        private const bool WEAVE_UNITY_ASSEMBLIES = false;

        [InitializeOnLoadMethod]
        public static void OnInitializeOnLoad()
        {
            CompilationPipeline.assemblyCompilationFinished += OnCompilationFinished;

            if (!SessionState.GetBool(WeaverConstants.WEAVED, false))
            {
                SessionState.SetBool(WeaverConstants.WEAVED, true);
                SessionState.SetBool(WeaverConstants.WEAVE_SUCCESS, true);

                WeaveAllAssemblies();
            }
        }

        public static void WeaveAllAssemblies()
        {
            foreach (UAssembly assembly in CompilationPipeline.GetAssemblies())
            {
                if (File.Exists(assembly.outputPath))
                {
                    OnCompilationFinished(assembly.outputPath, new CompilerMessage[0]);
                }
            }

#if UNITY_2019_3_OR_NEWER
            EditorUtility.RequestScriptReload();
#else
            UnityEditorInternal.InternalEditorUtility.RequestScriptReload();
#endif
        }

        private static bool CompilerMessagesHasError(CompilerMessage[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                if (messages[i].type == CompilerMessageType.Error)
                {
                    return true;
                }
            }

            return false;
        }

        private static void OnCompilationFinished(string assemblyPath, CompilerMessage[] messages)
        {
            LevelEditorLogger.Log($"OnCompileFinished | Is building player: {BuildPipeline.isBuildingPlayer}, Is Debug build: {Debug.isDebugBuild} | {assemblyPath}");

            stopwatch.Reset();

            stopwatch.Start();

            if (CompilerMessagesHasError(messages))
            {
                stopwatch.Stop();
                LevelEditorLogger.Log($"Weaving stopped due to errors. It took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
                return;
            }

            if (!WEAVE_UNITY_ASSEMBLIES && (assemblyPath.Contains("Unity.") || assemblyPath.Contains("UnityEngine.") || assemblyPath.Contains("UnityEditor.")))
            {
                stopwatch.Stop();
                LevelEditorLogger.Log($"Weaving stopped due to avoiding Unity assemblies. It took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
                return;
            }

            // Allow editors for now until further testing.
            if (assemblyPath.Contains("-Editor") || assemblyPath.Contains(".Editor"))
            {
                stopwatch.Stop();
                LevelEditorLogger.Log($"Weaving stopped due to editor assembly. It took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
                return;
            }

            // Don't weave itself.
            string assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);
            if (assemblyName == WeaverConstants.RUNTIME_ASSEMBLY || assemblyName == WeaverConstants.EDITOR_ASSEMBLY)
            {
                stopwatch.Stop();
                LevelEditorLogger.Log($"Weaving stopped due to finding itself. It took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
                return;
            }

            string runtimeAssembly = FindRuntimeAssembly();
            if (string.IsNullOrEmpty(runtimeAssembly))
            {
                Debug.LogError("Failed to find runtime assembly.");
                stopwatch.Stop();
                LevelEditorLogger.Log($"Weaving stopped due to errors. It took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
                return;
            }

            // This is normal.
            if (!File.Exists(runtimeAssembly))
            {
                stopwatch.Stop();
                return;
            }

            string unityCoreModule = UnityEditorInternal.InternalEditorUtility.GetEngineCoreModuleAssemblyPath();
            if (string.IsNullOrEmpty(unityCoreModule))
            {
                Debug.LogError("Failed to find UnityEngine assembly.");
                stopwatch.Stop();
                LevelEditorLogger.Log($"Weaving stopped due to errors. It took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
                return;
            }

            HashSet<string> dependencies = GetDependencies(assemblyPath);

            if (!Weaver.Process(unityCoreModule, runtimeAssembly, null, new[] { assemblyPath }, dependencies.ToArray()))
            {
                SessionState.SetBool(WeaverConstants.WEAVE_SUCCESS, false);
                Debug.LogError("Weaving failed for " + assemblyPath);
            }

            stopwatch.Stop();

            LevelEditorLogger.Log($"Weaving took {stopwatch.ElapsedMilliseconds}ms\nAssembly path: {assemblyPath}");
        }

        private static HashSet<string> GetDependencies(string assemblyPath)
        {
            HashSet<string> dependencies = new HashSet<string>
            {
                Path.GetDirectoryName(assemblyPath)
            };
            foreach (UAssembly assembly in CompilationPipeline.GetAssemblies())
            {
                if (assembly.outputPath != assemblyPath)
                {
                    continue;
                }

                foreach (string assemblyReference in assembly.compiledAssemblyReferences)
                {
                    dependencies.Add(Path.GetDirectoryName(assemblyReference));
                }
            }

            return dependencies;
        }

        private static string FindRuntimeAssembly()
        {
            foreach (UAssembly assembly in CompilationPipeline.GetAssemblies())
            {
                if (assembly.name == WeaverConstants.RUNTIME_ASSEMBLY)
                {
                    return assembly.outputPath;
                }
            }

            return string.Empty;
        }
    }
}
