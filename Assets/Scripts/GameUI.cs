using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Image[] _levelPartUI;

    public void ShowPartLevelUI(int count)
    {
        for (int i = 0; i < count ; i++)
        {
            _levelPartUI[i].gameObject.SetActive(true);
        }
    }
}
