#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public class FreeSimBoxCollider : FreeSimCollider
    {
        #region Private Variables
        private OrientedBox _orientedBox;
        #endregion

        #region Public Properties
        public OrientedBox OrientedBox { get { return new OrientedBox(_orientedBox); } }
        public Box ModelSpaceBox { get { return _orientedBox.ModelSpaceBox; } }
        #endregion

        #region Constructors
        public FreeSimBoxCollider(OrientedBox orientedBox)
        {
            _orientedBox = new OrientedBox(orientedBox);
        }
        #endregion

        #region Public Methods
        public override FreeSimColliderType GetColliderType()
        {
            return FreeSimColliderType.Box;
        }

        public override bool Raycast(Ray ray, out FreeSimColliderRayHit colliderRayHit)
        {
            colliderRayHit = null;
            float t;

            if (_orientedBox.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);
                BoxFace faceWhichContainsHitPoint = _orientedBox.GetBoxFaceClosestToPoint(hitPoint);
                Vector3 hitNormal = _orientedBox.GetBoxFacePlane(faceWhichContainsHitPoint).normal;

                colliderRayHit = new FreeSimColliderRayHit(ray, t, hitPoint, hitNormal, this);
            }
            return colliderRayHit != null;
        }
        #endregion
    }
}
#endif