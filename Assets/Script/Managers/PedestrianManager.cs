using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianManager : MonoBehaviour
{
    [SerializeField] GameObject enemie;
    [SerializeField] GameObject[] waypoints;

    public GameObject GetEnemie() => enemie; 
    public GameObject[] GetWaypoints() => waypoints; 

}
