using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Call this from the Button OnClick()
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("2.Start Menu");   // exact scene name
    }
}
