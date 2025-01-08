using UnityEngine;

namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class MyFirstSystem : SystemMainThread
    {
        public override void Update(Frame f)
        {
            Log.Info("MyFirstSystem loop");
        }
    }
}
