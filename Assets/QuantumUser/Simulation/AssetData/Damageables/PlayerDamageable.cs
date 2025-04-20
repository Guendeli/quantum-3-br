using Photon.Deterministic;

namespace Quantum
{
    public class PlayerDamageable : DamageableBase
    {
        public override unsafe void DamageableHit(Frame frame, EntityRef target, EntityRef source, FP damage, Damageable* damageable)
        {
            damageable->Health -= damage;
            if (damageable->Health <= FP._0)
            {
                frame.Destroy(target);
            }
        }
    }
}