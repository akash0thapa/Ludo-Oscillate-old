using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public RollingDice rolledDice;
    public bool canPlayerMove = false;
    public int moveSteps;
    public int alreadyMoved;
    public List<PathPoints> playersOnPathPoints=new List<PathPoints>();
    public bool canDiceRoll=true;
    public bool transferDice = false;

   public List<RollingDice> rollingDiceList;
    public List<PlayerPiece> playerPieceList;

    public int bluePlayerOut;
    public int redPlayerOut;
    public int greenPlayerOut;
    public int yellowPlayerOut;
    private void Awake()
    {
        gameManager=this;
        rollingDiceList[0].playerPiece = playerPieceList[0];
        rollingDiceList[1].playerPiece = playerPieceList[1];
        rollingDiceList[2].playerPiece = playerPieceList[2];
        rollingDiceList[3].playerPiece = playerPieceList[3];
    }

    public void AddPoint(PathPoints point)
    {
        playersOnPathPoints.Add(point);
    } 
    
    public void RemovePoint(PathPoints point)
    {
        if (playersOnPathPoints.Contains(point)) {
            playersOnPathPoints.Remove(point);
        }
    }

    public void rollingDiceTransfer()
    {
        if (transferDice && moveSteps!=0)
        {
            int nextDice;  
            for (int i = 0; i < rollingDiceList.Count; i++)
            {
                if (i == rollingDiceList.Count - 1) { nextDice = 0; } else { nextDice = i + 1; }
                if (rolledDice == rollingDiceList[i]) {
                    rollingDiceList[i].gameObject.SetActive(false);
                    rollingDiceList[nextDice].gameObject.SetActive(true);   
                
                }
            }
        }
            canDiceRoll = true;
            transferDice = false;
    }
}
