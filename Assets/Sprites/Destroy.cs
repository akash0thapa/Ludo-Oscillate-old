using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Piece") && collision.gameObject != gameObject)
        {
            // Destroy the other pawn
            Destroy(collision.gameObject);
        }
    }
}
