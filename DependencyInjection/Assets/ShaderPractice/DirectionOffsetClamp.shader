// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DirectionOffsetClamp" {

	Properties{
		_Texture("Texture",2D) = "white"{}
	_Scale("Scale",Range(0,0.5)) = 0
		_Color("Color",Color) = (1,1,1,1)
		_Pos("Pos",Range(-1,1)) = 0
		_Range("Range",Range(0,0.5))=0
	}

		SubShader{
		Pass{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		CGPROGRAM

#pragma vertex vert
#pragma fragment frag

	sampler2D _Texture;
	fixed _Scale;
	fixed4 _Color;
	fixed _Pos;
	fixed _Range;

	struct appdata {
		fixed4 vertex : POSITION;
		fixed2 uv : TEXCOORD0;
		fixed4 normal : NORMAL;
	};

	struct v2f {
		fixed4 vertex : SV_POSITION;
		fixed2 uv : TEXCOORD0;
		fixed4 color : COLOR;
	};


	v2f vert(appdata v) {
		v2f o;
		o.uv = v.uv;
		if (v.vertex.z <= _Pos&&v.vertex.z >= _Pos - _Range) {
			o.color = _Color;
			v.vertex.xyz += v.normal * _Scale;
		}
		else {
			o.color = fixed4(1, 1, 1, 1);
		}
		o.vertex = UnityObjectToClipPos(v.vertex);
		return o;
	}

	fixed4 frag(v2f v) :SV_Target{
		return tex2D(_Texture,v.uv)*v.color;
	}
		ENDCG

	}
	}
		FallBack "Diffuse"
}
