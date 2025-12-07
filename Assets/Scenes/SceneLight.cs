using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLight : MonoBehaviour
{
   void Start()
    {
        // Force camera to use skybox
        Camera.main.clearFlags = CameraClearFlags.Skybox;

        // Make sure there’s a sun
        if (RenderSettings.sun == null)
        {
            Light dirLight = FindObjectOfType<Light>();
            if (dirLight != null && dirLight.type == LightType.Directional)
            {
                RenderSettings.sun = dirLight;
                dirLight.intensity = 1f;
                dirLight.color = Color.white;
            }
        }

        // Ensure ambient lighting
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        RenderSettings.ambientIntensity = 1f;
        DynamicGI.UpdateEnvironment();
    }
}
