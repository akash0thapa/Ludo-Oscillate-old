using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PathPoints : MonoBehaviour
{
    public PathPointsParent pathParent;
    public List<PlayerPiece> piecesList = new List<PlayerPiece>();
    PathPoints[] reverseMovePath;
    //public GameObject blueStartPoint;

    private void Start()
    {
        pathParent = GetComponentInParent<PathPointsParent>();
    }
    public bool AddPlayerPieces(PlayerPiece piece)
    {
        if (!pathParent.safePathPoints.Contains(this))
        {
            if (piecesList.Count == 1)
            {
                string prePieceName = piecesList[0].name;
                string currentPieceName = piece.name;
                if (!prePieceName.Contains(currentPieceName) && piece.moveDirection == true)
                {
                    piecesList[0].isReady = false;
                    StartCoroutine(RevertToStart(piecesList[0]));
                    piecesList[0].numberOfStepsAlreadyMoved = 0;
                    RemovePlayerPieces(piecesList[0]);
                    AddPlayer(piece);
                    return false;
                }
            }
        }
        AddPlayer(piece);
        return true;
    }

    public IEnumerator RevertToStart(PlayerPiece piece) {
        if (piece.name.Contains("RedPiece"))
        {
            reverseMovePath = pathParent.redPathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--) {
                piece.transform.position = reverseMovePath[i].transform.position;
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(1.16f, -0.039f, 0f);
            GameManager.gameManager.redPlayerOut--;
        }
        else if (piece.name.Contains("BluePiece"))
        {

            reverseMovePath = pathParent.bluePathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                piece.transform.position = reverseMovePath[i].transform.position;
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(-1.159f, -0.017f, 0f);
            GameManager.gameManager.bluePlayerOut--;
        }
        else if (piece.name.Contains("YellowPiece"))
        {
            reverseMovePath = pathParent.yellowPathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                piece.transform.position = reverseMovePath[i].transform.position;
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(-1.14f, 2.29f, 0f);
            GameManager.gameManager.yellowPlayerOut--;
        }
        else
        {
            reverseMovePath = pathParent.greenPathPoints;
            for (int i = piece.numberOfStepsAlreadyMoved - 1; i >= 0; i--)
            {
                piece.transform.position = reverseMovePath[i].transform.position;
                yield return new WaitForSeconds(0.05f);
            }
            piece.transform.position = new Vector3(1.18f, 2.28f, 0f);
            GameManager.gameManager.greenPlayerOut--;
        }
        piece.isReady = false;
    }
    private void AddPlayer(PlayerPiece piece)
    {
        piecesList.Add(piece);
        RescaleAndReposition();
        int SpriteLayer = 0;
        for (int i = 0; i < piecesList.Count; i++)
        {
            SpriteRenderer[] spriteRenderers = piecesList[i].GetComponentsInChildren<SpriteRenderer>();
            if (i == piecesList.Count - 1)
            {
                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.sortingOrder = renderer.sortingOrder + (SpriteLayer + i);
                }
            }
            SpriteLayer += 4;

        }
    }

    public void RemovePlayerPieces(PlayerPiece piece)
    {
        if (piecesList.Contains(piece))
        {
            piecesList.Remove(piece);
            RescaleAndReposition();
        }
        Debug.Log(piecesList.Count);
        if (piecesList.Count > 0)
        {
              foreach (PlayerPiece p in piecesList) { 
                SpriteRenderer[] spriteRenderers = p.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer renderer in spriteRenderers)
                {
                    renderer.sortingOrder = renderer.sortingOrder - 5;
                }            
            }
        }
    }

    public void RescaleAndReposition()
    {
        int playersCount = piecesList.Count;
        switch (playersCount) {
            case 1:
                piecesList[0].transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                piecesList[0].transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;

            case 2:
                piecesList[0].transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                piecesList[1].transform.localScale = new Vector3(0.3f, 0.3f, 1f);
                piecesList[0].transform.position = new Vector3(transform.position.x + 0.075f, transform.position.y, 0f);
                piecesList[1].transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                break;

            case 3:
                piecesList[0].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0f);
                piecesList[1].transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, 0f);
                piecesList[2].transform.position = new Vector3(transform.position.x - 0.045f + 0.03f, transform.position.y, 0f);
                piecesList[0].transform.localScale = new Vector3(0.25f, 0.25f, 25f);
                piecesList[1].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                piecesList[2].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                break;

            case 4:
                piecesList[0].transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, 0f);
                piecesList[1].transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, 0f);
                piecesList[3].transform.position = new Vector3(transform.position.x - 0.115f + 0.03f, transform.position.y, 0f);
                piecesList[2].transform.position = new Vector3(transform.position.x - 0.045f + 0.03f, transform.position.y, 0f);
                piecesList[0].transform.localScale = new Vector3(0.25f, 0.25f, 25f);
                piecesList[1].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                piecesList[2].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                piecesList[3].transform.localScale = new Vector3(0.25f, 0.25f, 1f);
                break;
        }      
    } 
}

        /*  
          bool isOdd = (playersCount % 2 == 0) ? false : true;
          int extent = (playersCount / 2);
          int count = 0;
        
        if (isOdd)
          {
              for (int i = -extent; i <= extent; i++)
              {
                  piecesList[count].transform.localScale = new Vector3(pathParent.scales[playersCount - 1], pathParent.scales[playersCount - 1], 1f);

                  piecesList[count].transform.position = new Vector3(transform.position.x + (i * pathParent.positionDifference[playersCount - 1]), transform.position.y, 0f);
              }            
          }
          else {
              for (int i = -extent; i < extent; i++)
              {
                  piecesList[count].transform.localScale = new Vector3(pathParent.scales[playersCount - 1], pathParent.scales[playersCount - 1], 1f);

                  piecesList[count].transform.position = new Vector3(transform.position.x + (i * pathParent.positionDifference[playersCount - 1]), transform.position.y, 0f);
              }
          }
  */


        /*for (int i = 0; i < playersCount; i++) {
            piecesList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder=SpriteLayer;
            SpriteLayer++;
        }*/
