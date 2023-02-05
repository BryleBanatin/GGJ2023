using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelOpen : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PLAYER_WIN, this.OpenPanel);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.PLAYER_WIN);
    }

    private void OpenPanel()
    {
        winPanel.SetActive(true);
    }
}
