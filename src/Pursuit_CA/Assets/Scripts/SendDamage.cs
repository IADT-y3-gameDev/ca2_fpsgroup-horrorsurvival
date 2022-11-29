using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionStay(Collision other)
    {
        if (other.collider.transform.CompareTag("Player"))
        {
            other.transform.SendMessage("ApplyDamage", 1);
        }
    }

    
}
