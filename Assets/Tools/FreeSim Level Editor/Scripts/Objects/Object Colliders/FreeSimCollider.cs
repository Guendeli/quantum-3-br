#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public abstract class FreeSimCollider
    {
        #region Public Methods
        public bool Raycast(Ray ray)
        {
            FreeSimColliderRayHit colliderRayHit;
            return Raycast(ray, out colliderRayHit);
        }

        public bool RaycastBothDirections(Ray ray, out FreeSimColliderRayHit colliderRayHit)
        {
            const float originOffsetAlongReverseDirection = 0.001f;
            Ray offsetRay = ray;
            offsetRay.origin -= offsetRay.direction * originOffsetAlongReverseDirection;

            if (Raycast(offsetRay, out colliderRayHit)) return true;
            else
            {
                offsetRay.direction = -offsetRay.direction;
                offsetRay.origin = ray.origin - offsetRay.direction * originOffsetAlongReverseDirection;
                if (Raycast(offsetRay, out colliderRayHit)) return true;
            }

            return false;
        }
        #endregion

        #region Public Abstract Methods
        public abstract FreeSimColliderType GetColliderType();
        public abstract bool Raycast(Ray ray, out FreeSimColliderRayHit colliderRayHit);
        #endregion
    }
}
#endif