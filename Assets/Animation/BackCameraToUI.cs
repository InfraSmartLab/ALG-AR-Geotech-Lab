using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackCameraToUI : MonoBehaviour
{
    public RawImage target;
    public AspectRatioFitter fitter;

    WebCamTexture camTex;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera))
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.Camera);
#endif
        StartCam();
    }

    void StartCam()
    {
        var devices = WebCamTexture.devices;
        if (devices.Length == 0) { Debug.LogWarning("No camera found"); return; }

        // Prefer back camera; fall back to first
        var back = devices.FirstOrDefault(d => !d.isFrontFacing);
        string deviceName = string.IsNullOrEmpty(back.name) ? devices[0].name : back.name;

        camTex = new WebCamTexture(deviceName, Screen.width, Screen.height, 30);
        target.texture = camTex;
        camTex.Play();
    }

    void Update()
    {
        if (camTex == null || camTex.width <= 16) return; // not yet ready

        // keep correct aspect
        fitter.aspectRatio = (float)camTex.width / camTex.height;

        // fix mirror/rotation from some devices
        target.rectTransform.localEulerAngles = new Vector3(0, 0, -camTex.videoRotationAngle);
        target.rectTransform.localScale = new Vector3(1, camTex.videoVerticallyMirrored ? -1 : 1, 1);
    }

    void OnDisable()
    {
        if (camTex != null) camTex.Stop();
    }
}
