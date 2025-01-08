#if UNITY_EDITOR
namespace FreeSimEditor
{
    public enum BoxPlaneClassificationResult
    {
        InFront = 0,
        Behind,
        Spanning,
        OnPlane     // Rare, but possible
    }
}
#endif