using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTargetFound : MonoBehaviour
{
    [SerializeField] private string sceneName = "3.Start Menu"; // set in Inspector if you like

    // Called by Vuforia's "On Target Found" UnityEvent
    public void Load()
    {
        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogError($"Scene '{sceneName}' not in Build Settings.");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
