using UnityEngine;
using System.Collections;

public class PortalRenderer : MonoBehaviour
{
    public Camera TargetCamera;
    public Material PortalMaterial;

    private Resolution currentResolution;

    void Start ()
    {
        SetUpRenderTextureForCurrentResolution();
        currentResolution = new Resolution();
        currentResolution.width = Screen.width;
        currentResolution.height = Screen.height;
    }

    void Update()
    {
        if (currentResolution.width != Screen.width || currentResolution.height != Screen.height)
        {
            SetUpRenderTextureForCurrentResolution();
            currentResolution.width = Screen.width;
            currentResolution.height = Screen.height;
        }
    }

    void SetUpRenderTextureForCurrentResolution()
    {
        // Set up camera render texture. Render texture needs to be same size as screen dimensions.
        // Clean up existing texture if it exists
        if (TargetCamera.targetTexture != null)
            TargetCamera.targetTexture.Release();

        TargetCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        PortalMaterial.mainTexture = TargetCamera.targetTexture;
    }
}