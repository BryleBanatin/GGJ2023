using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelOpen : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject FPSController;

    private bool WinFlag = false;

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
        WinFlag = true;
        LockCursor();

    }

    private void LockCursor()
    {
        Debug.Log("CALLED");
      FirstPersonController fpsController = FPSController.gameObject.GetComponent<FirstPersonController>();
        ExamineRaycast examine = FPSController.gameObject.GetComponent<ExamineRaycast>();
        examine.isExamining = true;
        Cursor.lockState = CursorLockMode.None;
                fpsController.playerCanMove = false;
                fpsController.lockCursor = false;
                fpsController.cameraCanMove = false;
                fpsController.enableHeadBob = false;
                fpsController.enableZoom = false;
    }
}
