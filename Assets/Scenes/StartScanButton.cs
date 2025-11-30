using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScanButton : MonoBehaviour
{
    // Use the exact scene name that contains the ARCamera + ImageTargets
    [SerializeField] private string scanScene = "2.Scan";

    public void OpenScanner()
    {
        if (!Application.CanStreamedLevelBeLoaded(scanScene))
        {
            Debug.LogError($"Scene '{scanScene}' not found in Build Settings.");
            return;
        }
        SceneManager.LoadScene(scanScene);
    }
}
