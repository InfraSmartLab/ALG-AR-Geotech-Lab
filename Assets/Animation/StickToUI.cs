using UnityEngine;

public class StickToUI : MonoBehaviour
{
    public Camera arCamera;             // your Vuforia ARCamera
    public RectTransform uiTarget;      // the Button's RectTransform
    public float distance = 0.6f;       // meters in front of the camera

    void LateUpdate()
    {
        // For Screen Space - Overlay, uiTarget.position is already in screen coords
        Vector3 screen = uiTarget.position;

        // Place bowl 'distance' meters in front of the camera at that screen point
        Vector3 world = arCamera.ScreenToWorldPoint(new Vector3(screen.x, screen.y, distance));
        transform.position = world;

        // Make it face the camera (nice for labels/models)
        transform.rotation = Quaternion.LookRotation(transform.position - arCamera.transform.position);
    }
}
