Shader "Graph/Point Surface GPU" {

	Properties {
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}
	
	SubShader {
		CGPROGRAM
        // below line instructs shader compiler to generate a suface shader with standard lighting and full support for shadows
        // pragma comes from Greek and refers to an action, or something that needs to be done.
		#pragma surface ConfigureSurface Standard fullforwardshadows addshadow
        #pragma instancing_options assumeuniformscaling procedural:ConfigureProcedural
        #pragma editor_sync_compilation
		#pragma target 4.5
		
		struct Input {
			float3 worldPos;
		};

		float _Smoothness;

        #if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
            StructuredBuffer<float3> _Positions;
        #endif

        float _Step;

        void ConfigureProcedural () {
            #if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
                float3 position = _Positions[unity_InstanceID];

                unity_ObjectToWorld._m00 = _Step; // Scale x
                unity_ObjectToWorld._m11 = _Step; // Scale y
                unity_ObjectToWorld._m22 = _Step; // Scale z
                unity_ObjectToWorld._m03 = position.x; // Position x
                unity_ObjectToWorld._m13 = position.y; // Position y
                unity_ObjectToWorld._m23 = position.z; // Position z
                unity_ObjectToWorld._m33 = 1.0; // Homogeneous coordinate

            #endif
        }

		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo = saturate(input.worldPos * 0.5 + 0.5);
			surface.Smoothness = _Smoothness;
		}
		ENDCG
	}
						
	FallBack "Diffuse"
}