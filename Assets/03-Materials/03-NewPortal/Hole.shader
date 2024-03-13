Shader "Unlit/Hole"
{
    Properties
    {
   [HDR] _Color("Color",Color) = (1,1,1,0.5)
        _MainTex("Texture", 2D) = "white" {}
        _TwistSpeed("Twist Speed",float) = 7
    }
        SubShader
    {
      Tags { "RenderType" = "Opaque" "Queue" = "Transparent+2"}
        ColorMask RGB

              ZTest off
            ZWrite On
            Cull Front
            Lighting Off


            Stencil
            {
                Ref 1
                Comp equal
                Pass zero
                fail zero
                zfail zero
            }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;

            void Unity_Rotate_Radians_float(float2 UV, float2 Center, float Rotation, out float2 Out)
            {
                //rotation matrix
                UV -= Center;
                float s = sin(Rotation);
                float c = cos(Rotation);

                //center rotation matrix
                float2x2 rMatrix = float2x2(c, -s, s, c);
                rMatrix *= 0.5;
                rMatrix += 0.5;
                rMatrix = rMatrix * 2 - 1;

                //multiply the UVs by the rotation matrix
                UV.xy = mul(UV.xy, rMatrix);
                UV += Center;

                Out = UV;
            }

            void Unity_Twirl_float(float2 UV, float2 Center, float Strength, float2 Offset, out float2 Out)
            {
                float2 delta = UV - Center;
                float angle = Strength * length(delta);
                float x = cos(angle) * delta.x - sin(angle) * delta.y;
                float y = sin(angle) * delta.x + cos(angle) * delta.y;
                Out = float2(x + Center.x + Offset.x, y + Center.y + Offset.y);
            }


            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                float2 twistUV;
                Unity_Rotate_Radians_float(i.uv, float2(0.5,0.f), _Time.x*7.0, twistUV);
                Unity_Twirl_float(twistUV, float2(0.5, 0.5), 10, 0, twistUV);
                fixed4 col = tex2D(_MainTex, twistUV);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col * _Color;
            }
        ENDCG
        }
    }
}