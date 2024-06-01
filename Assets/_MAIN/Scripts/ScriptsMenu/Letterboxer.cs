using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Letterboxer : MonoBehaviour
{
    public float targetAspect = 16.0f / 9.0f; // Relación de aspecto deseada (16:9)
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateLetterbox();
    }

    void UpdateLetterbox()
    {
        if (cam == null) return;

        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            cam.rect = rect;
        }
        else // Add pillarbox
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }
    }

    void OnPreCull()
    {
        GL.Clear(true, true, Color.black);
    }

    void OnPreRender()
    {
        GL.Clear(true, true, Color.black);
    }

    void OnValidate()
    {
        if (cam == null) cam = GetComponent<Camera>();
        UpdateLetterbox();
    }
}
