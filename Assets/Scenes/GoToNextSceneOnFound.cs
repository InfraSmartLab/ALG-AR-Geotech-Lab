using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class GoToNextSceneOnFound : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "3.Start Menu";
    [SerializeField] private float delay = 0.1f;   // small debounce
    private ObserverBehaviour observer;
    private bool loading;

    void Awake() => observer = GetComponent<ObserverBehaviour>();

    void OnEnable()
    {
        if (observer) observer.OnTargetStatusChanged += OnStatusChanged;
    }

    void OnDisable()
    {
        if (observer) observer.OnTargetStatusChanged -= OnStatusChanged;
    }

    void OnStatusChanged(ObserverBehaviour beh, TargetStatus status)
    {
        if (loading) return;

        var s = status.Status;
        if (s == Status.TRACKED || s == Status.EXTENDED_TRACKED)
        {
            loading = true;
            StartCoroutine(LoadAfterDelay());
        }
    }

    System.Collections.IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        if (!Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            Debug.LogError($"Scene '{sceneToLoad}' not found in Build Settings.");
            loading = false;
            yield break;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
