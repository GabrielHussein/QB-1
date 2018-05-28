using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    private Rigidbody2D Player;
    private SpriteRenderer Spr;
    public GameObject painel;
    RectTransform ConfigDoPainel;
    PlayerInventory InventarioCheck;
    public bool InvAberto;

    [SerializeField]
    GameObject Inventario;
    

    float Velocidade;
    float fome, sede;

	// Use this for initialization
	void Start ()
    {
        Player = GetComponent<Rigidbody2D>();
        Spr = GetComponent<SpriteRenderer>();
        ConfigDoPainel = painel.GetComponent<RectTransform>();
        InvAberto = false;
        InventarioCheck = this.transform.GetComponent<PlayerInventory>();
        Velocidade = 1.90f;
        fome = 1;
        sede = 1;
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

        if ((Input.GetKeyDown("i")) && (!InvAberto))
        {
            int x;
            if (InventarioCheck.mochilacheck)
            {
                x = 50;
            }
            else
            {
                x = 92;
            }
            StopCoroutine(AnimacaoDdoInventario(x));
            StartCoroutine(AnimacaoSdoInventario(x));
            InvAberto = true;
        }
        else if((Input.GetKeyDown("i")) && (InvAberto))
        {
            int x;
            if (InventarioCheck.mochilacheck)
            {
                x = 50;
            }
            else
            {
                x = 92;
            }
            StopCoroutine(AnimacaoSdoInventario(x));
            StartCoroutine(AnimacaoDdoInventario(x));
            InvAberto = false;
        }
    }

    IEnumerator AnimacaoSdoInventario(int x)
    {
        for (float y = -84;y <= 34; y+=14.75f)
        {
            ConfigDoPainel.localPosition = new Vector2(x, y);
            yield return new WaitForSeconds(0.000001f);
        }
    }

    IEnumerator AnimacaoDdoInventario(int x)
    {
        for (float y = 34; y >= -84; y -= 14.75f)
        {
            ConfigDoPainel.localPosition = new Vector2(x, y);
            yield return new WaitForSeconds(0.000001f);
        }
    }
}
