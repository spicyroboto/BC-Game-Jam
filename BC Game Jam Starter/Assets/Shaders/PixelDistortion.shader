Shader "Hidden/PixelDistortion"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float _pixelGranularity;
			uniform float _radius;
			uniform float _intermediateRatio;
			uniform float _cursorX;
			uniform float _cursorY;
			uniform float _textureWidth;
			uniform float _textureHeight;

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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float distFromCursor = sqrt(pow((i.vertex.xy.x - _cursorX), 2.0) + pow((i.vertex.xy.y - _cursorY), 2.0));
				if (distFromCursor > _radius) {
					col = tex2D(_MainTex, float2(_pixelGranularity * floor((i.vertex.xy.x + (_pixelGranularity / 2)) / _pixelGranularity) / _textureWidth, (1 - (_pixelGranularity * floor((i.vertex.xy.y + (_pixelGranularity / 2)) / _pixelGranularity)) / _textureHeight)));
				}
				else if (distFromCursor > _radius - (_radius * _intermediateRatio)) {
					float varyingGranularity = _pixelGranularity / 2;
					col = tex2D(_MainTex, float2(varyingGranularity * floor((i.vertex.xy.x + (_pixelGranularity / 2)) / varyingGranularity) / _textureWidth, (1 - (varyingGranularity * floor((i.vertex.xy.y + (_pixelGranularity / 2)) / varyingGranularity)) / _textureHeight)));
				}
				return col;
			}
			ENDCG
		}
	}
}
