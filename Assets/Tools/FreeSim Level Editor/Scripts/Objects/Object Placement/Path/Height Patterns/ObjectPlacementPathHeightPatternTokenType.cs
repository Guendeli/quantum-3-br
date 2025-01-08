#if UNITY_EDITOR
namespace FreeSimEditor
{
    public enum ObjectPlacementPathHeightPatternTokenType
    {
        Comma = 0,
        OpeningParenthesis,
        ClosingParanthesis,
        Digit,
        Letter,
        MinusSign,
        Whitespace
    }
}
#endif