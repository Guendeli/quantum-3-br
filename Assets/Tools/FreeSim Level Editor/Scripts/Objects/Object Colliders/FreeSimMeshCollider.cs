#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public class FreeSimMeshCollider : FreeSimCollider
    {
        #region Private Variables
        private FreeSimMesh _mesh;
        private TransformMatrix _meshTransform;
        #endregion

        #region Public Properties
        public FreeSimMesh Mesh { get { return _mesh; } }
        public TransformMatrix MeshTransform { get { return _meshTransform; } }
        #endregion

        #region Constructors
        public FreeSimMeshCollider(FreeSimMesh mesh, TransformMatrix meshTransform)
        {
            _mesh = mesh;
            _meshTransform = meshTransform;
        }
        #endregion

        #region Public Methods
        public override FreeSimColliderType GetColliderType()
        {
            return FreeSimColliderType.Mesh;
        }

        public override bool Raycast(Ray ray, out FreeSimColliderRayHit colliderRayHit)
        {
            colliderRayHit = null;
            MeshRayHit meshRayHit = Mesh.Raycast(ray, _meshTransform);
            if (meshRayHit != null) colliderRayHit = new FreeSimColliderRayHit(ray, meshRayHit.HitEnter, meshRayHit.HitPoint, meshRayHit.HitNormal, this);

            return colliderRayHit != null;
        }
        #endregion
    }
}
#endif