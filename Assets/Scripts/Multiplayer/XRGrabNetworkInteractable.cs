using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

// Dette Script bruges til at alle brugere kan interagere med et objekt

public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        // Request Ownership with current local player
        photonView.RequestOwnership();
        base.OnSelectEnter(interactor);
    }
}
