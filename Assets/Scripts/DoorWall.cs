using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWall : MonoBehaviour
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
        float scaleX = 0.8f;
        float scaleY = 0.8f;
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }
}
