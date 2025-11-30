using UnityEngine;
using System; // optional, for StringComparison

public class OpenExternalLinkVideo : MonoBehaviour
{
    [SerializeField] private string url;   // set per button in Inspector

    public void Open()
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            Application.OpenURL("https://youtu.be/VSBaIJyi0Ds");
            Debug.LogWarning("OpenExternalLink: URL was empty; opened default video.");
            return;
        }

        var toOpen = url.Trim();
        if (!toOpen.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            toOpen = "https://" + toOpen;

        Application.OpenURL(toOpen);
    }
}
