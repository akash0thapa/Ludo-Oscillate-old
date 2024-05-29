using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public bool canMove;
    public bool moveNow;
    public bool isReady;
    public int numberOfStepsAlreadyMoved=0;
    public PathPointsParent pathPoints;

    private void Awake()
    {
        pathPoints=FindObjectOfType<PathPointsParent>();
    }
}
