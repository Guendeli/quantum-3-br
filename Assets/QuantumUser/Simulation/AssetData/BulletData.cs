/*
 * Project : Quantum 3 Battle royale
 * Purpose : scriptable object to store the data of the bullets
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */

namespace Quantum
{
    using Photon.Deterministic;

    public class BulletData : AssetObject
    {
        public FP Damage;
        public FP Speed;
        public FP Lifetime;
        public EntityPrototype Bullet;
    }
}
