using System;
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
    [SerializeField] private GameObject m_overheadUI;
    private Renderer[] m_Renderers;
    private bool m_IsLocalPlayer;
    
    #region Animator Parameters
    private static readonly int PARAM_MOVE_X = Animator.StringToHash("moveX");
    private static readonly int PARAM_MOVE_Z = Animator.StringToHash("moveZ");
    #endregion

    private void Awake()
    {
        m_Renderers = GetComponentsInChildren<Renderer>(true);
    }

    public override void OnActivate(Frame frame)
    {
        m_IsLocalPlayer = _game.PlayerIsLocal(frame.Get<PlayerLink>(EntityRef).Player);
        var layer = UnityEngine.LayerMask.NameToLayer(m_IsLocalPlayer ? "Player_Local" : "Player_Remote");

        foreach (Renderer renderer in m_Renderers)
        {
            renderer.gameObject.layer = layer;
            renderer.enabled = true;
        }
        
        m_overheadUI.SetActive(true);

        QuantumEvent.Subscribe<EventOnPlayerEnteredGrass>(this, OnPlayerEnteredGrass);
        QuantumEvent.Subscribe<EventOnPlayerExitGrass>(this, OnPlayerLeftGrass);
    }

    private void OnPlayerEnteredGrass(EventOnPlayerEnteredGrass callback)
    {
        if (callback.Player != PredictedFrame.Get<PlayerLink>(EntityRef).Player)
            return;
        if(m_IsLocalPlayer)
            return;
        
        ToggleVisibility(false);
    }

    private void ToggleVisibility(bool value)
    {
        foreach (Renderer renderer in m_Renderers)
        {
            renderer.enabled = value;
        }
        m_overheadUI.SetActive(value);
    }
    
    private void OnPlayerLeftGrass(EventOnPlayerExitGrass callback)
    {
        if (callback.Player != PredictedFrame.Get<PlayerLink>(EntityRef).Player)
            return;
        if(m_IsLocalPlayer)
            return;
        
        ToggleVisibility(true);
    }


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

    public override void OnDeactivate()
    {
        QuantumEvent.UnsubscribeListener(this);
    }
}
