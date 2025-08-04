using Unity.VisualScripting;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows; // Assign all window GameObjects in inspector

    [SerializeField] private GameObject TypingGameUIToClose;
    [SerializeField] private GameObject BuzzFeedUIToClose;
    public GameObject TypingGame;  
    public GameObject BuzzFeed;

    public void ShowWindow(int windowIndex)
    {
        // Hide all windows first
        foreach (GameObject window in windows)
        {
            window.SetActive(false);
        }

        // Show the selected window if index is valid
        if (windowIndex >= 0 && windowIndex < windows.Length)
        {
            windows[windowIndex].SetActive(true);
        }
    }

    // Optional: Method to hide all windows
    public void HideAllWindows()
    {
        foreach (GameObject window in windows)
        {
            window.SetActive(false);
        }
    }

    public void Update()
    {
        if (!TypingGame.activeInHierarchy)
        {
            TypingGameUIToClose.SetActive(false);
        }

        if (TypingGame.activeInHierarchy)
        {
            TypingGameUIToClose.SetActive(true);
        }

          if (!BuzzFeed.activeInHierarchy)
        {
            BuzzFeedUIToClose.SetActive(false);
        }

        if (BuzzFeed.activeInHierarchy)
        {
            BuzzFeedUIToClose.SetActive(true);
        }
;
    }
}