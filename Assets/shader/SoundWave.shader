Shader "GaiziShader/SoundWave" {
Properties {
		//角度
		_Angle("Angle",Range(1,10))=0.5
		//强度
        _WaveStrength("Wave Strength",Float) = 0.01
		//折皱数
        _WaveFactor("Wave Factor",Float) = 50
		//波动速度 
        _WaveSpeed("_WaveSpeed",Float) = 10
		//中心点X
		_CenterX("_CenterX",Float)=0.5
		//中心点Y
		_CenterY("_CenterY",Float)=0.5
		//衰减距离
		_AttenDir("AttenDir",Float)=0.5
	}
	SubShader {
		// 因为玻璃的，这里我们需要做透明混合
		Tags { "Queue"="Transparent" "RenderType"="Opaque" }
		Cull Off
		//关闭深度写入
		//ZWrite off
		//源因子：透明度            目标因子：1-源因子透明度
		//最后会把源因子和目标因子相乘得到最终结果
		//Blend SrcAlpha OneMinusSrcAlpha
		//这是一个抓取屏幕图像的Pass,会把图像存进_RefractionTex这个变量中
		GrabPass { "_RefractionTex" }
		
		Pass {		
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _RefractionTex;
			float4 _RefractionTex_TexelSize;
			float _Angle;
            float _WaveStrength;
            float _WaveFactor;
            float _WaveSpeed;
			float _CenterX;
			float _CenterY;
			float _AttenDir;

			struct a2v {
				float4 vertex : POSITION;
				float2 texcoord: TEXCOORD0;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float4 scrPos : TEXCOORD0;
				float2 uv : TEXCOORD1;
			};
			
			v2f vert (a2v v) {
				v2f o;
				
				o.pos = UnityObjectToClipPos(v.vertex);
				//TRANSFORM_TEX 想当于 v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				o.uv.xy = v.texcoord;
				//齐次坐标系下的屏幕坐标值
				o.scrPos = ComputeGrabScreenPos(o.pos);
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target {

				//计算出fixed2(0.5,0.5)到uv每个点的单位向量方向
                fixed2 uvDir = normalize(i.uv-fixed2(_CenterX,_CenterY));
				//计算出fixed2(0.5,0.5)到uv每个点的距离
                fixed dis = distance(i.uv,fixed2(_CenterX,_CenterY));
				float WaveAngle=clamp( atan(uvDir),0,1);
				WaveAngle = pow( WaveAngle,_Angle);
				//距离衰减
				WaveAngle*=max(0,_AttenDir- dis);

				//这个是折射取UV的内容(i.scrPos.xy/i.scrPos.w) 后面的是对UV扭曲的计算
                fixed2 uv =(i.scrPos.xy/i.scrPos.w)+_WaveStrength*sin(_Time.y*_WaveSpeed+dis*_WaveFactor)*WaveAngle;

				fixed3 refrCol = tex2D(_RefractionTex, uv).rgb;

				//调节一下扭曲的程度,得到最终的颜色
				fixed3 finalColor =  refrCol ;
			
				return fixed4(finalColor, 1);
			}
			
			ENDCG
		}
	}
	FallBack "Diffuse"
}
