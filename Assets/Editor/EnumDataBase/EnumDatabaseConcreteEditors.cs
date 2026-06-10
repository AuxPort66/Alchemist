using UnityEditor;

[CustomEditor(typeof(SymbolDatabase))]
public class SymbolDatabaseEditor : EnumDatabaseEditor {}

[CustomEditor(typeof(ColorDatabase))]
public class ColorDatabaseEditor : EnumDatabaseEditor {}