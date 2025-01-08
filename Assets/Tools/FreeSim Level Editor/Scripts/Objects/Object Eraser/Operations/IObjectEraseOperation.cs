#if UNITY_EDITOR
namespace FreeSimEditor
{
    public interface IObjectEraseOperation
    {
        #region Interface Methods
        void Perform();
        #endregion
    }
}
#endif