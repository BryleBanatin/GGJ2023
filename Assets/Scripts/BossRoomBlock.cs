using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomBlock : MonoBehaviour
{
    [SerializeField] private float _chooseTimer;
    [SerializeField] private int MaxRooms;

    private float currentTime = 0;
    private int previousRoom = -1;
    int roomNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BossRoomChoice bossFlag = this.gameObject.GetComponent<BossRoomChoice>();
        if (currentTime >= _chooseTimer && bossFlag.Showtime == true)
        {
            Debug.Log("Blocking Room!");
            RoomBlock(GetRandomNumber(previousRoom));
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }

    private void RoomBlock(int RoomNum)
    {
        GameObject Room = GameObject.Find("Room" + RoomNum);
        GameObject[] WallEnemy = GameObject.FindGameObjectsWithTag("WallEnemy");
        Debug.Log(Room);
        Debug.Log(Room.transform.childCount);
        GameObject[] AllWalls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wallNonBlock in AllWalls)
        {
            wallNonBlock.SetActive(false);
        }

        foreach (GameObject gameObject in WallEnemy)
        {
            gameObject.SetActive(false);
        }

        for (int i = 0; i < Room.transform.childCount; i++)
        {
            Transform childWall = Room.transform.GetChild(i);
            childWall.gameObject.SetActive(true);
            Debug.Log(childWall.gameObject.name);
        }
    }
    private int GetRandomNumber(int previousRoom)
    {
        int rand = Random.Range(1, MaxRooms);
        Debug.Log(rand);
        if (rand != previousRoom)
        {
            return rand;
        }
        else
        {
            Debug.Log("Duplicate");
            return GetRandomNumber(previousRoom);
        }

    }

}
