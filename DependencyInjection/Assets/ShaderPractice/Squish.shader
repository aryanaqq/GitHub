Shader "Custom/VertexTry" {
	Properties{
		_Color("Color",Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness",Range(0,1)) = 0.5
		_Metallic("Metallic",Range(0,1)) = 0.0
		_SquishAmount("Squish Amount",Float) = 1.0
		_SquishLimit("Squish Limit",Float)=0.0
	}

		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma target 3.0

		sampler2D _MainTex;
		struct Input {
		float2 uv_MainTex;
	};

	half _Glossiness;
	half _Metallic;
	half _SquishAmount;
	half _SquishLimit;
	fixed4 _Color;


	void vert(inout appdata_full v) {
		v.vertex.xyz += v.normal * 0;
		float3 worldPos = mul(unity_ObjectToWorld, v.vertex);

		float squish = -min(worldPos.y, _SquishLimit) * _SquishAmount;
		float3 normal = mul(unity_ObjectToWorld,v.normal);
		normal.y = 0;
		if (normal.x != 0 && normal.z != 0) {
			normal = normalize(normal);
		}
		v.vertex.xyz += normal*squish;
		float difference = min(worldPos.y - _SquishLimit,0);
		//v.vertex.y += difference *mul(unity_ObjectToWorld,float3(0,1,0));
	}

	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex)*_Color;
		o.Albedo = c.rgb;
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
