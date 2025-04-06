namespace Quantum {
  using Photon.Deterministic;
  using UnityEngine;

  /// <summary>
  /// A Unity script that creates empty input for any Quantum game.
  /// </summary>
  public class QuantumDebugInput : MonoBehaviour {

    private Vector3 m_mousePos;
    
    private void OnEnable() {
      QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
    }

    /// <summary>
    /// Set an empty input when polled by the simulation.
    /// </summary>
    /// <param name="callback"></param>
    public void PollInput(CallbackPollInput callback) {
      Quantum.Input i = new Quantum.Input();
      
      var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
      if(Physics.Raycast(ray, out var hit, 100, 1 << UnityEngine.LayerMask.NameToLayer("Ground"))) { 
        m_mousePos = hit.point;
      }

      i.MousePosition = m_mousePos.ToFPVector3().XZ;
      i.Direction = new FPVector2(UnityEngine.Input.GetAxis("Horizontal").ToFP(),
        UnityEngine.Input.GetAxis("Vertical").ToFP());
      i.Fire = UnityEngine.Input.GetMouseButton(0);
      callback.SetInput(i, DeterministicInputFlags.Repeatable);
    }
  }
}
