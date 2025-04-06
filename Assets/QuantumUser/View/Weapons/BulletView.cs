/*
 * Project : Quantum 3 Battle royale
 * Purpose : View component to display bullets
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */
namespace Quantum
{
    using UnityEngine;

    public class BulletView : QuantumEntityViewComponent
    {

        [SerializeField] private Transform m_BulletGraphic;

        public override void OnActivate(Frame frame)
        {
            Bullet bullet = PredictedFrame.Get<Bullet>(EntityRef);
            Vector3 localPos = m_BulletGraphic.localPosition;
            localPos.y = bullet.HeightOffset.AsFloat;
            m_BulletGraphic.localPosition = localPos;
        }
    }
}
