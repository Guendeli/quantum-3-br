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
    public unsafe class CharacterMovableSystem : SystemMainThreadFilter<CharacterMovableSystem.Filter>, ISignalOnPlayerAdded
    {
        public override void Update(Frame f, ref Filter filter)
        {
            Input* playerInput = f.GetPlayerInput(filter.PlayerLink->Player);
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
        }

        public void OnPlayerAdded(Frame f, PlayerRef player, bool firstTime)
        {
            RuntimePlayer playerData = f.GetPlayerData(player);
            EntityRef playerEntity = f.Create(playerData.PlayerAvatar);
            PlayerLink playerLink = new PlayerLink()
            {
                Player = player
            };
            
            f.Add(playerEntity, playerLink);
            
            // TODO: use KCCSettings.init instead of setting the component values directly
            KCC* kcc = f.Unsafe.GetPointer<KCC>(playerEntity);
            KCCSettings settings = f.FindAsset(kcc->Settings);
            kcc->Acceleration = settings.Acceleration;
            kcc->MaxSpeed = settings.BaseSpeed;
        }
    }
}
