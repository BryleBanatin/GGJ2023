using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private LayerMask pedestal;
    [SerializeField] private LayerMask plant;
    [SerializeField] public GameObject currPedestal { get; set; }
    [SerializeField] private GameObject currObject = null;

    public bool looking { get; private set; }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currObject != null && currPedestal != null)
            {
                PutPlant();
            }
            /*
            else if (currObject != null && looking == false)
            {
                //ThrowOut();
            }
            */
            else if (currObject == null)
            {
                PickUp();
            }
        }
    }

    private void PutPlant()
    {
        currPedestal.GetComponent<PedestalBehavior>().Plant(currObject.GetComponent<NumberID>().ID);
        currObject = null;
        EventBroadcaster.Instance.PostEvent(EventNames.PUT_PLANT);
    }

    private void PickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5.0f, plant))
        {
            currObject = hit.transform.gameObject;
            Debug.Log(currObject.GetComponent<NumberID>().ID);
            hit.transform.gameObject.SetActive(false);
        }
    }
}
