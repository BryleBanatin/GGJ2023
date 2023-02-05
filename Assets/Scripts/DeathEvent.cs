using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DeathEvent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] VideoPlayer Video;
    [SerializeField] GameObject DeathScreen;
    private bool isDead = false;
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Video.loopPointReached += ChangeScene;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You are dead, no big surprise");
            DeathScreen.SetActive(true);
            PlayVideo();
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
