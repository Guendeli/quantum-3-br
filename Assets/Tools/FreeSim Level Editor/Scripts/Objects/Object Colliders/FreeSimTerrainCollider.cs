#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public class FreeSimTerrainCollider : FreeSimCollider
    {
        #region Private Methods
        private TerrainCollider _terrainCollider;
        #endregion

        #region Public Properties
        public TerrainCollider TerrainCollider { get { return _terrainCollider; } }
        #endregion

        #region Constructors
        public FreeSimTerrainCollider(TerrainCollider terrainCollider)
        {
            _terrainCollider = terrainCollider;
        }
        #endregion

        #region Public Methods
        public override FreeSimColliderType GetColliderType()
        {
            return FreeSimColliderType.Terrain;
        }

        public override bool Raycast(Ray ray, out FreeSimColliderRayHit colliderRayHit)
        {
            colliderRayHit = null;

            RaycastHit rayHit;
            if (_terrainCollider.Raycast(ray, out rayHit, float.MaxValue)) 
                colliderRayHit = new FreeSimColliderRayHit(ray, rayHit.distance, rayHit.point, rayHit.normal, this);

            return colliderRayHit != null;
        }
        #endregion
    }
}
#endif