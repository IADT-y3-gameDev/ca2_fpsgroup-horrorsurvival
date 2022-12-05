using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform TeleEnd;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider Other)
    {
       thePlayer.transform.position = TeleEnd.transform.position; 
    }
}
