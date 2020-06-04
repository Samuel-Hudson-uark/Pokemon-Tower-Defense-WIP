using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float attack = 1;
    public int targetLayer = 9;
    HpHandler target;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == targetLayer)
        {
            Destroy(gameObject);
            //Find the enemy's script and deal damage
            target = (HpHandler)collision.gameObject.GetComponent(typeof(HpHandler));
            target.TakeDamage(attack);
        }
    }
}
