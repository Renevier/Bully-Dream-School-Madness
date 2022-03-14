using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    public GameObject GetPlayer() => player;
}
