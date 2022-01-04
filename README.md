# Advanced Level Editor (ALE)

![tests](https://github.com/Hertzole/advanced-level-editor/actions/workflows/test.yml/badge.svg) 
![build](https://github.com/Hertzole/advanced-level-editor/actions/workflows/build.yml/badge.svg) 
![dev package](https://github.com/Hertzole/advanced-level-editor/actions/workflows/dev_package.yml/badge.svg) 
![release package](https://github.com/Hertzole/advanced-level-editor/actions/workflows/release_package.yml/badge.svg) 

⚠ **ALE IS IN VERY EARLY DEVELOPMENT! ANYTHING CAN CHANGE SUDDENLY! USE AT YOUR OWN RISK** ⚠

![Built level editor](https://i.imgur.com/KXStiWT.png)
*Image is what ALE currently looks like. Will get periodically updated along with ALE. Keep in mind everything is a work in progress!*

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
- [x] JSON serialization and deserialization ([see note](https://hertzole.github.io/advanced-level-editor/docs/serialization/json-serialization))
- [x] Unified serializer for binary and JSON
- [x] Editor camera
- [ ] Full 2D support
- [ ] Full 3D support
- [x] Input System support
- [ ] Undo and redo
- [x] Hierarchy
- [ ] Hierarchy customization
- [x] Inspector
- [x] Custom component fields
- [x] Resource browser
- [ ] Resource browser customization
- [x] Level editor gizmos
- [x] Play mode
- [x] Save all exposed values in play mode
- [x] Auto serialize unknown types³
- [ ] Auto expose unknown types
- [x] Integrate custom serializers
- [ ] Menu items
- [ ] Add component menus
- [x] Fast enter play mode support
- [x] Custom component wrappers
- [x] Serialize arrays¹
- [x] Serialize lists¹
- [ ] Serialize dictionary²
- [ ] Resource limit support

#### Optional
What would be really nice to have before 1.0.0 verified.  
- [ ] Orientation gizmos
- [ ] Scene grid
- [x] Manipulation handles
- [ ] Adaptive editor GUI
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
- [ ] Vector4/Quaternion field
- [x] Object reference field
- [ ] Resource reference field
- [x] Color field
- [ ] Array field
- [ ] Nested classes/structs
- [x] Enum field

¹ Doesn't work 100% with Unity objects yet. **May appear to work during runtime but most likely won't work in build!**  
² While technically it will serialize dictionaries, it won't serialize exposed field dictionaries.  
³ It will automatically serialize structs but not classes.

## 📦 Installation 

See the [documentation for installation](https://hertzole.github.io/advanced-level-editor/docs/getting-started/installation).

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

#### Draw level editor gizmos
You can draw gizmos at runtime in the level editor very easily using interfaces.
```cs
public class MyScript : MonoBehaviour, ILevelEditorGizmos, ILevelEditorSelectedGizmos
{
	// Always drawing
    public void DrawLevelEditorGizmos(ILevelEditorGizmosDrawer drawer)
    {
        // Start, end, color
        drawer.DrawLine(Vector3.zero, Vector3.one, Color.red);
        // Center, size, rotation, color
        drawer.DrawWireCube(Vector3.zero, Vector3.one, new Vector3(0, 45, 0), Color.magenta);
    }
	
	// Only drawing when selected
	public void DrawLevelEditorGizmosSelected(ILevelEditorGizmosDrawer drawer)
	{
		// Center, size, rotation, color
		drawer.DrawSquare(Vector3.zero, new Vector2(1, 1), Quaternion.identity, Color.blue);
	}
}
```

## 📃 License
ALE itself is licensed under MIT. However, it contains some code that is under Unity's own license. As long as you use ALE within Unity, you're good to go.

## ❤ Credits
[yasirkula](https://github.com/yasirkula) - [Dynamic Panels for Unity3D](https://github.com/yasirkula/UnityDynamicPanels) for panels  
[yasirkula](https://github.com/yasirkula) - [Runtime Inspector & Hierarchy for Unity 3D](https://github.com/yasirkula/UnityRuntimeInspector) for tree control  
Unity Technologies/ProBuilder team - [GILES](https://github.com/Unity-Technologies/giles) for editor camera  
[judah4](https://github.com/judah4) - [HSV Color Picker](https://github.com/judah4/HSV-Color-Picker-Unity) for color picker  
[Mirage team](https://github.com/MirageNet) - Lots of weaving code from [Mirage](https://github.com/MirageNet/Mirage)  
[paulpach](https://github.com/paulpach) - Helped me with weaver related questions  
[Yoshifumi Kawai](https://github.com/neuecc) - [MessagePack for C#](https://github.com/neuecc/MessagePack-CSharp) for serialization  
[HiddenMonk](https://github.com/HiddenMonk) - [Unity3DRuntimeTransformGizmo](https://github.com/HiddenMonk/Unity3DRuntimeTransformGizmo) for runtime handles

❤ Developed with love and support from [Aurora Punks](https://www.aurorapunks.com/) ❤
