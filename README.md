# Advanced Level Editor (ALE)
Advanced, but simple to use, runtime level editor for Unity.

⚠ **ALE IS VERY MUCH IN EARLY DEVELOPMENT! USE AT YOUR OWN RISK** ⚠

## ✅ TODO List
#### Required
What needs to be done before 1.0.0 verified.  
- [x] Binary serialization and deserialization
- [x] JSON serialization and deserialization
- [x] Unified serializer for binary and JSON
- [x] Editor camera
- [ ] Full 2D support
- [ ] Full 3D support
- [ ] Input System support
- [ ] Undo and redo
- [x] Hierarchy
- [ ] Hierarchy customization
- [x] Inspector
- [ ] Custom component fields
- [x] Resource browser
- [ ] Resource browser customization
- [ ] Level editor gizmos
- [ ] Play mode
- [x] Save all exposed values in play mode
- [ ] Auto serialize unknown types
- [ ] Auto expose unknown types
- [ ] Integrate custom serializers
- [ ] Menu items
- [ ] Custom component wrappers
- [ ] Serialize arrays

#### Optional
What would be really nice to have before 1.0.0 verified.  
- [ ] Orientation gizmos
- [ ] Scene grid
- [ ] Manipulation handles
- [ ] Adaptive editor GUI
- [ ] Clean up code
- [ ] Tilemap integration
- [ ] ProBuilder integration
- [ ] Multiselection support
- [ ] More errors and visuals to tell when something is wrong
- [ ] Custom component UGUI
- [ ] Unity mathematics support

#### Inspector fields
The supported inspector fields.  
- [x] Number fields
- [x] Text fields
- [x] Toggle field
- [x] Vector2(int) field
- [x] Vector3(int) field
- [ ] Vector4 field
- [x] Object reference field
- [x] Color field
- [ ] Arrays

## 📦 Installation 
#### Without package manager
To install it without the package manager, download the project as a zip file and extract it from the packages folder. From there, put the files either inside your assets folder or in your packages folder.
#### With package manager
Currently, only the development package is available. It's updated with each commit to the master branch.   

1. Open the package manager and click 'Add from Git url' in the top right corner
2. Paste in `https://github.com/Hertzole/gold-player.git#dev-package` and click enter
3. Wait an eternity for Unity to realize that you have installed the package.
4. It should now be installed. Either create it from scratch or import the "Complete" sample and modify that. I recommend the sample because it's currently quite a pain to set everything up...

## 🔨 Getting Started

⚠ **DOCUMENTATION IS EXTREMELY SPARSE RIGHT NOW AND WILL PROBABLY REMAIN SO FOR QUITE A WHILE** ⚠

#### Setup a level editor
If you've installed it through the package manager, I recommend importing the "Complete" sample and start modifying that.

//TODO: Finish setup guide  
Start by creating an empty object and add the `Level Editor` component. Then assign the required fields.

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
Unity Technologies/ProBuilder team - [GILES](https://github.com/Unity-Technologies/giles) for editor camera  
[judah4](https://github.com/judah4) - [HSV Color Picker](https://github.com/judah4/HSV-Color-Picker-Unity) for color picker  
The [MirrorNG team](https://github.com/MirrorNG) - Lots of weaving code from [MirrorNG](https://github.com/MirrorNG/MirrorNG)  
[paulpach](https://github.com/paulpach) - Helped me with weaver related questions

❤ Developed with love and support from [Limit Break Studio](https://main.limitbreakstudio.com/) ❤
