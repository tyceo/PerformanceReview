
using UnityEngine;
using UnityEngine.EventSystems;

public class IconController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int windowIndex; // Which window this icon controls
    private WindowManager windowManager;

    private void Awake()
    {
        windowManager = FindObjectOfType<WindowManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            windowManager.ShowWindow(windowIndex);
        }
    }
}