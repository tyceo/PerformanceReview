using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject windowToClose;

    private void OnMouseDown()
    {
        if (windowToClose != null)
        {
            windowToClose.SetActive(false);
        }
    }
}