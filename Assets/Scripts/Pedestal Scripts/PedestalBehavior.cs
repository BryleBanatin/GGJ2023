using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalBehavior : MonoBehaviour
{
    public bool IsFilled { get; set; } 
    public bool lookedAt { get; set; }

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PUT_PLANT, this.Plant);
        lookedAt = false;
        IsFilled = false;
    }


    private void Plant(Parameters parameters)
    {
        int index = parameters.GetIntExtra(EventNames.PUT_PLANT, -1);
        if (lookedAt == false) { return; }

        switch (index)
        {
            case 0:
                this.transform.Find("PlantContainer").Find("0").gameObject.SetActive(true);
                break;
        }

        IsFilled = true;
    }
}
