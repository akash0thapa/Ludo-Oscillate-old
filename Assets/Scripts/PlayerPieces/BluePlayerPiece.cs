using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPiece : PlayerPiece
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        canMove = true;
        StartCoroutine("MoveStepsEnum");
    }
   

    IEnumerator MoveStepsEnum()
    {
        if (canMove == true) {
            for (int i = 0; i < 25; i++)
            {
                transform.position = pathPoints.bluePathPoints[i].transform.position;
                yield return new WaitForSeconds(0.25f);
            }
        }
       
    }

    public void Onclick()
    {
        OnMouseDown();
    }
    



}
