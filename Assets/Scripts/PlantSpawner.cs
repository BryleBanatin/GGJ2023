using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    private GameObject Spawned;
    private Vector3 offset = new Vector3(0.0f, 5.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlant();
    }

    private void SpawnPlant()
    {
        Spawned = Instantiate(plantPrefab, transform.position + offset, Quaternion.identity);
        if (Spawned.GetComponent<NumberID>().ID >= 8)
        {
            Spawned.SetActive(false);
        }
    }

    public void RegenPlant()
    {
        Spawned.SetActive(true);
    }

    
}
