﻿#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace FreeSimEditor
{
    public class PrefabWithPrefabCategoryAssociationQueue : Singleton<PrefabWithPrefabCategoryAssociationQueue>
    {
        #region Private Variables
        private Queue<PrefabWithPrefabCategoryAssociation> _associationQueue = new Queue<PrefabWithPrefabCategoryAssociation>();
        #endregion

        #region Public Methods
        public void Enqueue(PrefabWithPrefabCategoryAssociation association)
        {
            if(association != null) _associationQueue.Enqueue(association);
        }

        public void DequeueAndPerform()
        {
            if (_associationQueue.Count != 0)
            {
                PrefabWithPrefabCategoryAssociation association = _associationQueue.Dequeue();
                association.Perform();
            }
        }

        public void DequeAllAndPerform()
        {
            while (_associationQueue.Count != 0)
            {
                DequeueAndPerform();
            }

            FreeSimWorldBuilder.ActiveInstance.RepaintAllEditorWindows();
        }
        #endregion
    }
}
#endif