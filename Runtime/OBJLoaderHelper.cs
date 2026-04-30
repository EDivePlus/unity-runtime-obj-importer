using System.Globalization;
using UnityEngine;

namespace Dummiesman
{
    public static class OBJLoaderHelper
    {
        /// <summary>
        /// Switches a URP Lit material to Transparent / Alpha-blend mode.
        /// </summary>
        public static void EnableMaterialTransparency(Material mtl)
        {
            mtl.SetFloat("_Surface", 1f); // 0 = Opaque, 1 = Transparent
            mtl.SetFloat("_Blend", 0f);   // 0 = Alpha, 1 = Premultiply, 2 = Additive, 3 = Multiply
            mtl.SetFloat("_AlphaClip", 0f);
            mtl.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mtl.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mtl.SetFloat("_ZWrite", 0f);

            mtl.DisableKeyword("_ALPHATEST_ON");
            mtl.DisableKeyword("_ALPHABLEND_ON");
            mtl.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mtl.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");

            mtl.SetOverrideTag("RenderType", "Transparent");
            mtl.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        }

        /// <summary>
        /// Modified from https://codereview.stackexchange.com/a/76891. Faster than float.Parse
        /// </summary>
        public static float FastFloatParse(string input)
        {
            if (input.Contains("e") || input.Contains("E"))
                return float.Parse(input, CultureInfo.InvariantCulture);

            float result = 0;
            int pos = 0;
            int len = input.Length;

            if (len == 0) return float.NaN;
            char c = input[0];
            float sign = 1;
            if (c == '-')
            {
                sign = -1;
                ++pos;
                if (pos >= len) return float.NaN;
            }

            while (true) // breaks inside on pos >= len or non-digit character
            {
                if (pos >= len) return sign * result;
                c = input[pos++];
                if (c < '0' || c > '9') break;
                result = (result * 10.0f) + (c - '0');
            }

            if (c != '.' && c != ',') return float.NaN;
            float exp = 0.1f;
            while (pos < len)
            {
                c = input[pos++];
                if (c < '0' || c > '9') return float.NaN;
                result += (c - '0') * exp;
                exp *= 0.1f;
            }
            return sign * result;
        }

        /// <summary>
        /// Modified from http://cc.davelozinski.com/c-sharp/fastest-way-to-convert-a-string-to-an-int. Faster than int.Parse
        /// </summary>
        public static int FastIntParse(string input)
        {
            int result = 0;
            bool isNegative = (input[0] == '-');

            for (int i = (isNegative) ? 1 : 0; i < input.Length; i++)
                result = result * 10 + (input[i] - '0');
            return (isNegative) ? -result : result;
        }

        public static Material CreateNullMaterial()
        {
            return new Material(Shader.Find("Universal Render Pipeline/Lit"));

        }

        public static Vector3 VectorFromStrArray(string[] cmps)
        {
            float x = FastFloatParse(cmps[1]);
            float y = FastFloatParse(cmps[2]);
            if (cmps.Length == 4)
            {
                float z = FastFloatParse(cmps[3]);
                return new Vector3(x, y, z);
            }
            return new Vector2(x, y);
        }

        public static Color ColorFromStrArray(string[] cmps, float scalar = 1.0f)
        {
            float Kr = FastFloatParse(cmps[1]) * scalar;
            float Kg = FastFloatParse(cmps[2]) * scalar;
            float Kb = FastFloatParse(cmps[3]) * scalar;
            return new Color(Kr, Kg, Kb);
        }
    }
}