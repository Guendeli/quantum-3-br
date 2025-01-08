#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace FreeSimEditor
{
    public interface IEntityNameMatchOperation
    {
        #region Interface Methods
        List<INamedEntity> GetEntitiesWithMatchingNames(List<INamedEntity> namedEntities, string nameToMatch);
        #endregion
    }
}
#endif