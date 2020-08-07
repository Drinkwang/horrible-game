// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/briSatConShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}	
		_Brightness("Brightness",float)=1
		_Saturation("Saturation",float)=1
		_Contrast("Constast",float)=1

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
			
			sampler2D _MainTex;
			half	_Brightness;
			half	_Saturation;
			half	_Contrast;
           
            struct v2f
            {
                half2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata_img v)
            {
				v2f o;
				
				o.pos = UnityObjectToClipPos(v.vertex);
				
				o.uv = v.texcoord;
						 
				return o;
            }

     

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
				fixed3 finalColor=col*_Brightness;
				fixed luminance=0.2125*col.r+0.7154*col.g+0.0721*col.b;
				fixed3 luminanceColor=fixed3(luminance,luminance,luminance);
				finalColor= lerp(finalColor,luminance,_Saturation);
				fixed3 avgColor=fixed3(0.5,0.5,0.5);
				finalColor=lerp(avgColor,finalColor,_Contrast);
				return fixed4(finalColor.rgb,col.a);
            }
            ENDCG
        }
    }
		FallBack Off
}
