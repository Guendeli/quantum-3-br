#if UNITY_EDITOR
namespace FreeSimEditor
{
    public interface IMessageListener
    {
        #region Interface Methods
        void RespondToMessage(Message message);
        #endregion
    }
}
#endif