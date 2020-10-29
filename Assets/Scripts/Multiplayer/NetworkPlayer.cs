using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

//Part 2
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour
{
    //How to make VR Multiplayer - Part 2

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    //Part 2
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;


    private PhotonView photonView;

    //Part 2
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        //Part 2
        XRRig rig = FindObjectOfType<XRRig>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");

        //Part 2
        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            // rightHand.gameObject.SetActive(false);
            // leftHand.gameObject.SetActive(false);
            // head.gameObject.SetActive(false);

            // MapPosition(head, XRNode.Head);
            // MapPosition(leftHand, XRNode.LeftHand);
            // MapPosition(rightHand, XRNode.RightHand);

            //Part 2
            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

            //Part 2
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightEye), rightHandAnimator);
        }        

    }

    //Part 2
    //Nedenstående er kopieret fra HandPresence.cs
    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }


    //Part 2
    void MapPosition(Transform target, Transform rigTransform)
    {
        // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 positon);
        // InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;

    }
    /*

    // How to make VR Multiplayer - Part 1

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, XRNode.Head);
            MapPosition(leftHand, XRNode.LeftHand);
            MapPosition(rightHand, XRNode.RightHand);
        }

    }

    void MapPosition(Transform target, XRNode node)
    {

        // Bruger CommunUsages.devicePosition til at bevæge og rotere hænder og hoved
        // Men da det er lokale værdier, så når man flytter XR rig så vil lokal avatar ikke flytte
        // Derfor er der lavet en part 2 der retter dette.

        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 positon);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = positon;
        target.rotation = rotation;

    }
    */
}
