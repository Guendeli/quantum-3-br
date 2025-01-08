#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public static class PrefabTagAssociationsFactory
    {
        #region Public Static Functions
        public static PrefabTagAssociations Create(Prefab prefab)
        {
            if(prefab != null)
            {
                PrefabTagAssociations tagAssociations = FreeSimWorldBuilder.ActiveInstance.CreateScriptableObject<PrefabTagAssociations>();
                tagAssociations.Prefab = prefab;

                return tagAssociations;
            }

            return null;
        }
        #endregion
    }
}
#endif