namespace Hertzole.ALE
{
    //TODO: IEquatable
    public struct LevelEditorComponentData
    {
        public string type;
        public LevelEditorPropertyData[] properties;

        public LevelEditorComponentData(IExposedToLevelEditor exposed)
        {
            type = exposed.TypeName;
            ExposedProperty[] exposedProperties = exposed.GetProperties();
            properties = new LevelEditorPropertyData[exposedProperties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i] = new LevelEditorPropertyData(exposedProperties[i], exposed);
            }
        }
    }
}
