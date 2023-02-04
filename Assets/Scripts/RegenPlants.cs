using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenPlants : MonoBehaviour
{
    [SerializeField] private List<GameObject> basicPotions;
    [SerializeField] private List<GameObject> advancedPotions;
    [SerializeField] private GameObject plants;
    [SerializeField] private Mixer progressCheck;

    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.REGEN_PLANT, this.Regen);
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.REGEN_PLANT);
    }

    private void Regen()
    {
        foreach (Transform plant in plants.transform)
        {
            plant.gameObject.SetActive(true);
        }
        if (progressCheck.Blue == true)
        {
            basicPotions[0].SetActive(true);
        }
        if (progressCheck.Yellow == true)
        {
            basicPotions[1].SetActive(true);
        }
        if (progressCheck.Red == true)
        {
            basicPotions[2].SetActive(true);
        }
        if (progressCheck.Green == true)
        {
            advancedPotions[0].SetActive(true);
        }
        if (progressCheck.Violet == true)
        {
            advancedPotions[1].SetActive(true);
        }
        if (progressCheck.Pink == true)
        {
            advancedPotions[2].SetActive(true);
        }
    }
}
