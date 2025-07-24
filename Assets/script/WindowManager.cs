using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows; // Assign all window GameObjects in inspector

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
}