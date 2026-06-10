using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "ColorData", menuName = "GameData/Base/Colors", order = 1)]
public class ColorDatabase : Database
{
    public List<ColorEntry> colors;
    public Color GetColor(ColorType type)
    {
        return colors.FirstOrDefault(c => c.type == type).color;
    }
}

[System.Serializable]
public class ColorEntry
{
    public ColorType type;
    public Color color;
}