using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventarioUI : MonoBehaviour {

    
    public GameObject painel;
    RectTransform ConfigDoPainel;
    PlayerControler PlayerController;

    // Use this for initialization
    void Start ()
    {
        PlayerController = GameObject.Find("Player").transform.GetComponent<PlayerControler>();
        ConfigDoPainel = painel.GetComponent<RectTransform>();
    }

	public void ArrumarInv()
    {
        if (PlayerController.InvAberto)
        {
            ConfigDoPainel.localPosition = new Vector2(50, 34);
        }
        else
        {
            ConfigDoPainel.localPosition = new Vector2(50, -84);
        }
        ConfigDoPainel.sizeDelta = new Vector2(120, 69);
        for (int i = 4; i < 8; i++)
        {
            painel.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }    
	}
}
