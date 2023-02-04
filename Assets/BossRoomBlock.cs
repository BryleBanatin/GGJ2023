using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomBlock : MonoBehaviour
{
    [SerializeField] private float _chooseTimer;
    [SerializeField] private float MaxRooms;

    private float currentTime = 0;

    int roomNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= _chooseTimer)
        {
            Debug.Log("Blocking Room!");
            RoomBlock(roomNumber);
            currentTime = 0;
            roomNumber++;
        }
        currentTime += Time.deltaTime;
        if (roomNumber > 1)
        {
            roomNumber = 0;
        }
    }

    private void RoomBlock(int RoomNum)
    {
        GameObject Room = GameObject.Find("Room" + RoomNum);
        GameObject Wall = Room.transform.Find("WallDead").gameObject;
        GameObject[] AllWalls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wallNonBlock in AllWalls)
        {
            wallNonBlock.SetActive(false);
        }

        Wall.SetActive(true);
    }

}
