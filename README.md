# Advanced Level Editor (ALE)
Advanced, but simple to use, runtime level editor for Unity.

⚠ **ALE IS VERY MUCH IN EARLY DEVELOPMENT! USE AT YOUR OWN RISK** ⚠

## 🎇 Features
- Runtime level editor for your game
- Save and load
- Scene tree/hierarchy, inspector and resource browser
- Expose fields/properties using attributes
- *Should* support all platforms, both Mono and IL2CPP
- Supports fast enter play mode
- Extendable to suit your needs

## 🔨 Getting Started
#### Setup a level editor
TODO
#### Expose a field to the level editor
To expose a field or property to the level editor, you simply do  
```cs
[ExposeToLevelEditor(0)]
public float myField;
[ExposeToLevelEditor(1)]
public string MyProperty { get; set; }
```
**NOTICE! The IDs need to be unique and they are used for saving levels and fetching values! You should not change these after creating your exposed field!**

## ❤ Credits
[yasirkula](https://github.com/yasirkula) - [Dynamic Panels for Unity3D](https://github.com/yasirkula/UnityDynamicPanels) for panels  
[yasirkula](https://github.com/yasirkula) - [Runtime Inspector & Hierarchy for Unity 3D](https://github.com/yasirkula/UnityRuntimeInspector) for tree control

❤ Developed with love and support from [Limit Break Studio](https://main.limitbreakstudio.com/) ❤
