using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[SerializeField, SetProperty("textureWidth")]
[ExecuteInEditMode]
public class newtest : MonoBehaviour
{
    public Material material = null;
    #region Material1 properties
    [SerializeField, SetProperty("textureWidth")]
    private int m_textureWidth = 512;
    public int textureWidth
    {
        get
        {
            return m_textureWidth;
        }
        set
        {
            m_textureWidth = value;
            _UpdateMaterial();

        }
    }
    // Use this for initialization
    [SerializeField, SetProperty("backgroundColor")]
    private Color m_backgroundColor = Color.white;
    public Color backgroundColor
    {
        get { return m_backgroundColor; }
        set
        {
            m_backgroundColor = value;
            _UpdateMaterial();
            //this is descript
        }

    }
    [SerializeField, SetProperty("circleColor")]
    private Color m_circleColor = Color.yellow;
    public Color circleColor
    {
        get { return m_circleColor; }
        set
        {
            m_circleColor = value;
            _UpdateMaterial();
        }
    }
    [SerializeField, SetProperty("blurFactor")]
    private float m_blurFactor = 2.0f;
    public float blurFactor
    {
        set { m_blurFactor = value; }
        get { return m_blurFactor; }
    }

    #endregion
    private Texture2D m_generatedTexture = null;
    // Update is called once per frame
    void Start()
    {
        if (material == null)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            if (renderer == null)
            {
                Debug.LogWarning("cannot find a renderer.");
                return;
            }
            material = renderer.sharedMaterial;

        }
        _UpdateMaterial();
    }

    private void _UpdateMaterial()
    {
        if (material != null)
        {
            m_generatedTexture = GenerateProceduralTexture();
            material.SetTexture("_MainTex", m_generatedTexture);
        }

    }

    private Texture2D GenerateProceduralTexture()
    {
        Texture2D proceduralTexture = new Texture2D(textureWidth, textureWidth);

        float circleInterval = textureWidth / 4.0f;
        float radius = textureWidth / 10.0f;
        float edgeBlur = 1.0f / blurFactor;

        for (int w = 0; w < textureWidth; w++)
        {
            for (int h = 0; w < textureWidth; h++)
            {
                Color pixel = backgroundColor;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Vector2 circleCenter = new Vector2(circleInterval * (i + 1), circleInterval * (j + 1));
                        float dist = Vector2.Distance(new Vector2(w, h), circleCenter) - radius;
                        Color color = 
                            _MixColor(circleColor, new Color(pixel.r, pixel.g, pixel.b, 0.0f), Mathf.SmoothStep(0f, 1.0f, dist * edgeBlur));
                        pixel = _MixColor(pixel, color, color.a);
                    }
                }
                proceduralTexture.SetPixel(w, h, pixel);
            }
        }
        proceduralTexture.Apply();
        return proceduralTexture;
    }

    private Color _MixColor(Color circleColor, Color color, float v)
    {
        Color t = circleColor * v + color * (1 - v);
        return t;
    }
}


