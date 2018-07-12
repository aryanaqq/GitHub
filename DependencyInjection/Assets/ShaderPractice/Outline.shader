
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Outline" {

	Properties{
		_Texture("Texture",2D) = "white"{}
		_Outline("Scale",Range(0,0.05))=0.01
		_OutlineColor("Ouline Color",Color)=(0,0,1,1)
	}
		SubShader{
		Pass{

		Tags{ "RenderType" = "Opaque" }
		LOD 100
		Cull Front
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		sampler2D _Texture;
		fixed _Outline;
		fixed4 _OutlineColor;

		struct appdata {
		fixed4 vertex : POSITION;
		fixed4 normal : NORMAL;
		};

		struct v2f {
		fixed4 vertex : SV_POSITION;
		};


	v2f vert(appdata v) {
		v2f o;
		v.vertex.xyz += v.normal*_Outline;
		o.vertex = UnityObjectToClipPos(v.vertex);
		return o;
	}

	fixed4 frag(v2f v) :SV_Target{
		return _OutlineColor;
	}
		ENDCG
		}
			Pass{
	CGPROGRAM
#pragma vertex vert
#pragma fragment frag

	sampler2D _Texture;
	struct appdata {
		fixed4 vertex : POSITION;
		fixed2 uv : TEXCOORD0;
	};

	struct v2f {
		fixed2 uv : TEXCOORD0;
		fixed4 vertex : SV_POSITION;
	};

	v2f vert(appdata v) {
		v2f o;
		o.uv = v.uv;
		o.vertex = UnityObjectToClipPos(v.vertex);
		return o;
	}
	
	fixed4 frag(v2f i) :SV_Target{
	return tex2D(_Texture,i.uv);
	}

	ENDCG
	}

	}
		FallBack "Diffuse"
}
