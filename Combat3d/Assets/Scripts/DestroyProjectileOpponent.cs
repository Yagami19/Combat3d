using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileOpponent : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBody")
        {
            Destroy(this.gameObject, 0.01f);
        }
    }
}
