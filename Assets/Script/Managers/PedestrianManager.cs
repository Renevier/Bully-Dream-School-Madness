using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] waypoints;

    public GameObject[] GetEnemies() => enemies; 
    public GameObject[] GetWaypoints() => waypoints; 

}
