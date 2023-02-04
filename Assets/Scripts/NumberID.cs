using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberID : MonoBehaviour
{
    [SerializeField] private PlantID data;
    public int ID { get; set; }
    private void Awake()
    {
        ID = data.id;
        GetComponent<SpriteRenderer>().sprite = data.sprite;
    }
    
}
