using System.Collections;
using UnityEngine;
public class RedPlayerPiece : PlayerPiece
{

    RollingDice redRollingDice;
    private void Start()
    {
        redRollingDice=GetComponentInParent<RedHome>().rollingDice;
    }

    public void OnMouseDown()
    {       
        if (GameManager.gameManager.rolledDice != null)
            {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == redRollingDice && GameManager.gameManager.moveSteps == 3 && GameManager.gameManager.canPlayerMove == true)
                {
                    GameManager.gameManager.redPlayerOut++;
                    MakePlayerReadyToMove(pathParent.redPathPoints);
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            else
            {      
            if (GameManager.gameManager.rolledDice == redRollingDice && GameManager.gameManager.canPlayerMove == true)
                    {
                        GameManager.gameManager.canPlayerMove = false;
                        MovePlayer(pathParent.redPathPoints);
                        return;
                    }
                }          
        }
      
    }
    public void OnClick()
    {
        OnMouseDown();
    }
}
