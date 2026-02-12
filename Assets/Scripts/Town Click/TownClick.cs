using UnityEngine;
using UnityEngine.EventSystems;

public class TownClick : MonoBehaviour, IPointerClickHandler
{
    //private void OnMouseDown()
    //{
    //    Debug.Log("Town Clicked");
    //}

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