using UnityEngine;
using UnityEngine.AI;

public class PedestrianManager : MonoBehaviour
{
    [SerializeField] NavMeshAgent enemie;
    [SerializeField] GameObject[] waypoints;

    public NavMeshAgent GetEnemie() => enemie; 
    public GameObject[] GetWaypoints() => waypoints; 

}
