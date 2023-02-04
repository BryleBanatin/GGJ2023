using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Mixer : MonoBehaviour
{
    [SerializeField] private PedestalBehavior tower1;
    [SerializeField] private PedestalBehavior tower2;
    [SerializeField] private List<Material> colors;
    // add list here
    [SerializeField] private GameObject result;

    private void Update()
    {
        if (tower1.IsFilled == true && tower2.IsFilled == true)
        {
            this.GetComponent<Renderer>().material = colors[0];
        }
    }
}
