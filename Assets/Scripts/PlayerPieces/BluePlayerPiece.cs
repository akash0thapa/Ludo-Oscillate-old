using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BluePlayerPiece : PlayerPiece
{
    // Start is called before the first frame update
    private RollingDice rollDice;
    private void Start()
    {
        rollDice=GetComponentInParent<BlueHome>().rollingDice;
    }
    private void OnMouseDown()
    {

        if (GameManager.gameManager.rolledDice != null) {
            if (isReady == false)
            {
                if(GameManager.gameManager.rolledDice==rollDice && GameManager.gameManager.moveSteps == 1)
                {
                    MakePlayerReadyToMove();
                }
            }
        }
        if (GameManager.gameManager.rolledDice == rollDice && isReady) {
            canMove = true;
        }
        
        StartCoroutine("MoveStepsEnum");
    }
    IEnumerator MoveStepsEnum()
    {
        yield return new WaitForSeconds(0.25f);
       int  numberOfStepsToMove=GameManager.gameManager.moveSteps;
        int temp = numberOfStepsAlreadyMoved+numberOfStepsToMove;
        if (canMove == true) {
            if (numberOfStepsToMove > 0)
            {
                if (numberOfStepsAlreadyMoved + numberOfStepsToMove <= 33)
                {
                    for (int i = numberOfStepsAlreadyMoved - 1; i < (numberOfStepsAlreadyMoved + numberOfStepsToMove - 1); i++)
                    {
                        transform.position = pathPoints.bluePathPoints[i + 1].transform.position;
                        yield return new WaitForSeconds(0.25f);
                    }
                    numberOfStepsAlreadyMoved += numberOfStepsToMove;
                }
            }
            else
            {
                if (numberOfStepsAlreadyMoved < 30)
                {
                    if (numberOfStepsAlreadyMoved + numberOfStepsToMove > 0)
                    {
                        for (int i = numberOfStepsAlreadyMoved - 1; i >= (numberOfStepsAlreadyMoved + numberOfStepsToMove - 1); i--)
                        {

                            transform.position = pathPoints.bluePathPoints[i].transform.position;
                            yield return new WaitForSeconds(0.25f);

                        }
                        numberOfStepsAlreadyMoved += numberOfStepsToMove;
                    }
                    else
                    {
                        yield break;
                    }
                }

            }  
        }
    }
    private void MakePlayerReadyToMove(){
        isReady = true;
        transform.position = transform.position = pathPoints.bluePathPoints[0].transform.position;
        numberOfStepsAlreadyMoved = 0;
    }
    public void Onclick()
    {
        OnMouseDown();
    }
    
}
