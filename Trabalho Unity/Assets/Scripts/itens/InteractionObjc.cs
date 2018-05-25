using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjc : MonoBehaviour {

    public bool inventory; //Caso verdadeiro o item pode ser armazenado no inventario.
	public void DoInterction()
    {
        gameObject.SetActive(false);  
    }
}
