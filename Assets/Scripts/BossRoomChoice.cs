using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoomChoice : MonoBehaviour
{
    [SerializeField] private List<Vector3> RoomList;
    [SerializeField] private float _chooseTimer;
    private int previousRoom = -1;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetRandomRoom();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= _chooseTimer)
        {
            Debug.Log("Changing Room!");
            GetRandomRoom();
            currentTime= 0;
        }
        currentTime += Time.deltaTime;
    }

    private void GetRandomRoom()
    {
        int rand = GetRandomNumber(previousRoom); 
        Vector3 newPosition = RoomList[rand];
        Debug.Log(newPosition);
        this.transform.position = newPosition;
        this.GetComponent<BossSpawn>().SpawnSequence();
    }

    private int GetRandomNumber(int previousRoom)
    {
        int rand = Random.Range(0, 5);

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
