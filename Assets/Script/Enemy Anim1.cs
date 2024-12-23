using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim1 : MonoBehaviour
{
    public int health;
public Animator anim;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit");
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("IsDead", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }








}

