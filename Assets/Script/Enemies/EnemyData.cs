using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float detectionDistance;
    public float attackDistance;
}
