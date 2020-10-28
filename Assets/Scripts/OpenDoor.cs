using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//åben døren
// https://www.youtube.com/watch?v=3cJ_uq1m-dg&vl=fr

//open door
public class OpenDoor : MonoBehaviour
{
	public Transform target;
	Rigidbody rb;
    AudioSource sound;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {
	    rb.MovePosition(target.transform.position); 

        Debug.Log(target.transform.position);
        

       
    } 
}