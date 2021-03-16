using Hertzole.ALE;
using UnityEngine;

public class TintObject : MonoBehaviour
{
    [SerializeField]
    [HideInInspector]
    private Renderer ren = null;

    [ExposeToLevelEditor(0)]
    public Color32 Color { get { return ren.material.color; } set { ren.material.color = value; } }

#if UNITY_EDITOR
    private void OnValidate()
    {
        GetStandardComponents();
    }

    private void Reset()
    {
        GetStandardComponents();
    }

    private void GetStandardComponents()
    {
        if (ren == null)
        {
            ren = GetComponent<Renderer>();
        }
    }
#endif
}
