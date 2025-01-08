using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Quantum;
using UnityEngine;

/// <summary>
/// Quantum Context to be able to access the virtual camera in the view.
/// </summary>
public class CameraViewContext : MonoBehaviour, IQuantumViewContext
{
    [SerializeField] public CinemachineVirtualCamera VirtualCamera;
    
}
