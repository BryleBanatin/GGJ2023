using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    [SerializeField] GameObject PlayerLocationHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLocationHandler playerLocationHandler = PlayerLocationHandler.GetComponent<PlayerLocationHandler>();
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.name == "North Collider")
            {
                playerLocationHandler.CurrentLocation = "North Room";
            }
            else if (this.gameObject.name == "South Collider")
            {
                playerLocationHandler.CurrentLocation = "South Room";
            }
            else if (this.gameObject.name == "East Collider")
            {
                playerLocationHandler.CurrentLocation = "East Room";
            }
            else if (this.gameObject.name == "South West Collider")
            {
                playerLocationHandler.CurrentLocation = "South West Room";
            }
            Debug.Log("Player is in " + playerLocationHandler.CurrentLocation);

        }
    }
}
