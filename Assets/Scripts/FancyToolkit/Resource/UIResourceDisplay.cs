using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UIResourceDisplay : MonoBehaviour
{
    public ResourceType type;
    public TMP_Text txtValue;

    private void OnEnable()
    {
        ResourceCtrl.OnChanged += HandleResourceChange;
        HandleResourceChange(type, ResourceCtrl.current.Get(type));
    }

    private void OnDisable()
    {
        ResourceCtrl.OnChanged -= HandleResourceChange;
    }

    void HandleResourceChange(ResourceType type, int value)
    {
        if (this.type != type) return;

        txtValue.SetText(new ResourceInfo(type, value).ToString());
    }
}
