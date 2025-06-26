Shader "Custom/NightVision_Unlit"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {} // Texture de l'objet
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            Lighting Off // D�sactive compl�tement l'�clairage
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv); // R�cup�re la texture de l'objet
                float luminance = dot(col.rgb, float3(0.3, 0.59, 0.11)); // Convertit en niveaux de gris
                return fixed4(0, luminance * 2.0, 0, 1); // Applique une teinte verte avec boost de luminosit�
            }
            ENDCG
        }
    }
}
