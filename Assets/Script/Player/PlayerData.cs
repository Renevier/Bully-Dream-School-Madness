using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField, Range(0,1000)] private float maxHealth = 10;

    [Header("Energy")]
    [SerializeField, Range(0,1000)] private float maxEnergy = 10;
    [SerializeField] private float energyWin = .01f;
    [SerializeField] private float energyLost = .1f;

    [Header("Degats")]
    [SerializeField, Range(0, 100)] private float damage = 0f;
    [SerializeField, Range(.1f, .5f)] private float punchDistance = 0f;
    [SerializeField] private GameObject proj;

    [SerializeField, Range(0, 5)] private float speed = 0f;


    [HideInInspector] public Vector3 movement;
    [HideInInspector] public float rotationFactorPerFrame = 15.0f;

    public float GetMaxHealth() => maxHealth;
    public float GetMaxEnergy() => maxEnergy;
    public float GetEnergyWin() => energyWin;
    public float GetEnergyLost() => energyLost;
    public float GetDamages() => damage;
    public float GetSpeed() => speed;
    public GameObject GetProj() => proj;
    public float GetPunchDistance() => punchDistance;
}
