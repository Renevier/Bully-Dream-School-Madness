using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTriggerScipt : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyGo = other.gameObject.GetComponent<Enemy>();
            enemyGo.TakeDamage(player.damage);
        }
    }
}
