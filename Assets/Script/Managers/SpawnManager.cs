using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] PedestrianManager em;
    [SerializeField] Transform[] spawners;
    [SerializeField] int maxEnemies = 0;
    [SerializeField] float timeBeetweenSpawn = 0;

    int nbEnemies = 0;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (nbEnemies < maxEnemies)
            SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (timer >= timeBeetweenSpawn)
        {
            foreach(Transform spawner in spawners)
            Spawner(spawner);
        }

    }

    private void Spawner(Transform spawner)
    {
        Vector3 newRotation = new Vector3(0, Random.Range(0, 360), 0);

        timer = 0;
        NavMeshAgent agent = Instantiate(em.GetEnemie());
        if(NavMesh.SamplePosition(spawner.transform.position, out NavMeshHit hit, 5f, -1))
        {
            agent.Warp(hit.position);
        }
        agent.transform.rotation = spawner.rotation;
        nbEnemies++;
    }
}
