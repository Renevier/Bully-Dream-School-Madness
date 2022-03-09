using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rule", menuName = "ScriptableObject/Rule", order = 0)]
public class Rule : ScriptableObject 
{
    public string letter;
    [SerializeField] private string[] result;
    [SerializeField] private bool randomResult = false;

    public string GetResult()
    {
        if(randomResult)
        {
            int randomIndex = Random.Range(0, result.Length);
            return result[randomIndex];
        }

        return result[0];
    }
}
