using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Terraria;

namespace SpawnRateScaler.Converters
{
    public static class Converters
    {
        private static float minVal = 0.05f;
        private static float maxVal = 20.0f;

        public static float ConvertToSpawnRate(float val)
        {
            if (val < 0.5f)
            {
                // Main.NewText($"<0.5f: {MathF.Pow(val*2.0f, 2.0f)}");
                return MathF.Pow(val * 2.0f, 2.0f);
            }
            else if (val > 0.5f)
            {
                float t = (val - 0.5f) * 2f;
                // Main.NewText($">0.5f: {MathF.Pow(maxVal, t)}");
                return MathF.Pow(maxVal, t);
            }
            else // == 0.5f -> default, 1x rates
            {
                // Main.NewText($"== 1.0f: {1.0f}");
                return 1.0f;

            }
        }

    }
}