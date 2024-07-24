Shader "Custom/RippleShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _RippleOrigin("Ripple Origin", Vector) = (0, 0, 0, 0)
        _RippleStrength("Ripple Strength", Float) = 1
        _RippleSpeed("Ripple Speed", Float) = 1
        _TimeOffset("Time Offset", Float) = 0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    float3 worldPos : TEXCOORD1;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float3 _RippleOrigin;
                float _RippleStrength;
                float _RippleSpeed;
                float _TimeOffset;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float distanceFromOrigin = distance(i.worldPos, _RippleOrigin);
                    float ripple = sin(distanceFromOrigin * _RippleStrength - (_Time.y + _TimeOffset) * _RippleSpeed) * 0.1;
                    fixed4 col = tex2D(_MainTex, i.uv);
                    return col + ripple;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}