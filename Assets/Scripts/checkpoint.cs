using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public GameObject objects;
    public GameObject objects1;
    private bool isShowing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "check1" && objects != null)  {
            isShowing = !isShowing;
            Debug.Log("Goal");
            objects.SetActive(isShowing);
            Destroy(objects1);
         }
    }
}
