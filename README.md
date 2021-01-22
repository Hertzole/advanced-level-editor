# Advanced Level Editor (ALE)
Advanced, but simple to use, runtime level editor for Unity.

⚠ **ALE IS VERY MUCH IN EARLY DEVELOPMENT! USE AT YOUR OWN RISK** ⚠

## ✅ TODO List
#### Required
- [ ] Binary serialization and deserialization
- [ ] JSON serialization and deserialization
- [ ] Full 2D support
- [ ] Full 3D support
- [ ] Input System support
- [ ] Undo and redo
- [ ] Hierarchy
- [x] Inspector
- [ ] Resource browser
- [ ] Scene gizmos

#### Optional
- [ ] Scene grid
- [ ] Manipulation handles
- [ ] Adaptive editor GUI
- [ ] Clean up code
- [ ] Tilemap integration
- [ ] ProBuilder integration
- [ ] Multiselection support

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
