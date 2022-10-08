using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{
    public GameObject levelChanger;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            levelChanger.GetComponent<LevelChanger>().FadeToLevel("ThankYouScreen");
        }
    }
}
