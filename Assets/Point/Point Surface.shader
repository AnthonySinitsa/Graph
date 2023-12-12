Shader "Graph/Point Surface" {

    Properties{
        _Smoothness("Smoothness", Range(0,1)) = 0.5
    }

    SubShader {
        CGPROGRAM
        // below line instructs shader compiler to generate a suface shader with standard lighting and full support for shadows
        // pragma comes from Greek and refers to an action, or something that needs to be done
        #pragma surface ConfigureSurface fullforwardshadows
        #pragma target 3.0

        struct Input {
            float3 worldPos;
        };

        float _Smoothness;

        void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
            surface.Albedo.rg = input.worldPos.xy * 0.5 + 0.5;
            surface.Smoothness = _Smoothness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}