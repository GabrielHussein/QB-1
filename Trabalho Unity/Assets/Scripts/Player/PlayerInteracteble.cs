using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracteble : MonoBehaviour {

    [SerializeField]
    GameObject currentItemInter = null;

    void Update()
    {
        if (Input.GetButtonDown("Interacao") && currentItemInter)
        {
            currentItemInter.SendMessage("DoInterction");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ItemInteragivel"))
        {
            Debug.Log(other.name);
            currentItemInter = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ItemInteragivel"))
        {
            if(other.gameObject == currentItemInter)
            {
                currentItemInter = null;
            }
        }
    }
}
