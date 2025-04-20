/*
 * Project : Quantum 3 Battle royale
 * Purpose : System to initialize health and deal with all the damageable entities
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */
namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class DamageableSystem : SystemSignalsOnly, ISignalOnComponentAdded<Damageable>, ISignalOnDamageableHit
    {

        public void OnAdded(Frame f, EntityRef entity, Damageable* component)
        {
            DamageableBase @base = f.FindAsset(component->DamageableData);
            if (@base == null)
            {
                f.Destroy(entity);
                return;
            }
            component->Health = @base.MaxHealth;
        }

        public void OnDamageableHit(Frame f, EntityRef target, EntityRef source, FP damage, Damageable* damageable)
        {
            var damageableBase = f.FindAsset<DamageableBase>(damageable->DamageableData);
            damageableBase.DamageableHit(f, target, source, damage, damageable);
            
        }
    }
}
