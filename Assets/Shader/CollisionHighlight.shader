Shader "Custom/CollisionHighlight" {
    Properties {
        _MainTex ("Base Texture", 2D) = "white" {}
        _HighlightColor ("Highlight Color", Color) = (1,0,0,1)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float4 _HighlightColor;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            float4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
        }
        ENDCG
    }
}
