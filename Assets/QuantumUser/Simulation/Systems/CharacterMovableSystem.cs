namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class CharacterMovableSystem : SystemMainThreadFilter<CharacterMovableSystem.Filter>
    {
        public override void Update(Frame f, ref Filter filter)
        {
            filter.CharacterController3D->Move(f, filter.Entity, default);
        }

        public struct Filter
        {
            public EntityRef Entity;
            public CharacterController3D* CharacterController3D;
        }
    }
}
