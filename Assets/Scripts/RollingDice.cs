using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer diceNumber;
    [SerializeField] Sprite[] diceSprites;   
    [SerializeField] GameObject rollingDiceAnim;
    [SerializeField] bool canDiceRoll=true;
    Coroutine generateRandomNumber;
    
    // Update is called once per frame
     
    public void OnMouseDown(){
       generateRandomNumber = StartCoroutine("GenerateRandomNumberOnDice");
}
    IEnumerator GenerateRandomNumberOnDice() {
        if (canDiceRoll == true)
        {
            canDiceRoll = false;
            diceNumber.gameObject.SetActive(false);
            rollingDiceAnim.SetActive(true);
            canDiceRoll = false;
            yield return new WaitForSeconds(0.55f);
            numberGot = Random.Range(0, 6);
            diceNumber.sprite = diceSprites[numberGot];
            if (numberGot == 3) { numberGot = -1; }
            else if (numberGot == 4) { numberGot = -2; }
            else if (numberGot == 5) { numberGot = -3; }
            else numberGot += 1;
            GameManager.gameManager.moveSteps = numberGot;
            GameManager.gameManager.rolledDice = this;
            diceNumber.gameObject.SetActive(true);
            rollingDiceAnim.SetActive(false);
            canDiceRoll = true;
            yield return new WaitForEndOfFrame();
            if (generateRandomNumber != null)
            {
                StopCoroutine(generateRandomNumber);
            }
        }
    } 
}
