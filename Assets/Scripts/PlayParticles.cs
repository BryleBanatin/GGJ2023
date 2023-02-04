using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.PUT_PLANT, this.Plant);
    }

    public void ParticlesOn()
    {
        particles.Play();
    }

    public void ParticlesOff()
    {
        particles.Stop();
    }

    private void Plant(Parameters parameters)
    {
        int index = parameters.GetIntExtra(EventNames.PUT_PLANT, -1);
        switch (index) 
        {
            case 0:
                this.transform.Find("PlantContainer").Find("0").gameObject.SetActive(true);
                break;
        }
    }
}
