using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracteble : MonoBehaviour {

    [SerializeField]
    GameObject currentItemInter = null;
    public InteractionObjc currentObjScript = null;
    public PlayerInventory inventario;
    public bool check = true;
    void Update()
    {
        if (Input.GetButtonDown("Interacao") && currentItemInter)
        {
            if (currentObjScript.inventory)
            {
                inventario.AddItem(currentItemInter);
                check = this.gameObject.GetComponent<PlayerInventory>().itemAdd;
                if (check)
                {
                    currentObjScript.DoInterction();
                    currentItemInter = null;
                }
                
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ItemInteragivel"))
        {
            Debug.Log(other.name);
            currentItemInter = other.gameObject;
            currentObjScript = currentItemInter.GetComponent <InteractionObjc>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ItemInteragivel"))
        {
            if (other.gameObject == currentItemInter)
            {
                currentItemInter = null;
            }
        }
    }
}
