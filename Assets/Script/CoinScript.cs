using UnityEngine;

public class CoinScript : MonoBehaviour
{
    GameManager gm;

    private void Awake()
    {
        gm = GetComponentInParent<Enemy>().GetGM();
        transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            gm.AddCoin(1);
            Destroy(gameObject);
        }
    }
}
