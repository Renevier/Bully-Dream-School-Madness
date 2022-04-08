using UnityEngine;

public class PunchTriggerScipt : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Collider col;

    private void Update()
    {
        col.isTrigger = player.isAttacking;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyGo = other.gameObject.GetComponent<Enemy>();
            enemyGo.TakeDamage(player.GetPlayerData().GetDamages());
        }
    }
}
