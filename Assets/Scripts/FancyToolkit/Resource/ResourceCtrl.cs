using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FancyUtils;

[DefaultExecutionOrder(-10)]
public class ResourceCtrl : MonoBehaviour
{
    public static ResourceCtrl current;

    public static event System.Action<ResourceType, int> OnChanged;

    List<int> values;

    private void Awake()
    {
        current = this;
        values = new List<int>();
        foreach (var item in EnumUtil.GetValues<ResourceType>())
        {
            values.Add(0);
        }
    }

    public int Idx(ResourceType type) => (int)type;

    public int Get(ResourceType type) => values[Idx(type)];

    public bool Enough(ResourceType type, int value) => Get(type) >= value;

    public bool Enough(ResourceInfo info) => Enough(info.type, info.value);

    public void Add(ResourceType type, int value)
    {
        values[Idx(type)] += value;
        OnChanged?.Invoke(type, Get(type));
    }

    public bool Remove(ResourceType type, int value)
    {
        if (!Enough(type, value)) return false;
        int idx = Idx(type);
        int current = values[idx];

        values[idx] -= value;
        OnChanged?.Invoke(type, Get(type));

        return true;
    }

    public void Set(ResourceType type, int value)
    {
        values[Idx(type)] = value;
        OnChanged?.Invoke(type, Get(type));
    }

    public bool Enough(List<ResourceInfo> list)
    {
        foreach (var item in list)
        {
            if (!Enough(item.type, item.value)) return false;
        }

        return true;
    }

    public bool Remove(List<ResourceInfo> list)
    {
        if (!Enough(list)) return false;

        foreach (var item in list)
        {
            Remove(item.type, item.value);
        }
        return true;
    }

    public static string GetEmoji(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Gold: return "g";
            case ResourceType.Speed: return "spd";
            case ResourceType.Strength: return "str";
            case ResourceType.Health: return "hp";
            default: return "";
        }
        //return $" {type}";//$"<sprite name=\"{type}\">";
    }
}