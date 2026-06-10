public enum ColorType
{
    White = 0,
    Magenta = 1,
    Yellow = 2,
    Cyan = 4,
    Red = Magenta | Yellow,
    Blue = Magenta | Cyan,
    Green = Yellow | Cyan,
    Black = Yellow | Cyan | Magenta
}
public enum SymbolType
{
    Earth, 
    Air, 
    Water, 
    Fire
}