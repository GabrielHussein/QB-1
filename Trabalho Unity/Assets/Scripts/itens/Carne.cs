using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carne : MonoBehaviour {
    bool stay;
    GameObject Player;
    private PlayerControler PlayerScript;
	// Use this for initialization
	void Start () {
        stay = false;
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerControler>();
    }
	
	// Update is called once per frame
	void Update () {

        if (stay)
        {
            Debug.Log("Aperte E para pegar");
            if (Input.GetKey("e"))
            {
                PlayerScript.QuantidadesDeCarnes++;
                Destroy(this.gameObject);
            }
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            stay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            stay = false;
        }
    }

}
