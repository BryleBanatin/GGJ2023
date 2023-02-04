using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Mixer : MonoBehaviour
{
    [SerializeField] private PedestalBehavior tower1;
    [SerializeField] private PedestalBehavior tower2;
    [SerializeField] private List<Material> colors;
    [SerializeField] private List<GameObject> potions;
    // 0 = Red, 1 = Blue, 2 = Yellow, 3 = Green, 4 = Violet, 5 = Success, 6 = White
    [SerializeField] private GameObject result;
    private GameObject Spawned;
    Vector3 offset = new Vector3(0f, 3.0f, 0f);

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PUT_PLANT, this.CheckCombination);
    }
    public void CheckCombination() 
    {
        if (tower1.plantID == 2 && tower2.plantID == 7
            || tower1.plantID == 7 && tower2.plantID == 2)
        {
            // this.GetComponent<Renderer>().material = colors[0]; // blue
            tower1.Clear();
            tower2.Clear();
            Spawned = Instantiate(potions[0], transform.position + offset, Quaternion.identity);
        }
        else if (tower1.plantID == 5 && tower2.plantID == 0
            || tower1.plantID == 0 && tower2.plantID == 5)
        {
            // this.GetComponent<Renderer>().material = colors[1]; // red
            tower1.Clear();
            tower2.Clear();
            Spawned = Instantiate(potions[1], transform.position + offset, Quaternion.identity);
        }
        else if (tower1.plantID == 6 && tower2.plantID == 1
            || tower1.plantID == 1 && tower2.plantID == 6)
        {
            //   this.GetComponent<Renderer>().material = colors[2]; // yellow
            tower1.Clear();
            tower2.Clear();
            Spawned = Instantiate(potions[2], transform.position + offset, Quaternion.identity);
        }
        else if (tower1.plantID == 9 && tower2.plantID == 8
            || tower1.plantID == 8 && tower2.plantID == 9)
        {
            //  this.GetComponent<Renderer>().material = colors[3]; //Green
            tower1.Clear();
            tower2.Clear();
            Spawned = Instantiate(potions[3], transform.position + offset, Quaternion.identity);
        }
        else if (tower1.plantID == 8 && tower2.plantID == 10
            || tower1.plantID == 10 && tower2.plantID == 8)
        {
            //  this.GetComponent<Renderer>().material = colors[4]; //Violet
            tower1.Clear();
            tower2.Clear();
            Spawned = Instantiate(potions[4], transform.position + offset, Quaternion.identity);
        }
        else if (tower1.plantID == 11 && tower2.plantID == 12
            || tower1.plantID == 12 && tower2.plantID == 11)
        {
            // this.GetComponent<Renderer>().material = colors[5]; //Success
            tower1.Clear();
            tower2.Clear();
            Spawned = Instantiate(potions[5], transform.position + offset, Quaternion.identity);
        }
        else 
        {
            this.GetComponent<Renderer>().material = colors[6]; //Default
            if (tower1.IsFilled == true && tower2.IsFilled == true)
            {
                Clear();
            }
        }

        
    }

    private void Clear()
    {
        GameObject.Destroy(Spawned);
        this.GetComponent<Renderer>().material = colors[6];
        tower1.Clear();
        tower2.Clear();
    }
}
