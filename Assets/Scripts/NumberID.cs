using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberID : MonoBehaviour
{
    [SerializeField] private int m_ID;
    public int ID { get; set; }
    private void Awake()
    {
        ID = m_ID;
    }
    
}
