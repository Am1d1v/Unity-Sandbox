using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TownClick : MonoBehaviour, IPointerClickHandler
{
    [Header("Settings")]
    [SerializeField] string townName;
    [SerializeField] bool isInsideTown;

    public void OnPointerClick(PointerEventData eventData)
    {        
        if(eventData.clickCount == 2)
        {
            OpenMenu();
        }
    }

    void OpenMenu()
    {
        if (isInsideTown) return;

        SceneManager.LoadScene(townName, LoadSceneMode.Additive);

        isInsideTown = true;
    }
}