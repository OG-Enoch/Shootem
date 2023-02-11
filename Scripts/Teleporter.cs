using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform[] destination;
    Transform currentDestination;
 
    public Transform GetDestination()
    {
        for(int i = 0; i < destination.Length; i++)
        {
            currentDestination = destination[i];
        }
        return currentDestination;
    }
}
