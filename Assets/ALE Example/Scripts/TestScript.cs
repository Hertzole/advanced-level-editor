using Hertzole.ALE;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [ExposeToLevelEditor(0, order = 10, visible = false)]
    public int FirstTestButLast { get; set; }
    [ExposeToLevelEditor(1)]
    public string Test { get; set; }
}
