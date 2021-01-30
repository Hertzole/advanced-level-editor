using Hertzole.ALE;

public static class CustomWriters
{
    public static void WriteMyCustomStruct(this LevelEditorWriter writer, MyCustomStruct value, string name = "value")
    {
        writer.WriteStartObject(name);
        writer.Write(value.str, "str");
        writer.WriteEndObject();
    }

    public static MyCustomStruct ReadMyCustomStruct(this LevelEditorReader reader, bool withName)
    {
        reader.ReadObjectStart(withName);

        MyCustomStruct val = new MyCustomStruct
        {
            str = reader.ReadString()
        };
        reader.ReadObjectEnd();

        return val;
    }
}
