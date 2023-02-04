using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavAgent : MonoBehaviour
{
    NavMeshAgent agent;
    private int destPoint = 0;
    [SerializeField]
    Transform[] Room1;
    [SerializeField]
    Transform[] Room2;
    [SerializeField]
    Transform[] Room3;
    [SerializeField]
    Transform[] Room4;
    [SerializeField]
    Transform[] Room5;

    private List<int> visitedPoints = new List<int>();
    private Transform[] CurrentRoom;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Random.InitState(System.DateTime.Now.Millisecond);
        agent.autoBraking = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GotoNextPoint(Transform[] currentRoom)
    {
         
        // Returns if no points have been set up
        if (currentRoom.Length == 0)
            return;

        destPoint = Random.Range(0, currentRoom.Length);
        // Set the agent to go to the currently selected destination.

        //if (visitedPoints.Contains(destPoint))
        //{
        //    Random.Range(0, Points.Length);
        //}
        //else
        agent.destination = currentRoom[destPoint].position;
        visitedPoints.Add(destPoint);
        Debug.Log(destPoint);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Help " + other.gameObject.name);
        Debug.Log(Room1.Length);
        if (other.gameObject.name == "Room1")
        {
            Debug.Log("I'M IN ROOM 1");
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Debug.Log("Reached destination, moving");
                GotoNextPoint(Room1);
            }
        }
        else if (other.gameObject.name == "Room2")
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Debug.Log("Reached destination, moving");
                GotoNextPoint(Room2);
            }
        }
        else if (other.gameObject.name == "Room3")
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Debug.Log("Reached destination, moving");
                GotoNextPoint(Room3);
            }
        }
        else if (other.gameObject.name == "Room4")
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Debug.Log("Reached destination, moving");
                GotoNextPoint(Room4);
            }
        }
        else if (other.gameObject.name == "Room5")
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Debug.Log("Reached destination, moving");
                GotoNextPoint(Room5);
            }
        }
    }

}
