using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public bool canMove;
    public bool moveNow;
    public int numberOfStepsToMove;
    public PathPointsParent pathPoints;

    private void Awake()
    {
        pathPoints=FindObjectOfType<PathPointsParent>();
    }
}
