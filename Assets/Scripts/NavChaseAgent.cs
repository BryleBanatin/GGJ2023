using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class NavChaseAgent : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject Player;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private float distanceLimit;
    [SerializeField] GameObject Boss;
    [SerializeField] VideoPlayer Video;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] AudioSource scream;
    private float currentTime = 0;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);
        Debug.Log(agent.remainingDistance);
        Video.loopPointReached += ChangeScene;

        if (agent.remainingDistance < 20.0f)
        {
            scream.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You are dead, no big surprise");
            DeathScreen.SetActive(true);
            PlayVideo();
            this.gameObject.GetComponent<Collider>().enabled = false;
            agent.isStopped = true;
        }
    }

    void ChangeScene(VideoPlayer vp)
    {
        if (!isDead)
        {
            SceneManager.LoadScene("MainScene");
            isDead = true;
        }

    }

    void PlayVideo()
    {
        Video.Play();
    }
}