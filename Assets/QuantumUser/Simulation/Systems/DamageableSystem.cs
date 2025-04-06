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
            DamageableData data = f.FindAsset(component->DamageableData);
            if (data == null)
            {
                f.Destroy(entity);
                return;
            }
            component->Health = data.MaxHealth;
        }

        public void OnDamageableHit(Frame f, EntityRef damageableEntity, FP damage, Damageable* damageable)
        {
            damageable->Health -= damage;
            if (damageable->Health <= FP._0)
            {
                f.Destroy(damageableEntity);
            }
        }
    }
}
