//Shader "Shader105/OutlineShader"
//{
//    Properties
//    {
//        _MainTex("Base texture", 2D) = "white" {}
//        _AmbientStrength("Ambient Strength",Range(0,1.0)) = 0.1
//        _DiffStrength("Diff Strength",Range(0,1.0)) = 0.1
//        _SpecStrength("Spec Strength",Range(0,5.0)) = 0.1
//        _SpecPow("Specular Pow",Range(0.1,256)) = 1
//        _Brightness("Brightness",Range(0,2.0)) = 0.5


//    }
//        SubShader
//        {

//			Tags{"LightMode" = "Vertex"}
//		Pass
//		{
//			CGPROGRAM
//			#pragma vertex vert
//			#pragma fragment frag
//		//	#include "UnityLightingCommon.cginc" // for _LightColor0
//			#include "UnityCG.cginc"
//			#include "Lighting.cginc"
			
//			struct appdata
//			{
//				float4 vertex : POSITION;
//				float3 normal : NORMAL;
//				float2 uv: TEXCOORD0;
//			};

//			struct v2f
//			{
//				float4 vertex : SV_POSITION;
//				float3 normal : NORMAL;
//				float2 uv: TEXCOORD0;
//				float3 viewDir : TEXCOORD1;
//			};

//			v2f vert(appdata v)
//			{
//				v2f o;
//				o.uv = v.uv;
//				o.vertex = UnityObjectToClipPos(v.vertex);
//				o.normal = UnityObjectToWorldNormal(v.normal);
//				o.viewDir = normalize(_WorldSpaceCameraPos.xyz - mul(unity_ObjectToWorld, v.vertex).xyz);
//				return o;
//			}

//			sampler2D _MainTex;
//			float _AmbientStrength;
//			float _DiffStrength;
//			float _SpecStrength;
//			float _SpecPow;
//			float _Brightness;

//			float4 frag(v2f i) : SV_Target
//			{
//				//texture
//				float4 baseColor = tex2D(_MainTex, i.uv);

//				//ambient 
//				float3 ambient = _LightColor0 * _AmbientStrength;

//				//diffuse
//				float3 diff = dot(i.normal,_WorldSpaceLightPos0) * _LightColor0 * _DiffStrength;

//				//specular
//				float3 reflectDir = reflect(-_WorldSpaceLightPos0, i.normal);
//				float3 spec = pow(max(dot(i.viewDir, reflectDir), 0.0), _SpecPow) * _LightColor0 * _SpecStrength;

//				//final color
//				float4 final_color = float4((spec + diff + ambient),1.0) * baseColor * _Brightness;
//				return final_color;
//			}
//			ENDCG
//            }


        
//}



