/*
 * Project : Quantum 3 Battle royale
 * Purpose : scriptable object to store the data of the weapons
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */

namespace Quantum
{
    using Photon.Deterministic;

    public class WeaponData : AssetObject
    {
        public FP Cooldown;
        public FPVector3 Offset;
        public BulletData BulletData;
    }
}
