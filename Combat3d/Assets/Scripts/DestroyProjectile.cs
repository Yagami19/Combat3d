using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyProjectile : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "OpponentBody")
        {
            Destroy(this.gameObject, 0.01f);

        }
    }
}
