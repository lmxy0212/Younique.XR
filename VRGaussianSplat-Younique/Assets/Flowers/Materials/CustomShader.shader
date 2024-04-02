Shader "CustomShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _BumpMap ("Normal Map", 2D) = "bump" {} // Added normal map property
        _BumpScale ("Normal Map Strength", Float) = 1.0 // Added normal map strength property
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderQueue"="Transparent" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap; // Sampler for the normal map
        half _BumpScale; // Normal map strength

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap; // UV coordinates for the normal map
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;

            // Sample the normal map
            fixed3 normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            // Apply the normal map strength
            o.Normal = lerp(o.Normal, normal, _BumpScale);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