Shader "Unlit/gun"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		//模式一(_VERTEXMODEL_ONE)有效，代表哪一个灯光影响物体
		[Enum(ZeroLight,0,FirstLight,1,SecondLight,2)] _LightNum("LightNumber", Float) = 1
 
		//分别为四个模式：其实也可以不用变体的形式来控制
		//模式一: 可控制某一个灯光影响物体，只限一个；可控制环境光影响，通过下面的ENABLE_AMBIENT控制
		//模式二:Shade4PointLights函数，受到环境光、前四个光源的影响（必然包含平行光）且不可控
		//模式三:Shade4PointLightsFull函数，可控制数量和是否对SpotLight特殊处理（分别是函数的第三和第四个参数）
		//模式四: 可空灯光影响个数、是否受环境光影响、是否受平行光影响、是否对SpotLight特殊处理，如有需其他需求自行修改
		[KeywordEnum(One,Two,Three,Four)] _VertexModel("VertexModel", Float) = 0
 
		//在VertexModel_One和VertexModel_Four模式下有效：是否开启环境光影响
		[Toggle(ENABLE_AMBIENT)] _EnableAmbient("EnableAmbient", Float) = 0
 
		//在VertexModel_Four模式下有效：光照个数
		_LightCount("LightModelFour_CustomLightCount", Float) = 0
 
		//在VertexModel_Four模式下有效：是否开启SpotLight计算效果(变化不大)
		[Toggle] _EnableSotLight("EnableSpotLight", Float) = 0
		
		//在VertexModel_Four模式下有效：是否忽略平行光影响
		[Toggle] _IgnoreDirectionalLight("IgnoreDirectionalLight", Float) = 0 
				 _color("Main Color", Color) = (1,1,1,1)
				_OutlineColor("Outline Color", Color) = (1,1,1,1)
		_OutlineSize("OutlineSize", Range(0,1.5)) = 1.1
	}
	SubShader
	{
		//ZTest Always 
		//Cull Off
		//		 ZWrite Off
		Tags { "Queue"="AlphaTest+100" }
		LOD 100
		

			            Pass
            {
				Cull Front
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
                fixed4 _OutlineColor;
                float _OutlineSize;
                struct appdata
                {
                    float4 vertex:POSITION;
                };
                struct v2f
                {
                    float4 clipPos:SV_POSITION;
                };
                v2f vert(appdata v)
                {
                    v2f o;
                    o.clipPos = UnityObjectToClipPos(v.vertex * _OutlineSize);
                    return o;
                }
                fixed4 frag(v2f i) : SV_Target
                {
                    return _OutlineColor;
                }
             
				ENDCG
            }
		Pass
		{
			Tags{"LightMode" = "Vertex"}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
 
			#pragma multi_compile _VERTEXMODEL_ONE _VERTEXMODEL_TWO _VERTEXMODEL_THREE _VERTEXMODEL_FOUR
			#pragma multi_compile _ ENABLE_AMBIENT
			#pragma multi_compile _ ENABLE_SPOT_LIGHT
			#include "UnityCG.cginc"
 
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};
 
			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 color : COLOR;
			};
 
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _LightNum;			
			fixed4 _color;
			float _LightCount;
			float _EnableSotLight;
			float _IgnoreDirectionalLight;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
 
				#if _VERTEXMODEL_ONE
				//获取其中第_LightNum个光源位置 （视角空间）
				float4 lightPos1 = unity_LightPosition[_LightNum];
				fixed3 viewLightDir;
				if (lightPos1.w == 0)
				{
					viewLightDir = lightPos1.xyz;
				}
				else {
					viewLightDir = lightPos1.xyz - UnityObjectToViewPos(v.vertex).xyz * unity_LightPosition[0].w;
				}			
				fixed3 viewNormal = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
 
				float lengthSq = dot(viewLightDir, viewLightDir);
 
				// don't produce NaNs if some vertex position overlaps with the light
				lengthSq = max(lengthSq, 0.000001);
 
				viewLightDir *= rsqrt(lengthSq);
 
				float atten = 1.0 / (1.0 + lengthSq * unity_LightAtten[_LightNum].z);
 
				#if ENABLE_AMBIENT 
				//1.1环境光参与光照
				o.color.rgb = UNITY_LIGHTMODEL_AMBIENT.xyz + unity_LightColor[_LightNum].rgb * max(0,dot(viewNormal, normalize(viewLightDir)));
				#else				
				//1.2环境光不参与
				o.color.rgb = unity_LightColor[_LightNum].rgb * max(0, dot(viewNormal, normalize(viewLightDir)));
				#endif
 
				#elif _VERTEXMODEL_TWO
					o.color = ShadeVertexLights(v.vertex, v.normal);	 //函数为固定前4个光源的影响
				#elif _VERTEXMODEL_THREE
					o.color = ShadeVertexLightsFull(v.vertex, v.normal, 8, false);
				#elif _VERTEXMODEL_FOUR
				float3 viewpos = UnityObjectToViewPos(v.vertex);
				float3 viewN = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
				#if ENABLE_AMBIENT 
				float3 lightColor = UNITY_LIGHTMODEL_AMBIENT.xyz;
				#else
				float3 lightColor;
				#endif
				int startIndex = 0;
				if (_IgnoreDirectionalLight) {
					startIndex = 1;
				}
				for (int i = startIndex; i < _LightCount; i++) {
					float3 toLight = unity_LightPosition[i].xyz - viewpos.xyz * unity_LightPosition[i].w;
					float lengthSq = dot(toLight, toLight);
 
					// don't produce NaNs if some vertex position overlaps with the light
					lengthSq = max(lengthSq, 0.000001);
 
					toLight *= rsqrt(lengthSq);
 
					float atten = 1.0 / (1.0 + lengthSq * unity_LightAtten[i].z);
					if (_EnableSotLight)
					{
						float rho = max(0, dot(toLight, unity_SpotDirection[i].xyz));
						float spotAtt = (rho - unity_LightAtten[i].x) * unity_LightAtten[i].y;
						atten *= saturate(spotAtt);
					}
 
					float diff = max(0, dot(viewN, toLight));
					lightColor += unity_LightColor[i].rgb * (diff * atten);
				}
				o.color = lightColor;
				#endif				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb = col.rgb * i.color * 2*_color.rgb;
				return col;
			}
			ENDCG
			}
			
			

}	
}
