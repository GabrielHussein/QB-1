using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public GameObject[] inventory;
    private GameObject[] icones;
    private GameObject ObjInventario;
    public Sprite Mochila;


    private void Start()
    {
        inventory = new GameObject[4];
        icones = new GameObject[4];
        ObjInventario = GameObject.Find("Painel");
    }
    public bool itemAdd,mochilacheck = false;
    public void AddItem(GameObject item)
    {
        itemAdd = false;
        //encontrar o primeiro lugar vazio no inventario
        for (int i =0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                if (item.name == "mochila")
                {
                    mochilacheck = true;
                    Array.Resize(ref inventory, 8);
                    itemAdd = true;
                    item.SendMessage("DoInterction");
                    this.GetComponent<SpriteRenderer>().sprite = Mochila;
                    Debug.Log(item.name + "foi adicionado assim aumentando o tamanho da capacidade para 8.");
                    break;
                }

                inventory[i] = item;
                itemAdd = true;

                GameObject ImagenDoInventario = ObjInventario.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                Image IconeItem = ImagenDoInventario.GetComponent<Image>();
                IconeItem.sprite = item.GetComponent<SpriteRenderer>().sprite; 

                item.SendMessage("DoInterction");
                Debug.Log (item.name + "foi adicionado");
                break;
            }
        }


        if (!itemAdd)
        {
            if (item.name == "mochila")
            {
                mochilacheck = true;
                Array.Resize(ref inventory, 8);
                itemAdd = true;
                item.SendMessage("DoInterction");
                this.GetComponent<SpriteRenderer>().sprite = Mochila;
                Debug.Log(item.name + "foi adicionado assim aumentando o tamanho da capacidade para 8.");
            }
            else
            {
                Debug.Log("Inventrio Cheio - Item não adicionado.");
            }
            
        }

    }
}
