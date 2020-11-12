using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public Vector3 doorsound;
    public AudioSource aud;
    private bool oncer = false;

    // Start is called before the first frame update
    void Start()
    {
        //finder positionen
        doorsound = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // hvis bool er ulige spil en lyd
        if ( doorsound != transform.position && oncer == false) {
            aud.Play();
            oncer = true;         
            StartCoroutine(stilstand());
        }
    }

    IEnumerator stilstand() {
        yield return new WaitForSeconds(1f);
        doorsound = transform.position;
        oncer = false;
    }
}
