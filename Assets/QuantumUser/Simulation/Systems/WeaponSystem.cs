/*
 * Project : Quantum 3 Battle royale
 * Purpose : System to handle the weapon logic
 * Author  : Omar Guendeli
 * Copyright: MIT - 2025
 */

namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class WeaponSystem : SystemMainThreadFilter<WeaponSystem.Filter>
    {
        public override void Update(Frame f, ref Filter filter)
        {
            // just decrease cooldown during this frame and return
            if(filter.Weapon->Cooldown > FP._0)
            {
                filter.Weapon->Cooldown -= f.DeltaTime;
                return;
            }
            
            // if the player pressed the fire button, reset the cooldown
            Input* input = f.GetPlayerInput(filter.Player->Player);
            if(input->Fire.WasPressed)
            {
                WeaponData weaponData = f.FindAsset(filter.Weapon->WeaponData);
                filter.Weapon->Cooldown = weaponData.Cooldown;
                f.Signals.CreateBullet(filter.Entity, weaponData);
            }
        }

        public struct Filter
        {
            public EntityRef Entity;
            public PlayerLink* Player;
            public Weapon* Weapon;
        }
    }
}
