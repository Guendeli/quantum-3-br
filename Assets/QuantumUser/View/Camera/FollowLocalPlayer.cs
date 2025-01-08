using System.Collections;
using System.Collections.Generic;
using Quantum;
using UnityEngine;

/// <summary>
/// Sets the main virtual camera to follow the local player.
/// </summary>
public class FollowLocalPlayer : QuantumViewComponent<CameraViewContext>
{
    public override void OnActivate(Frame frame)
    {
        if(!frame.TryGet(_entityView.EntityRef, out PlayerLink playerLink))
        {
            return;
        }

        if (!_game.PlayerIsLocal(playerLink.Player))
        {
            return;
        }
        
        ViewContext.VirtualCamera.Follow = _entityView.transform;
    }
}
