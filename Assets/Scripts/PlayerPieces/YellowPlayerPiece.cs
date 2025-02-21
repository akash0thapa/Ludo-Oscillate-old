using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerPiece : PlayerPiece
{
    RollingDice yellowRollingDice;
    private void Start()
    {
        yellowRollingDice = GetComponentInParent<YellowHome>().rollingDice;
    }

    public void OnMouseDown()
    {
        if (GameManager.gameManager.rolledDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == yellowRollingDice && GameManager.gameManager.moveSteps ==3 && GameManager.gameManager.canPlayerMove == true  )
                {
                    GameManager.gameManager.yellowPlayerOut++;
                    MakePlayerReadyToMove(pathParent.yellowPathPoints);
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            if (GameManager.gameManager.rolledDice == yellowRollingDice && isReady && GameManager.gameManager.canPlayerMove == true)
            {
                GameManager.gameManager.canPlayerMove = false;
                MovePlayer(pathParent.yellowPathPoints);              
                return;
            }
        }
    }
    public void OnClick()
    {
        OnMouseDown();
    }
}
