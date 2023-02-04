using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] GameObject Book;
    [SerializeField] GameObject FPSHandler;
    // Start is called before the first frame update
    void Start()
    {
        Book.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ExamineRaycast examineRaycast = FPSHandler.GetComponent<ExamineRaycast>();
        FirstPersonController fpsController = FPSHandler.gameObject.GetComponent<FirstPersonController>();

        if (Input.GetKeyDown(KeyCode.Q) && examineRaycast.isExamining == false)
          {
            Book.SetActive(true);
            examineRaycast.isExamining = true;
          }
        else if (Input.GetKeyDown(KeyCode.Q) && examineRaycast.isExamining == true)
          {
             Book.SetActive(false);
             examineRaycast.isExamining = false;
          }
    }
}
