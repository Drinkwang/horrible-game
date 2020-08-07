using UnityEngine;
using System.Collections;

public class BrightnessSaturationAndConstast : PostEffectsBase {

	public Shader brightSaturaShader;
	private Material edgeDetectMaterial = null;
	public Material material {  
		get {
			edgeDetectMaterial = CheckShaderAndCreateMaterial(brightSaturaShader, edgeDetectMaterial);
			return edgeDetectMaterial;
		}  
	}

	[Range(0.0f, 3.0f)]
	public float brightness = 0.0f;
    [Range(0.0f, 3.0f)]
    public float saturation = 0.0f;
    [Range(0.0f, 3.0f)]
    public float constanst = 0.0f;

	void OnRenderImage (RenderTexture src, RenderTexture dest) {
		if (material != null) {
			material.SetFloat("_Brightness", brightness);
			material.SetFloat("_Saturation", saturation);
			material.SetFloat("_Contrast", constanst);

			Graphics.Blit(src, dest, material);
		} else {
			Graphics.Blit(src, dest);
		}
	}
}
