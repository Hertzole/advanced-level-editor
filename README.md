# Advanced Level Editor (ALE) v2

⚠ **VERY IN PREVIEW** ⚠

This branch is for a brand new way ALE based on the new incremental generators instead of doing IL manipulation. Due to this, it will be re-written from scratch.

## Why a new version?

IL manipulation is hard. Like, *really* hard. Especially to get right with all the different edge cases. But with source/incremental generators, you just write normal C# and let the compiler handle all the IL generation itself. I don't need to think about IL optimizations or weird edge cases anymore. But due to the big difference that this re-write is, a whole new version that uses the new features to their fullest potential is the best course right now.

## Differences

There are some slight differences between v1 and v2 (other than that almost all features don't exist yet)

#### Exposed properties

Before:  
```cs
public class ExposedClass : MonoBehaviour
{
    [ExposeToLevelEditor(0)]
    public int intValue;
}
```

Now:  
```cs
[ExposedType] // new
public partial class ExposedClass : MonoBehaviour
{
    [ExposedVar(0)] // renamed to ExposedVar
    public int intValue;
}
```

## Development

1. Clone the project.
2. Open up the `Unity` folder in **at least** Unity 2022.2b1. The beta version is important due to it having support for incremental generators.
3. When opening the C# solution, make sure you can see the whole solution. If you can't see the `Generator` project, you're doing it wrong.
4. To update the generator after your changes, just build the `Generator` project and it should move the generator to the Unity project automatically.