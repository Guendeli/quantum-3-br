using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Deterministic;
using Quantum;
using Quantum.Utils;
using TMPro;
using UnityEngine;
using Input = Quantum.Input;

/// <summary>
/// Updates the player view based on data incoming from the Quantum simulation
/// </summary>
public unsafe class PlayerView : QuantumEntityViewComponent
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private GameObject m_overheadUI;
    [SerializeField] private TMP_Text m_playerNameText;
    [SerializeField, Range(1,2)] private float m_animSpeedMultiplier = 1.5f;
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
        PlayerLink playerLink = frame.Get<PlayerLink>(EntityRef);
        m_IsLocalPlayer = _game.PlayerIsLocal(playerLink.Player);
        var playerData = frame.GetPlayerData(playerLink.Player);
        m_playerNameText.text = playerData.PlayerNickname;
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
        if (PredictedFrame.Exists(EntityRef) == false) 
            return;
        
        Input* input = PredictedFrame.GetPlayerInput(PredictedFrame.Get<PlayerLink>(EntityRef).Player);

        var currentrotation = PredictedFrame.Get<Transform2D>(EntityRef).Rotation;
        var rotation = input->Direction.Rotate(-currentrotation).ToUnityVector2() * m_animSpeedMultiplier;
        
        m_animator.SetFloat(PARAM_MOVE_X, rotation.x);
        m_animator.SetFloat(PARAM_MOVE_Z, rotation.y);
    }

    public override void OnDeactivate()
    {
        QuantumEvent.UnsubscribeListener(this);
    }
}
