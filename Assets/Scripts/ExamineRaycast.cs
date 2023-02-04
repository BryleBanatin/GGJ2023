using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class ExamineRaycast : MonoBehaviour
{
    public bool isExamining;
    private string lastItem;

    RaycastHit hit;
    [SerializeField] Camera PlayerCam;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject Book;

    private void Start()
    {
        Exit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ExamineItem();
        }
        LockCursorFunc();
    }

    private void ExamineItem()
    {
        if (Physics.Raycast(PlayerCam.transform.position, Camera.main.transform.forward, out hit, 100.0f))
        {
            if (hit.collider.tag == "Examinable")
            {
                Debug.Log(hit.collider.name + "Image");
                if (UI.transform.Find(hit.collider.name + "Image"))
                {
                    GameObject ObjSprite = GameObject.Find(hit.collider.name + "Image");
                    lastItem = hit.collider.name + "Image";
                    Image[] ObjImage = ObjSprite.GetComponentsInChildren<Image>();
                    Debug.Log(ObjImage.Length);
                    foreach (Image i in ObjImage)
                    {
                        if (i.gameObject.tag != "ItemBtn")
                        i.enabled = true;
                    }
                    Exit.gameObject.SetActive(true);
                    isExamining = true;
                }
            }
        }
    }

    public void HideItem()
    {
        GameObject ObjSprite = GameObject.Find(lastItem);
        Image ObjImage = ObjSprite.GetComponentInChildren<Image>();
        ObjImage.enabled = false;

    }
    private void LockCursorFunc()
    {
        FirstPersonController fpsController = this.gameObject.GetComponent<FirstPersonController>();
        BookManager bookManager = Book.gameObject.GetComponent<BookManager>();
        if (isExamining == true)
        {
            Cursor.lockState = CursorLockMode.None;
            fpsController.playerCanMove = false;
            fpsController.lockCursor = false;
            fpsController.cameraCanMove = false;
            fpsController.enableHeadBob = false;
            fpsController.enableZoom = false;
        }
        else if (isExamining == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            fpsController.playerCanMove = true;
            fpsController.lockCursor = true;
            fpsController.cameraCanMove = true;
            fpsController.enableHeadBob = true;
            fpsController.enableZoom = true;
        }
    }
}
