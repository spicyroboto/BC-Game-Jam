using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScreenDistortion : MonoBehaviour {

    /// <summary>
    /// The visible area to show.
    /// </summary>
    public float VisibleAreaRadius = 200;

    /// <summary>
    /// How big should the "distorted" pixels be?
    /// </summary>
    public float PixelGranularity = 16;

    /// <summary>
    /// The material used to distort the screen.
    /// </summary>
    private UnityEngine.Material pixelMaterial;

    private void Awake()
    {
        this.pixelMaterial = new Material(Shader.Find("Hidden/PixelDistortion"));
    }

    /// <summary>
    /// Called each time we render to the screen.
    /// </summary>
    /// <param name="inputTexture">The source texture to use when applying the distortion.</param>
    /// <param name="outputTexture">The texture we want to write to with our finished product.</param>
	public void OnRenderImage(RenderTexture inputTexture, RenderTexture outputTexture)
    {
        this.pixelMaterial.SetFloat("_pixelGranularity", this.PixelGranularity);
        this.pixelMaterial.SetFloat("_radius", this.VisibleAreaRadius);
        this.pixelMaterial.SetFloat("_cursorX", 100 + 200 * Mathf.Sin(UnityEngine.Time.time));
        this.pixelMaterial.SetFloat("_cursorY", 200.0f);
        this.pixelMaterial.SetFloat("_textureWidth", inputTexture.width);
        this.pixelMaterial.SetFloat("_textureHeight", inputTexture.height);

        Graphics.Blit(inputTexture, outputTexture, this.pixelMaterial);
    }
}
