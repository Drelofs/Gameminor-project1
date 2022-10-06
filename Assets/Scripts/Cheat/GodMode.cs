using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GodMode : MonoBehaviour
{
    public GameObject player;
    public GameObject healthbarFill;
    public bool doingGodMode = false;

    public bool godModeActivated = false;
    private int attackPressed = 0;
    private bool attackDone = false;
    private int jumpPressed = 0;
    private bool jumpDone = false;

    // Update is called once per frame
    void Update()
    {
        if(attackDone && jumpDone)
        {
            StartCoroutine(GodModeActivated());
            attackDone = false;
            jumpDone = false;
        }
    }

    public void CountAttackButton()
    {
        if (!godModeActivated)
        {
            attackPressed++;
            doingGodMode = true;
            if (attackPressed >= 5)
            {
                attackDone = true;
            }
        }
    }
    public void CountJumpButton()
    {
        if (!godModeActivated) {
            jumpPressed++;
            if (jumpPressed >= 5)
            {
                jumpDone = true;
            }
        }
    }
    public void GodModeFailed()
    {
        if (doingGodMode)
        {
            doingGodMode = false;
            attackPressed = 0;
            jumpPressed = 0;
        }
    }

    IEnumerator GodModeActivated()
    {
        Debug.Log("God Mode activated!");
        player.GetComponent<PlayerCombat>().godModeActivated = true;
        healthbarFill.GetComponent<Image>().color = new Color32(113, 0, 191, 100);
        GetComponent<TextMeshProUGUI>().enabled = true;
        yield return new WaitForSeconds(5);
        GetComponent<TextMeshProUGUI>().enabled = false;

    }
}
