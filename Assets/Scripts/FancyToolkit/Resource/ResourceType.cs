public enum ResourceType
{
    None,
    Gold,
    Speed,
    Strength,
    Health
}

[System.Serializable]
public struct ResourceInfo
{
    public ResourceType type;
    public int value;

    public ResourceInfo(ResourceType type, int value)
    {
        this.type = type;
        this.value = value;
    }

    public override string ToString()
    {
        return value + ResourceCtrl.GetEmoji(type);
    }
}