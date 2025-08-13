using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject windowToClose;
    [SerializeField] private GameObject emailcanvas;
        

    private void OnMouseDown()
    {
        if (windowToClose != null)
        {
            windowToClose.SetActive(false);
        }
        if (gameObject.name == "xemail")
        {
            Debug.Log("Close button clicked for email window. Closing...");
        }
    }
}