using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Material-mainTextureScale.html

public class Wall : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.name);
        //Debug.Log(GameObject.name);
        float scaleX = 0.3f;
        float scaleY = 2.2f;
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }
}
