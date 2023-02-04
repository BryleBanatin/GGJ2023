using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class BossSpawn : MonoBehaviour
{
    private float currentTime = 0;
    [SerializeField] private float _soundTimer;
    [SerializeField] private float _particlesTimer;

    //[SerializeField] private AudioSource firecrackerSFXSource;
    [SerializeField] private ParticleSystem sparkleParticle;
    [SerializeField] private Animator spawn;


    private void Start()
    {
        //StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //Debug.Log("PEW PEW");
        //add SFX here
        yield return new WaitForSeconds(_soundTimer);

        //Debug.Log("KIRA KIRA");
        //add ParticleFX here
        sparkleParticle.Play();

        yield return new WaitForSeconds(_particlesTimer);
        spawn.SetBool("GoUp", true);
        //Debug.Log("DON DON");
        //Boss Spawn / Animation
    }

    public void SpawnSequence()
    {
        StartCoroutine(Spawn());
    }

}
