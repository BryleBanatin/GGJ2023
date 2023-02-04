using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PedestalBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> plantList;
    [SerializeField] private ParticleSystem particles;
    private GameObject Spawned; 
    public bool IsFilled { get; set; } 
    public bool lookedAt { get; set; }
    public int plantID { get; set; }

    private void Awake()
    {
        lookedAt = false;
        IsFilled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            lookedAt = true;
            other.gameObject.GetComponent<GetItem>().currPedestal = this.gameObject;
            particles.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            lookedAt = false;
            other.gameObject.GetComponent<GetItem>().currPedestal = null;
            particles.Stop();
        }
    }

    public void Plant(int index)
    {

        Vector3 offset = new Vector3(0f, 3.0f, 0f);
        plantID = index;
        Spawned = Instantiate(plantList[index], transform.position + offset, Quaternion.identity);
        Debug.Log(Spawned.name);
        IsFilled = true;
    }

    public void Clear()
    {
        GameObject.Destroy(Spawned);
        IsFilled= false;
    }
}
