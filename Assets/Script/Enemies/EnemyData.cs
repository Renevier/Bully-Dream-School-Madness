using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField, Range(0, 10)] private float speed;
    [Header("Aera")]
    [SerializeField, Range(0, 10)] private float detectionDistance;
    [SerializeField, Range(0, 10)] private float attackDistance;
    [Header("Patrol")]
    [SerializeField, Range(0, 10)] private float walkRadius;

    [SerializeField] private GameObject coin;

    public float GetMaxHealth() => maxHealth;
    public float GetSpeed() => speed;
    public float GetDetectionDistance() => detectionDistance;
    public float GetAttackDistance() => attackDistance;
    public float GetWalkRadius() => walkRadius;
    public GameObject GetCoin() => coin;

}
