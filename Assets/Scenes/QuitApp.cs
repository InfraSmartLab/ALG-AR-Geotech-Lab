using UnityEngine;

public class QuitApp : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        // Works in Play Mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Works in builds (Android/Windows/macOS, etc.)
        Application.Quit();
#endif
    }
}
