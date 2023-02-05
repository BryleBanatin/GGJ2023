using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoomChoice : MonoBehaviour
{
    [SerializeField] private List<Vector3> RoomList;
    [SerializeField] private float _chooseTimer;
    [SerializeField] GameObject _playerRoom;
    [SerializeField] GameObject player;
    [SerializeField] private GameObject bossUnit;
    private bool Showtime; //Monster spawn
    /* South West Room = Element 0
       South Room = Element 1
       East Room = Element 2
       North Room = Element 3
    */
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetItem obtainedItem = player.gameObject.GetComponent<GetItem>();
        Debug.Log(obtainedItem.currObject);
        
        if (obtainedItem.currObject != null)
        {
            Showtime = true;
        }
        Debug.Log(Showtime);
        if (Showtime == true && bossUnit.activeSelf == false)
        {
            Debug.Log("Changing Room!");
            GetRandomRoom();
        }
    }

    private void GetRandomRoom()
    {
        PlayerLocationHandler playerLocationHandler = _playerRoom.GetComponent<PlayerLocationHandler>();
        int rand = GetRandomNumber(playerLocationHandler.CurrentRoomLocale()); 
        Vector3 newPosition = RoomList[rand];
        Debug.Log(newPosition);       
        this.transform.position = newPosition;
        this.GetComponent<BossSpawn>().SpawnSequence();
    }

    private int GetRandomNumber(int previousRoom)
    {
        PlayerLocationHandler playerLocationHandler = _playerRoom.GetComponent<PlayerLocationHandler>();
        int rand = Random.Range(0, RoomList.Count);
        Debug.Log(rand);
        if (rand != previousRoom)
        {
            return rand;
        }
        else if (rand == 0 && playerLocationHandler.CurrentLocation == "South West Room")
        {
            return GetRandomNumber(previousRoom);
        }
        else if (rand == 1 && playerLocationHandler.CurrentLocation == "South Room")
        {
            return GetRandomNumber(previousRoom);
        }
        else if (rand == 2 && playerLocationHandler.CurrentLocation == "East Room")
        {
            return GetRandomNumber(previousRoom);
        }
        else if (rand == 3 && playerLocationHandler.CurrentLocation == "North Room")
        {
            return GetRandomNumber(previousRoom);
        }
        else 
        {
            Debug.Log("Duplicate");
            return GetRandomNumber(previousRoom);
        }

    }

}
