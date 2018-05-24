using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[4];
    public bool itemAdd;
    public void AddItem(GameObject item)
    {
        itemAdd = false;
        //encontrar o primeiro lugar vazio no inventario
        for (int i =0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                itemAdd = true;
                item.SendMessage("DoInterction");
                Debug.Log(item.name + "foi adicionado");
                break;
            }
        }
        if (!itemAdd)
        {
            Debug.Log("Inventrio Cheio - Item não adicionado.");
        }

    }
}
