Shader "Custom/Multiply Layer (Fractal)"
{
	Properties
	{
        _MainColor ("Color", Color) = (1, 1, 1, 1)
        _Border ("Border Width", Range(0.01, 0.49)) = 0.1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Overlay+1" "PreviewType"="Plane"}
		LOD 100

		Pass
		{
			Cull Off
			ZWrite Off
            ZTest Off
			Blend DstColor OneMinusSrcAlpha

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
			};

            fixed4 _MainColor;
            float _Border;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
            
            float2 distort(float2 uv) {
                float x = 7 * uv.x - 3.5;
                float y = 7 * uv.y - 3.5;
                float r = sqrt(x * x + y * y);
                float a = atan2(y, x);

                float2 distorted;
                distorted.x = cos(a)/r;
                distorted.y = sin(a)/r;
                return distorted;
            }

            float getBrightness(float2 uv) {
                float2 time = float2(_Time.y/4 + 100, _Time.y/4 + 100);
                float2 recursiveDistort = fmod(distort(uv) + time, 1);
                for (int i = 0; i < 4; i++) {
                    if (recursiveDistort.x < _Border || recursiveDistort.x > 1 - _Border|| recursiveDistort.y < _Border || recursiveDistort.y > 1 - _Border) {
                        return 1 - i * 0.05;
                    }
                    else {
                        float scaledX = (recursiveDistort.x - _Border)/(1 - 2*_Border);
                        float scaledY = (recursiveDistort.y - _Border)/(1 - 2*_Border);
                        float2 scaled = float2(scaledX, scaledY);
                        recursiveDistort = fmod(distort(scaled) + time, 1);
                    }
                }
                return 0.8;
            }
			
			fixed4 frag (v2f i) : SV_Target
			{
                float brightness = getBrightness(i.uv);

                fixed4 col = fixed4(brightness, brightness, brightness, 1);

                float2 time = float2(_Time.y, _Time.y);

				return col;
			}
			ENDCG
		}
	}
}
