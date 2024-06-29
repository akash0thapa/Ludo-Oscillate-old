using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject backgroundCanvas;
    public GameObject selectPlayerCanvas;
  public  void  Play()
    {
        selectPlayerCanvas.gameObject.SetActive(true);
        selectPlayerCanvas.GetComponent<Canvas>().enabled = true;
        Canvas spriteRender = selectPlayerCanvas.GetComponent<Canvas>();
        spriteRender.sortingOrder = 10;
    }
    public void Load() {
        SceneManager.LoadScene("GameScene");
    }

    public void Main() {
        SceneManager.LoadScene("MainMenu");
    }
   public  void Exit() { 
    Application.Quit();
    }
}
