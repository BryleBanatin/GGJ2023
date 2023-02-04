using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationHandler : MonoBehaviour
{
    public string CurrentLocation;

    public int CurrentRoomLocale()
    {
        int i = 5;
        if (CurrentLocation == "South West Room")
        {
            i = 0;
        }
        else if (CurrentLocation == "South Room")
        {
            i = 1;
        }
        else if (CurrentLocation == "East Room")
        {
            i = 2;
        }
        else if (CurrentLocation == "North Room")
        {
            i = 3;
        }

        return i;
    }
}
