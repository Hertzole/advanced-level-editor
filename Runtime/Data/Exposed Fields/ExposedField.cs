namespace Hertzole.ALE
{
    public class ExposedField
    {
        public string Name { get; private set; }
        public bool IsVisible { get; private set; }

        public ExposedField(string name, bool isVisible)
        {
            Name = name;
            IsVisible = isVisible;
        }
    }
}
