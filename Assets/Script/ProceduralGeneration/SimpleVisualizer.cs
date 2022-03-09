using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVisualizer : MonoBehaviour
{
    public enum ENCODING_LETTER
    {
        SAVE = '[',
        LOAD = ']',
        DRAW = 'F',
        TURN_RIGHT = '+',
        TURN_LEFT = '-'
    }

    public LSystemGenerator lSystem;
    private List<Vector3> positions = new List<Vector3>();

    public RoadPlacement placement;

    private float lenght = 8;
    private float angle = 90;

    public float Lenght
    {
        get
        {
            if (lenght > 0)
                return lenght;
            else
                return 1;
        }
        set => lenght = value;
    }

    private void Start()
    {
        string sequence = lSystem.GenerateSentence();
        VisualizeSequence(sequence);
    }

    private void VisualizeSequence(string sequence)
    {
        Stack<AgentParameters> savePoints = new Stack<AgentParameters>();
        Vector3 currentPosition = Vector3.zero;

        Vector3 direction = Vector3.forward;
        Vector3 tmpPosition = Vector3.zero;

        positions.Add(currentPosition);

        foreach (char letter in sequence)
        {
            ENCODING_LETTER encodingLetter = (ENCODING_LETTER)letter;

            switch (encodingLetter)
            {
                case ENCODING_LETTER.SAVE:
                    savePoints.Push(new AgentParameters
                    {
                        position = currentPosition,
                        direction = direction,
                        lenght = Lenght
                    });
                    break;
                case ENCODING_LETTER.LOAD:
                    if (savePoints.Count > 0)
                    {
                        AgentParameters agentParameter = savePoints.Pop();
                        currentPosition = agentParameter.position;
                        direction = agentParameter.direction;
                        Lenght = agentParameter.lenght;
                    }
                    else
                        throw new Exception("Don't have saved point in our stack");
                    break;
                case ENCODING_LETTER.DRAW:
                    tmpPosition = currentPosition;
                    currentPosition += direction * lenght;
                    placement.PlaceRoads(tmpPosition, Vector3Int.RoundToInt(direction), Lenght);
                    Lenght -= 1f;
                    positions.Add(currentPosition);
                    break;
                case ENCODING_LETTER.TURN_RIGHT:
                    direction = Quaternion.AngleAxis(angle, Vector3.up) * direction;
                    break;
                case ENCODING_LETTER.TURN_LEFT:
                    direction = Quaternion.AngleAxis(-angle, Vector3.up) * direction;
                    break;
                default:
                    break;
            }

        }

    }
}
