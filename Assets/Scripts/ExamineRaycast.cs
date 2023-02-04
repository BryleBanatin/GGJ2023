using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class ExamineRaycast : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Camera PlayerCam;
    [SerializeField] GameObject UI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(PlayerCam.transform.position, Camera.main.transform.forward, out hit, 100.0f ))
            {
                if (hit.collider.tag == "Examinable")
                {
                    Debug.Log(hit.collider.name + "Image");
                    if (UI.transform.Find(hit.collider.name + "Image"))
                    {
                        GameObject ObjSprite = GameObject.Find(hit.collider.name + "Image");
                        Image[] ObjImage = ObjSprite.GetComponentsInChildren<Image>();
                        Debug.Log(ObjImage.Length);
                        foreach(Image i in ObjImage)
                        {
                            i.enabled = true;
                        }    
                    }
                }
            }
        }

    }
}
