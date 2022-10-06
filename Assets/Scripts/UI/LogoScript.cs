using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    public GameObject levelChanger;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToMainMenu());
    }


    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(5);
        levelChanger.GetComponent<LevelChanger>().FadeToLevel("MainMenu");
    }
}
