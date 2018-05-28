﻿using UnityEngine;
using System.Collections;

    public class InventarioResize : MonoBehaviour {


    // The resolution that the UI was initially designed for.
    [SerializeField]
    Vector2 targetResolution = new Vector2(69, 69);

    // The Transform that should be resized, if not given then itself.
    [SerializeField]
    Transform UIObject;

    void Start()
    {
        if (!UIObject)
            UIObject = transform;
        SizeResolution(new Vector2(Screen.width, Screen.height));
    }

    public void SizeResolution(Vector2 newResolution)
    {
        Vector3 scale = UIObject.localScale;
        scale.x = newResolution.x / targetResolution.x;
        scale.y = newResolution.y / targetResolution.y;
        UIObject.localScale = scale;
    }

}

