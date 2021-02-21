using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.CompilationPipeline.Common.Diagnostics;

namespace Hertzole.ALE.CodeGen
{
    public class WeaverLogger
    {
        public List<DiagnosticMessage> diagnostics = new List<DiagnosticMessage>();

        public void LogError(string message)
        {
            AddMessage(message, null, DiagnosticType.Error);
        }

        public void LogError(string message, MethodReference mr)
        {
            LogError($"{message} (at {mr})");
        }

        public void LogError(string message, MethodDefinition mr)
        {
            AddMessage($"{message} (at {mr})", mr.DebugInformation.SequencePoints.FirstOrDefault(), DiagnosticType.Error);
        }

        public void LogError(string message, MethodDefinition mr, SequencePoint sequencePoint)
        {
            AddMessage($"{message} (at {mr})", sequencePoint, DiagnosticType.Error);
        }

        private void AddMessage(string message, SequencePoint sequencePoint, DiagnosticType type)
        {
            diagnostics.Add(new DiagnosticMessage
            {
                DiagnosticType = type,
                File = sequencePoint?.Document.Url.Replace($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}", ""),
                Line = sequencePoint?.StartLine ?? 0,
                Column = sequencePoint?.StartColumn ?? 0,
                MessageData = message
            });
        }
    }
}
