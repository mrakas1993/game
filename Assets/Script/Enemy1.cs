using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int _damage)
    {
        health = _damage;
        if (health <= 0)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
