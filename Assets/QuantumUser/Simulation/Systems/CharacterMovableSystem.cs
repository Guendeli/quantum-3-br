namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    /// <summary>
    /// System that moves all entities with CharacterController components,
    /// Also instantiate default player when a player is added to the room.
    /// </summary>
    [Preserve]
    public unsafe class CharacterMovableSystem : SystemMainThreadFilter<CharacterMovableSystem.Filter>, ISignalOnPlayerAdded
    {
        public override void Update(Frame f, ref Filter filter)
        {
            Input* playerInput = f.GetPlayerInput(filter.PlayerLink->Player);
            FPVector3 direction = playerInput->Direction.XOY;
            
            // cheat check
            if (direction.Magnitude > 1)
            {
                direction = direction.Normalized;
            }
            
            filter.CharacterController3D->Move(f, filter.Entity, direction);
        }

        public struct Filter
        {
            public EntityRef Entity;
            public CharacterController3D* CharacterController3D;
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
        }
    }
}
