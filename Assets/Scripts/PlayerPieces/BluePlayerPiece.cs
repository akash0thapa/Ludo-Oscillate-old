using System.Collections;
using UnityEngine;

public class BluePlayerPiece : PlayerPiece
{

    RollingDice blueRollingDice;
    private void Start()
    {
        blueRollingDice = GetComponentInParent<BlueHome>().rollingDice;
    }

    public void OnMouseDown()
    {
        if (GameManager.gameManager.rolledDice != null)
        {
            if (!isReady)
            {
                if (GameManager.gameManager.rolledDice == blueRollingDice && GameManager.gameManager.moveSteps == 3  && GameManager.gameManager.canPlayerMove == true)
                {
                    GameManager.gameManager.bluePlayerOut++;
                    MakePlayerReadyToMove(pathParent.bluePathPoints);
                    GameManager.gameManager.moveSteps = 0;
                    return;
                }
            }
            if (GameManager.gameManager.rolledDice == blueRollingDice && isReady && GameManager.gameManager.canPlayerMove == true && GameManager.gameManager.turnCompleted == false)
            {
                GameManager.gameManager.canPlayerMove = false;
                MovePlayer(pathParent.bluePathPoints);
                GameManager.gameManager.turnCompleted = true;
                return;
            }
        }
    }
    public void OnClick()
    {
        OnMouseDown();
    }
}
