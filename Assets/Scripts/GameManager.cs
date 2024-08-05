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

    public int totalPlayersNumbers;
    public List<GameObject>playersHomes;

    public AudioSource audioPlay;
    public bool sound = true;

    private void Awake()
    {
        gameManager=this;
        for (int i=0; i < rollingDiceList.Count; i++){
            rollingDiceList[i].playerPiece = playerPieceList[i];
        }
        audioPlay=GetComponent<AudioSource>();
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
            TransferRollingDice();

        }    
            canDiceRoll = true;
            transferDice = false;
    }
    public void TransferRollingDice()
    {
        switch (totalPlayersNumbers) { 
        case 2:
                if (rolledDice == rollingDiceList[0])
                {
                    rollingDiceList[0].gameObject.SetActive(false);
                    rollingDiceList[2].gameObject.SetActive(true);
                }
                else
                {
                    rollingDiceList[2].gameObject.SetActive(false);
                    rollingDiceList[0].gameObject.SetActive(true);
                }
                break;


        case 4:
                int nextDice;
                for (int i = 0; i < rollingDiceList.Count; i++)
                {
                    if (i == rollingDiceList.Count - 1) { nextDice = 0; } else { nextDice = i + 1; }
                    if (rolledDice == rollingDiceList[i])
                    {
                        rollingDiceList[i].gameObject.SetActive(false);
                        rollingDiceList[nextDice].gameObject.SetActive(true);

                    }
                }
                break;

        default:
                break;

        }
        
    }
}
