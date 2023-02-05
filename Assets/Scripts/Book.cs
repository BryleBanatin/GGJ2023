using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;
    [SerializeField] private GameObject Forward;
    [SerializeField] private GameObject Backward;

    public void FlipForward()
    {
        Forward.SetActive(false);
        Backward.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(true);
    }

    public void FlipBackward()
    {
        Forward.SetActive(true);
        Backward.SetActive(false);
        page1.SetActive(true);
        page2.SetActive(false);
    }
}
