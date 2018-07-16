// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Displacement" {

	Properties{
		_MainTex("Texture",2D) = "white"{}
		_Speed("Speed",float)=1.0
		_Amount("Amount",float)=5
		_Distance("Distance",float)=0.1
	}
		SubShader{

		Tags{ "RenderType" = "Opaque"  }
		LOD 100
			Pass{
		CGPROGRAM

		#include "UnityCG.cginc"
		#pragma vertex vert
		#pragma fragment frag

		sampler2D _MainTex;
		float _Speed;
		float _Amount;
		float _Distance;
		float4 _MainTex_ST;


	struct appdata {
		fixed4 vertex : POSITION;
		fixed2 uv : TEXCOORD0;
	};

	struct v2f {
		fixed4 vertex : SV_POSITION;
		fixed2 uv : TEXCOORD0;
	};


	v2f vert(appdata v) {
		v2f o;					
		float4 worldPos=mul(unity_ObjectToWorld,v.vertex);
		worldPos.x+= sin(_Time.y*_Speed+v.vertex.y*_Amount)*_Distance;			
		v.vertex = mul( unity_WorldToObject, worldPos );
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv,_MainTex);
		return o;
	}

	fixed4 frag(v2f v) :SV_Target{
		fixed4 col = tex2D(_MainTex,v.uv);
		return col;
	}
		ENDCG

	}
	}
		FallBack "Diffuse"
}
