using System.Collections;
using System.Collections.Generic;
using Photon.Deterministic;
using Quantum;
using UnityEngine;
using Input = Quantum.Input;

/// <summary>
/// Updates the player view based on data incoming from the Quantum simulation
/// </summary>
public unsafe class PlayerView : QuantumEntityViewComponent
{
    [SerializeField] private Animator m_animator;
    
    #region Animator Parameters
    private static readonly int PARAM_MOVE_X = Animator.StringToHash("moveX");
    private static readonly int PARAM_MOVE_Z = Animator.StringToHash("moveZ");
    #endregion
    
    public override void OnUpdateView()
    {
        UpdateAnimator();
    }

    /// <summary>
    /// Updates the Mecanim animator based on the KCC data from the simulation
    /// Use Predicted frames instead of Verified frames for visual matters
    /// </summary>
    private void UpdateAnimator()
    {
        Input* input = PredictedFrame.GetPlayerInput(PredictedFrame.Get<PlayerLink>(EntityRef).Player);
        KCC kcc = PredictedFrame.Get<KCC>(EntityRef);
        FPVector2 velocity = kcc.Velocity;
        
        m_animator.SetFloat(PARAM_MOVE_X, velocity.X.AsFloat);
        m_animator.SetFloat(PARAM_MOVE_Z, velocity.Y.AsFloat);
    }
}
