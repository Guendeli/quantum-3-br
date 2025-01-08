namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    /// <summary>
    /// System that moves all entities with KCC (Kinematic Character Controller) components,
    /// Also instantiate default player when a player is added to the room.
    /// KCC doc: https://doc.photonengine.com/quantum/current/manual/physics/kcc
    /// </summary>
    [Preserve]
    public unsafe class CharacterMovableSystem : SystemMainThreadFilter<CharacterMovableSystem.Filter>
    {
        public override void Update(Frame f, ref Filter filter)
        {
            Input* playerInput = f.GetPlayerInput(filter.PlayerLink->Player);
            MovePlayer(f, filter, playerInput);
            RotatePlayer(f, filter, playerInput);
        }

        private void RotatePlayer(Frame frame, Filter filter, Input* playerInput)
        {
            FPVector2 direction = playerInput->MousePosition - filter.Transform->Position;
            filter.Transform->Rotation = FPVector2.RadiansSigned(FPVector2.Up, direction);
        }

        private static void MovePlayer(Frame f, Filter filter, Input* playerInput)
        {
            FPVector2 direction = playerInput->Direction;
            
            // cheat check
            if (direction.Magnitude > 1)
            {
                direction = direction.Normalized;
            }

            KCCSettings kccSetting = f.FindAsset(filter.KCC->Settings);
            
            kccSetting.Move(f, filter.Entity, direction);
        }

        public struct Filter
        {
            public EntityRef Entity;
            public KCC* KCC;
            public PlayerLink* PlayerLink;
            public Transform2D* Transform;
        }
    }
}
