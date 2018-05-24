using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    private Rigidbody2D Player;
    private SpriteRenderer Spr;
    [SerializeField]
    float Velocidade;
    float fome, sede;
    public int QuantidadesDeCarnes, QuantidadeDeAgua; 

	// Use this for initialization
	void Start ()
    {
        Player = GetComponent<Rigidbody2D>();
        Spr = GetComponent<SpriteRenderer>();
        Velocidade = 1.90f;
        fome = 1;
        sede = 1;
        QuantidadesDeCarnes = 0;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        int horizontal = 0, vertical = 0;
        
        if ((Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)))
        {
            horizontal = -1;
            if (!Spr.flipX)
            {
                Spr.flipX = true;
            }
        }
        
        else if (!(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)))
        {
            horizontal = 1;
            if (Spr.flipX)
            {
                Spr.flipX = false;
            }
        }
        else
        {
            horizontal = 0;
        }

        if ((Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)))
        {
            vertical = 1;
        }

        else if (!(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)))
        {
            vertical = -1;
        }

        else
        {
            vertical = 0;
        }
        Player.velocity = new Vector2(horizontal * Velocidade,vertical*Velocidade);

        
    }

    private void Update()
    {
        Debug.Log(QuantidadesDeCarnes);
    }
}
