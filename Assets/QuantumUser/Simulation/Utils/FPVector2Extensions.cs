using Photon.Deterministic;

namespace Quantum.Utils
{
    public static class FPVector2Extensions
    {
        public static FPVector2 Rotate(this FPVector2 v, FP angle)
        {
            FP sin = FPMath.Sin(angle);
            FP cos = FPMath.Cos(angle);

            return new FPVector2(v.X * cos - v.Y * sin, v.X * sin + v.Y * cos);
        }
    }
}