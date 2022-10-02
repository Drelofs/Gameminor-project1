using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;

    private string levelToLoad;

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
