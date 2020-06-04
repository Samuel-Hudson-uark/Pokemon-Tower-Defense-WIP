using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHandler : MonoBehaviour
{

    public float maxHP;
    private float currentHP;

    public bool TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            //kill
            Destroy(gameObject);
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }
}
