using MessagePack;
using UnityEngine;

[MessagePackObject]
public class MsgPackTest
{
	[Key(-10)]
	public int intTest;
	[Key(1)]
	public string stringTest;
	[Key(100)]
	public Vector3 vector3TesT;
}
