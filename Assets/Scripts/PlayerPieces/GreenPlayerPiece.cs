using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerPiece : PlayerPiece
{
    RollingDice greenRollingDice;
    private void Start()
    {
        greenRollingDice = GetComponentInParent<GreenHome>().rollingDice;
    }

    public void OnMouseDown()
    {
        if (GameManager.gameManager.rolledDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == greenRollingDice && GameManager.gameManager.moveSteps == 3  && GameManager.gameManager.canPlayerMove==true)
                {
                    GameManager.gameManager.greenPlayerOut++;
                    MakePlayerReadyToMove(pathParent.greenPathPoints);
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            if (GameManager.gameManager.rolledDice == greenRollingDice && isReady && GameManager.gameManager.canPlayerMove == true)
            {
                GameManager.gameManager.canPlayerMove = false;
                MovePlayer(pathParent.greenPathPoints);
            }
        }
    }
    public void OnClick()
    {
        OnMouseDown();
    }
}
