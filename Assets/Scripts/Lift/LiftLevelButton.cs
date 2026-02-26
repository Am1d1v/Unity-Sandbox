using System;
using UnityEngine;

public class LiftLevelButton : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject level;

    [Header("Actions")]
    public static Action<GameObject> onLiftLevelButtonClicked;


    private void OnMouseDown()
    {
        onLiftLevelButtonClicked?.Invoke(level);
    }
}