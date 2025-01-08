#if UNITY_EDITOR
namespace FreeSimEditor
{
    public interface IObjectSelectionUpdateOperation
    {
        #region Interface Methods
        void Perform();
        #endregion
    }
}
#endif