using UnityEngine;
using UnityEngine.EventSystems;

public class TownClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            OpenMenu();
        }
    }

    void OpenMenu()
    {
        Debug.Log("Town Menu");
    }
}