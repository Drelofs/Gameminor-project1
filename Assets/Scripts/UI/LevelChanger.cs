using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;

    private string levelToLoad;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(string levelName)
    {
        anim.SetTrigger("FadeOut");
        levelToLoad = levelName;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }

}
