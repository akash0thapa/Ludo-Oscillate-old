using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public RollingDice rolledDice;
    public int moveSteps;
    public List<Vector2> positions=new List<Vector2>();

    private void Awake()
    {
        gameManager=this;

    }

    public void AddPoint(Vector2 point)
    {
        positions.Add(point);
    } 
    
    public void RemovePoint(Vector2 point)
    {
        if (positions.Contains(point)) {
            positions.Remove(point);
        }
    }
}
