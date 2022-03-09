using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlacement : MonoBehaviour
{
    public GameObject roadStraight, roadCurve, road3Way, road4Way, roadEnd;
    Dictionary< Vector3, GameObject> roads = new Dictionary< Vector3, GameObject>();

    public void PlaceRoads(Vector3 start, Vector3Int direction, float length)
    {
        var rotation = Quaternion.identity;

        if(direction.x == 0)
            rotation = Quaternion.Euler(0, 90, 0);

        for(int i = 0; i < length; i++)
        {
            Vector3Int position = Vector3Int.RoundToInt(start + direction * i);

            if (roads.ContainsKey(position))
                continue;

            GameObject road = Instantiate(roadStraight, position, rotation, transform);
            roads.Add(position, road);
        }
    }
}
