/*
 * Project : Quantum 3 Battle royale
 * Purpose : scriptable object to store the data damageable entities
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */
namespace Quantum
{
    using Photon.Deterministic;

    public unsafe abstract class DamageableBase : AssetObject
    {
        public FP MaxHealth;

        public abstract void DamageableHit(Frame frame, EntityRef target, EntityRef source, FP damage, Damageable* damageable);
    }
}
