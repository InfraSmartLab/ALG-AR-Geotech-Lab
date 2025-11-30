using UnityEngine;

public class CameraFeedToQuad : MonoBehaviour
{
    public Camera cam;
    public float distance = 2f;
    private WebCamTexture feed;

    void Start()
    {
        // pick the back camera if available
        string devName = null;
        foreach (var d in WebCamTexture.devices)
            if (!d.isFrontFacing) { devName = d.name; break; }

        feed = string.IsNullOrEmpty(devName)
             ? new WebCamTexture(1280, 720, 30)
             : new WebCamTexture(devName, 1280, 720, 30);

        var r = GetComponent<Renderer>();
        var mat = r.material;
        // URP Unlit uses _BaseMap
        if (mat.HasProperty("_BaseMap")) mat.SetTexture("_BaseMap", feed);
        else mat.mainTexture = feed;

        feed.Play();
    }

    void LateUpdate()
    {
        // place + size quad to fill the view
        transform.position = cam.transform.position + cam.transform.forward * distance;
        transform.rotation = cam.transform.rotation;
        float h = 2f * distance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        transform.localScale = new Vector3(h * cam.aspect, h, 1f);

        // fix mirroring/orientation
        var mat = GetComponent<Renderer>().material;
        mat.mainTextureScale = feed.videoVerticallyMirrored ? new Vector2(1, -1) : Vector2.one;
        mat.mainTextureOffset = feed.videoVerticallyMirrored ? new Vector2(0, 1) : Vector2.zero;
        transform.localEulerAngles = new Vector3(0, 0, feed.videoRotationAngle);
    }

    void OnDestroy(){ if (feed != null) feed.Stop(); }
}
