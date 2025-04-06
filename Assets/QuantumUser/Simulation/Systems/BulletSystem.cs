/*
 * Project : Quantum 3 Battle royale
 * Purpose : System to handle bullet creation through Signals
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */
using Quantum.Utils;

namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class BulletSystem : SystemMainThreadFilter<BulletSystem.Filter>, ISignalCreateBullet
    {
        public override void Update(Frame f, ref Filter filter)
        {
        }

        public struct Filter
        {
            public EntityRef Entity;
            public Bullet* Bullet;
        }

        // This method is called when the ISignalCreateBullet is triggered
        public void CreateBullet(Frame f, EntityRef Owner, WeaponData WeaponData)
        {
            BulletData bulletData = WeaponData.BulletData;
            EntityRef bulletEntity = f.Create(bulletData.Bullet);
            Transform2D* bulletTransform = f.Unsafe.GetPointer<Transform2D>(bulletEntity);
            Transform2D ownerTransform = f.Get<Transform2D>(Owner);
            
            bulletTransform->Position = ownerTransform.Position + WeaponData.Offset.XZ.Rotate(ownerTransform.Rotation);
            bulletTransform->Rotation = ownerTransform.Rotation;
            
            Bullet* bullet = f.Unsafe.GetPointer<Bullet>(bulletEntity);
            bullet->Owner = Owner;
            bullet->Damage = bulletData.Damage;
            bullet->Speed = bulletData.Speed;
            bullet->Lifecycle = bulletData.Lifetime;
            bullet->Direction = ownerTransform.Up;
        }
    }
}
