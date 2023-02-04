using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private bool[] items;
    [SerializeField] private LayerMask pedestal;

    private GameObject currPedestal;

    public bool looking { get; private set; }

    private void Start()
    {
        items = new bool[8];  
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        DetectPedestal();
    }

    private void DetectPedestal()
    {/*
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == 7)
            {
                hit.transform.gameObject.GetComponent<PlayParticles>().ParticlesOn();
            }
        }
        */

        if (Physics.Raycast(transform.position, transform.forward, out var hit, 100.0f, pedestal))
        {
            var obj = hit.collider.gameObject;
            obj.GetComponent<PlayParticles>().ParticlesOn();
            looking = true;
        }
        else 
        {
            looking = false;
        }
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (items[0] == true && looking == true)
            {
                PutPlant();
            }
            else
            {
                if (items[0] == false)
                {
                    Debug.Log("Plant Not Found");
                }
                else if(looking != true) 
                {
                    Debug.Log("Pedestal Not Found");
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            items[1] = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            items[2] = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            items[3] = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            items[4] = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            items[5] = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            items[6] = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            items[7] = false;
        }
    }

    private void PutPlant()
    {
        items[0] = false;
        //add add item command
        Parameters parameters = new Parameters();
        parameters.PutExtra(EventNames.PUT_PLANT, 0);
        EventBroadcaster.Instance.PostEvent(EventNames.PUT_PLANT, parameters);
    }

    private void PickUp()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == 6)
            {
                Debug.Log($"Hit {hit.transform.gameObject.name}");
                int ID = hit.transform.gameObject.GetComponent<NumberID>().ID;
                Debug.Log($"PickedUp {ID}");
                if (items[ID] == false)
                {
                    items[ID] = true;
                    Debug.Log($"PickedUp {ID}");
                }
                hit.transform.gameObject.SetActive(false);
            }
            
        }
        
    }
}
