#if UNITY_EDITOR
namespace FreeSimEditor
{
    public enum ObjectPlacementPathTileConnectionType
    {
        Begin = 0,
        End, 
        Forward,
        Turn,
        TJunction,
        Cross,
        Autofill
    }
}
#endif