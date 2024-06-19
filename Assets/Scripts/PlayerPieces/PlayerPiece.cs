using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public bool isReady;
    public int numberOfStepsToMove;
    public int numberOfStepsAlreadyMoved;
    public PathPointsParent pathParent;
    Coroutine playerMove;
    public PathPoints prevPathPoint;
    public PathPoints currentPathPoint;
    public static PlayerPiece playerPiece;
    public bool moveDirection;


    private void Awake()
    {
        pathParent = FindObjectOfType<PathPointsParent>();
        playerPiece =GetComponentInParent<PlayerPiece>();
    }

    public void MovePlayer(PathPoints[] pathParent_)
    {
        playerMove = StartCoroutine(MovePlayer_enum(pathParent_));
        
    }
    IEnumerator MovePlayer_enum(PathPoints[] pathParent_)
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer Renderer in spriteRenderers)
        {
            Renderer.sortingOrder += 20;
        }
        numberOfStepsToMove = GameManager.gameManager.moveSteps;
        if (GameManager.gameManager.moveSteps > 0)
        {
            
            if (numberOfStepsAlreadyMoved + GameManager.gameManager.moveSteps <= 33)
            {
                moveDirection = true;
                for (int i = numberOfStepsAlreadyMoved - 1; i < (numberOfStepsAlreadyMoved + numberOfStepsToMove - 1); i++)
                {
                    transform.position = pathParent_[i + 1].transform.position;
                    yield return new WaitForSeconds(0.25f);
                }
                numberOfStepsAlreadyMoved += numberOfStepsToMove;        
            }

        }
        else
        {
            if (numberOfStepsAlreadyMoved < 30)
            {
                if (numberOfStepsAlreadyMoved + GameManager.gameManager.moveSteps > 0)
                {
                    moveDirection = false;
                    for (int i = numberOfStepsAlreadyMoved - 1; i >= (numberOfStepsAlreadyMoved + numberOfStepsToMove - 1); i--)
                    {
                        transform.position = pathParent_[i].transform.position;
                        yield return new WaitForSeconds(0.25f);

                    }
                    numberOfStepsAlreadyMoved += numberOfStepsToMove;
                    
                }               
            }
        }
        
        GameManager.gameManager.RemovePoint(prevPathPoint);
        prevPathPoint.RemovePlayerPieces(this);
        currentPathPoint = pathParent_[numberOfStepsAlreadyMoved - 1];
        bool transfer=currentPathPoint.AddPlayerPieces(this);
        GameManager.gameManager.AddPoint(currentPathPoint);
        prevPathPoint = currentPathPoint;
        if (transfer)
        {
            if (GameManager.gameManager.moveSteps != 3 )
            {
                GameManager.gameManager.transferDice = true;
                GameManager.gameManager.rollingDiceTransfer();
            }
        }
        GameManager.gameManager.canPlayerMove = true;     
        if (playerMove != null)
        {
            StopCoroutine(playerMove);
            GameManager.gameManager.moveSteps = 0;
            GameManager.gameManager.canDiceRoll = true;
        }
        SpriteRenderer[] spriteRender = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer Render in spriteRender)
        {
            Render.sortingOrder -= 20;
        }
    }
    public void MakePlayerReadyToMove(PathPoints[] pathParent_)
    {
        
        isReady = true;
        transform.position = pathParent_[0].transform.position;
        numberOfStepsAlreadyMoved = 1;
        GameManager.gameManager.moveSteps = 0;
        GameManager.gameManager.rollingDiceTransfer();
        currentPathPoint = pathParent_[0];
        prevPathPoint = pathParent_[0];
        currentPathPoint.AddPlayerPieces(this);
        GameManager.gameManager.AddPoint(currentPathPoint);
        GameManager.gameManager.transferDice = false;
    }
}