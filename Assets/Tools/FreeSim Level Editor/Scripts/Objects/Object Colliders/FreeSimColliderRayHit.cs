#if UNITY_EDITOR
using UnityEngine;

namespace FreeSimEditor
{
    public class FreeSimColliderRayHit
    {
        #region Private Variables
        private Ray _ray;
        private float _hitEnter;
        private Vector3 _hitPoint;
        private Vector3 _hitNormal;
        private FreeSimCollider _hitCollider;
        #endregion

        #region Public Properties
        public Ray Ray { get { return _ray; } }
        public float HitEnter { get { return _hitEnter; } }
        public Vector3 HitPoint { get { return _hitPoint; } }
        public Vector3 HitNormal { get { return _hitNormal; } }
        public FreeSimCollider HitCollider { get { return _hitCollider; } }
        #endregion

        #region Constructors
        public FreeSimColliderRayHit(Ray ray, float hitEnter, Vector3 hitPoint, Vector3 hitNormal, FreeSimCollider hitCollider)
        {
            _ray = ray;
            _hitEnter = hitEnter;
            _hitCollider = hitCollider;

            _hitPoint = hitPoint;
            _hitNormal = hitNormal;
            _hitNormal.Normalize();
        }
        #endregion
    }
}
#endif