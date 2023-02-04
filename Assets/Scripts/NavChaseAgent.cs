using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavChaseAgent : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] BossSpawn bossSpawn;
    [SerializeField] GameObject Player;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private float distanceLimit;
    [SerializeField] GameObject Boss;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        BossSpawn bossSpawn = Boss.GetComponent<BossSpawn>();
        agent.SetDestination(Player.transform.position);
        Debug.Log(agent.remainingDistance);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You are dead, no big surprise");
        }
    }
}
