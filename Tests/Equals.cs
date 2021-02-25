using NUnit.Framework;

namespace Hertzole.ALE.Tests
{
    public class Equals
    {
        [Test]
        public void SaveDataEquals()
        {
            EqualTest(SerializationTest.BuildSaveData(), SerializationTest.BuildSaveData());
        }

        [Test]
        public void CustomDataEquals()
        {
            EqualTest(SerializationTest.BuildCustomData(), SerializationTest.BuildCustomData());
        }

        [Test]
        public void ObjectDataEquals()
        {
            EqualTest(SerializationTest.BuildObjectData(), SerializationTest.BuildObjectData());
        }

        [Test]
        public void ComponentDataEquals()
        {
            EqualTest(SerializationTest.BuildComponentData(), SerializationTest.BuildComponentData());
        }

        [Test]
        public void PropertyDataEquals()
        {
            EqualTest(SerializationTest.BuildPropertyData(), SerializationTest.BuildPropertyData());
        }

        private void EqualTest<T>(T a, T b)
        {
            Assert.AreEqual(a, b);
        }
    }
}
