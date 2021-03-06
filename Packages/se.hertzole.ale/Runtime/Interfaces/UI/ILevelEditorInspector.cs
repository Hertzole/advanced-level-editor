﻿using System;
using UnityEngine;

namespace Hertzole.ALE
{
    public interface ILevelEditorInspector
    {
        void Initialize(ILevelEditorUI ui);

        void BindObject(ILevelEditorObject target);

        LevelEditorInspectorField GetField(Type fieldType, Transform parent);

        void PoolField(LevelEditorInspectorField field);

        bool HasField(Type type);
    }
}
