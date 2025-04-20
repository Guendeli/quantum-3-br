using System;
using System.Collections;
using System.Collections.Generic;
using Quantum;
using UnityEngine;

public class LookAtCamera : QuantumViewComponent<CameraViewContext>
{
    private void Update()
    {
        transform.LookAt(ViewContext.VirtualCamera.transform);
    }
}
