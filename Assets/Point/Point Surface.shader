Shader "Graph/Point Surface" {
    SubShader {
        CGPROGRAM
        // below line instructs shader compiler to generate a suface shader with standard lighting and full support for shadows
        // pragma comes from Greek and refers to an action, or something that needs to be done
        #pragma surface ConfigureSurface fullforwardshadows
        #pragma target 3.0

        struct Input {
            float3 worldPos;
        };

        void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {}
        ENDCG
    }
    FallBack "Diffuse"
}