# Advanced Level Editor (ALE)

⚠ **ALE IS IN VERY EARLY DEVELOPMENT! ANYTHING CAN CHANGE SUDDENLY! USE AT YOUR OWN RISK** ⚠

## ❓ What is it?
ALE is a runtime level editor for Unity that aims to be simple to use both for the user and the developer. It's built with performance and usability in mind. It should also be extendable so you can adapt it to fit just right for your game.

ALE works on a "editor mode system" where each mode does it's own thing and you switch between them. Right now there is only the (very much WIP!) unified mode that tries to replicate Unity. You can create your own modes and add them as components on the level editor and the mode will just work. 

ALE also does some "magic" for you to simplify your life. It uses Mono.Cecil to do some code weaving and inject code into your assemblies to automate your workflow. This means it will be very performant since you can do stuff like exposing properties without reflection (which can be rather slow)! It also means that, in theory, ALE should work on ALL platforms, Mono and IL2CPP!

## ✨ The magic
As mentioned above, ALE does some "magic" for you. I've tried to avoid reflection as much as possible since it can be rather slow and instead opted to generate code during compile time, IL weaving if you will. The best example of this is the `ExposeToLevelEditor` attribute that injects `IExposeToLevelEditor` in your scripts.  
In the future, the same will magic will be applied to much more. It's coming eventually™.

## ✅ TODO List
ALE is still in EARLY development. There's still a lot to do and it's nowhere close to finish. But it should be useable now. Anyways, here are some things that I need to do and the things that are finished.
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
- [x] Integrate custom serializers
- [ ] Menu items
- [ ] Custom component wrappers
- [x] Serialize arrays
- [ ] Resource limit support
- [ ] Generate resource icons at build time

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
- [ ] XML documentation in code

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
- [ ] Nested classes/structs
- [ ] Enum field

## 📦 Installation 
#### Without package manager
To install it without the package manager, download the project as a zip file and extract it from the packages folder. From there, put the files either inside your assets folder or in your packages folder.
#### With package manager
Currently, only the development package is available. It's updated with each commit to the master branch.   

1. Open the package manager and click 'Add from Git url' in the top right corner
2. Paste in `https://github.com/Hertzole/advanced-level-editor.git#dev-package` and click enter
3. Wait an eternity for Unity to realize that you have installed the package.
4. It should now be installed. Either create it from scratch or import the "Complete" sample and modify that. I recommend the sample because it's currently quite a pain to set everything up...

## 🔨 Getting Started

⚠ **DOCUMENTATION IS VERY SPARSE RIGHT NOW AND WILL PROBABLY REMAIN SO FOR QUITE A WHILE** ⚠

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

#### Write custom writers and readers for serialization
To serialize values you need to have a writer and a reader that the serializer will use. You can create them easily by creating extension methods for `LevelEditorWriter` and `LevelEditorReader`. If you're familiar with creating serializers in Json.Net you'll probably be familiar with how to create these. 

```cs
// Writer extension needs to be first.
// The type and value needs to be second.
// String name needs to be third.
public static void MyWriter(this NetworkWriter writer, MyStruct value, string name)
{
	writer.WriteStartObject(name);
	writer.Write(value.MyValue);
	writer.WriteEndObject();
}

// Reader extension needs to be first.
// withName needs to be second. It's used to read the property name if needed.
// You need to return the type of the value you want to make a reader for.
public static MyStruct MyReader(this NetworkReader reader, bool withName)
{
	MyStruct myStruct = new MyStruct();
	reader.ReadStartObject(withName);
	myStruct.MyValue = reader.ReadString();
	reader.ReadEndObject();
	
	return myStruct;
}
```

## ❤ Credits
[yasirkula](https://github.com/yasirkula) - [Dynamic Panels for Unity3D](https://github.com/yasirkula/UnityDynamicPanels) for panels  
[yasirkula](https://github.com/yasirkula) - [Runtime Inspector & Hierarchy for Unity 3D](https://github.com/yasirkula/UnityRuntimeInspector) for tree control  
Unity Technologies/ProBuilder team - [GILES](https://github.com/Unity-Technologies/giles) for editor camera  
[judah4](https://github.com/judah4) - [HSV Color Picker](https://github.com/judah4/HSV-Color-Picker-Unity) for color picker  
The [MirrorNG team](https://github.com/MirrorNG) - Lots of weaving code from [MirrorNG](https://github.com/MirrorNG/MirrorNG)  
[paulpach](https://github.com/paulpach) - Helped me with weaver related questions

❤ Developed with love and support from [Limit Break Studio](https://main.limitbreakstudio.com/) ❤
