using Hertzole.ALE;
using System.Collections.Generic;
using UnityEngine;

public class SetTypesTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IExposedToLevelEditor exposed = GetComponent<IExposedToLevelEditor>();
        exposed.OnValueChanged += OnValueChanged;

        bool notify = true;

        exposed.SetValue(0, "New string", notify);
        exposed.SetValue(1, 42, notify);
        exposed.SetValue(2, Color.green, notify);
        exposed.SetValue(3, new Color32(255, 255, 0, 255), notify);
        exposed.SetValue(4, new Vector3(12, 13, 14), notify);
        exposed.SetValue(5, transform, notify);
        exposed.SetValue(6, new SimpleClass() { value = "A modified string" }, notify);
        exposed.SetValue(7, new AdvancedClass() { value = "A newly modified string" }, notify);
        exposed.SetValue(8, new SimpleStruct() { value = "Structure string" }, notify);
        exposed.SetValue(0, new AdvancedStruct() { value = "Advanced string" }, notify);
        exposed.SetValue(10, new SimpleClass[] { new SimpleClass() { value = "Heck" } }, notify);
        exposed.SetValue(11, new SimpleStruct[] { new SimpleStruct() { value = "Heck" } }, notify);
        exposed.SetValue(12, new List<AdvancedClass> { new AdvancedClass() { value = "Heck" } }, notify);
        exposed.SetValue(13, new Dictionary<string, int> { { "lol", 42 } }, notify);

        exposed.SetValue(14, "Newer string", notify);
        exposed.SetValue(15, 43, notify);
        exposed.SetValue(16, Color.red, notify);
        exposed.SetValue(17, new Color32(0, 255, 0, 255), notify);
        exposed.SetValue(18, new Vector3(13, 14, 15), notify);
        exposed.SetValue(19, null, notify);
        exposed.SetValue(20, new SimpleClass() { value = "A modified string that is even newer" }, notify);
        exposed.SetValue(21, new AdvancedClass() { value = "A newly modified string, wow!" }, notify);
        exposed.SetValue(22, new SimpleStruct() { value = "Structure string :o" }, notify);
        exposed.SetValue(23, new AdvancedStruct() { value = "Advanced string ;)" }, notify);
        exposed.SetValue(24, new SimpleClass[] { new SimpleClass() { value = "Hecker" } }, notify);
        exposed.SetValue(25, new SimpleStruct[] { new SimpleStruct() { value = "Hecks" } }, notify);
        exposed.SetValue(26, new List<AdvancedClass> { new AdvancedClass() { value = "Deck" } }, notify);
        exposed.SetValue(27, new Dictionary<string, int> { { "lul", 42 } }, notify);
    }

    private void OnValueChanged(int arg1, object arg2)
    {
        Debug.Log($"{arg1} changed value to {arg2}");

        if (arg2 is IDictionary<string, int> dic)
        {
            Debug.Log(dic.ToDebugString());
        }
    }
}
