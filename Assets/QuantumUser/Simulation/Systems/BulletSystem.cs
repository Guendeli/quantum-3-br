/*
 * Project : Quantum 3 Battle royale
 * Purpose : System to handle bullet creation through Signals
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */

using System.Runtime.InteropServices.ComTypes;
using Quantum.Physics2D;
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
            var nextPosition = filter.Bullet->Direction * filter.Bullet->Speed * f.DeltaTime;
            if (HandleCollisions(f, filter, nextPosition, out EntityRef hitEntity))
            {
                f.Destroy(filter.Entity);
                return;
            }
            
            HandleLifecycle(f, filter);
            
            filter.Transform->Position += nextPosition;
        }

        private void HandleLifecycle(Frame frame, Filter filter)
        {
            filter.Bullet->Lifecycle -= frame.DeltaTime;
            if (filter.Bullet->Lifecycle <= FP._0)
            {
                frame.Destroy(filter.Entity);
            }
        }

        private bool HandleCollisions(Frame frame, Filter filter,FPVector2 nextPosition, out EntityRef hitEntity)
        {
            hitEntity = EntityRef.None;

            EntityRef owner = filter.Bullet->Owner;
            Transform2D bulletTransform = frame.Get<Transform2D>(filter.Entity);
            
            HitCollection collisions = frame.Physics2D.LinecastAll(bulletTransform.Position, bulletTransform.Position + nextPosition, int.MaxValue, QueryOptions.HitAll & ~QueryOptions.HitTriggers);
            for (int i = 0; i < collisions.Count; i++)
            {
                var collision = collisions[i];
                if(collision.Entity == owner || collision.Entity == filter.Entity)
                    continue;
                hitEntity = collision.Entity;
                return true;
            }
            
            return false;
        }

        public struct Filter
        {
            public EntityRef Entity;
            public Bullet* Bullet;
            public Transform2D* Transform;
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
            bullet->HeightOffset = WeaponData.Offset.Y;
            bullet->Damage = bulletData.Damage;
            bullet->Speed = bulletData.Speed;
            bullet->Lifecycle = bulletData.Lifetime;
            bullet->Direction = ownerTransform.Up;
        }
    }
}
