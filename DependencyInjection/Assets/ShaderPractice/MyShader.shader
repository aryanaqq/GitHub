// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/MyShader" {

	Properties{
		_Texture("Texture",2D) = "white"{}
		_Color("Color", Color) = (1,1,1,1)
			_Scale("Scale",Range(0,0.025))=0
	}

		SubShader{
			Pass{
			Tags { "Queue" = "Geomtry" "RenderType" = "Opaque" }
			LOD 100

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			sampler2D _Texture;
			fixed4 _Color;


			struct appdata {
				fixed4 vertex : POSITION;
				fixed2 uv : TEXCOORD0;
				fixed4 normal : NORMAL;
			};

			struct v2f {
				fixed4 vertex : SV_POSITION;
				fixed2 uv : TEXCOORD0;
			};


			v2f vert(appdata i) {
				v2f o;
				o.uv = i.uv;
				o.vertex = UnityObjectToClipPos(i.vertex);
				return o;
			}

			fixed4 frag(v2f v) :SV_Target{
			return tex2D(_Texture,v.uv)*_Color;
			}
			ENDCG

		}
		}
			FallBack "Diffuse"
}
