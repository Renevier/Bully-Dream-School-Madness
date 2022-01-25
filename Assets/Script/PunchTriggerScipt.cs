using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTriggerScipt : MonoBehaviour
{
    [SerializeField] private CharacterController player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemies"))
        {

        }
    }
}
