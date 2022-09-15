using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
     public GameObject menu1;
     private bool isShowing;
     public static bool isGamePaused = false;
     public void EnableLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void DisableLock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
     public void menuButton() 
    {
        
            if (isGamePaused){
                ResumeGame();
            }else{
                PauseGame();
            }
            //  if (menu1.gameObject.activeInHierarchy){
            //     isShowing = !isShowing;
            //     menu1.SetActive(isShowing);
            //     Debug.Log("active");
            //  }else{
            //     menu1.SetActive(true);
            //  }
            // DisableLock();
    
    }
    public void  ResumeGame(){
        menu1.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
        
    public void PauseGame(){
        Time.timeScale = 0f;
        menu1.SetActive(true);
        isGamePaused = true;
    }

    
}
