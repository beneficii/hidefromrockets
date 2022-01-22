using UnityEditor;
using UnityEngine;

public class MenuAddons : MonoBehaviour
{
    [MenuItem("MyMenu/Fix box collider size")]
    static void LogSelectedTransformName()
    {
        foreach (var item in Selection.objects)
        {
            if(item is GameObject obj
                && obj.TryGetComponent<SpriteRenderer>(out var render)
                && obj.TryGetComponent<BoxCollider2D>(out var box))
            {
                box.size = render.size;
            }
        }
    }
}