using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerPiece : PlayerPiece
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("MoveStepsEnum");
    }

    IEnumerator MoveStepsEnum()
    {
        for (int i = 0; i < 25; i++)
        {
            transform.position = pathPoints.greenPathPoints[i].transform.position;
            yield return new WaitForSeconds(0.25f);
        }
    }


}
