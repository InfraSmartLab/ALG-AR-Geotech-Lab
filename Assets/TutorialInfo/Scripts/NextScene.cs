using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] bool loopToFirst = false;   // set true if you want the last scene to wrap to 0

    // Hook this to the Button's OnClick()
    public void GoNext()
    {
        int cur = SceneManager.GetActiveScene().buildIndex;
        int next = cur + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next);
        }
        else if (loopToFirst)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Last scene reached — no next scene in Build Settings.");
        }
    }
}
