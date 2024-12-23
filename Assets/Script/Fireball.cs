using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    private bool hitn;
    private float direction;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float lifeTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        //if (hit)
        //{
        //    return;
        //}
        //float movementspeed = speed * Time.deltaTime *direction;

        //transform.Translate(movementspeed, 0, 0);

        //lifeTime += Time.deltaTime;
        //if (lifeTime > 5)
        //{
        //    gameObject.SetActive(false);
        //}
        if (hitn)
        {
            return;
        }

        float movementspeed = speed * Time.deltaTime * direction;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * direction, movementspeed);

        if (hit.collider != null)
        {
            OnTriggerEnter2D(hit.collider);
        }
        else
        {
            transform.Translate(movementspeed, 0, 0);
        }

        lifeTime += Time.deltaTime;
        if (lifeTime > 5)
        {
            Deactivate();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hit = true;
        //boxCollider.enabled = false;
        //anim.SetTrigger("explode");
        //if (collision.CompareTag("Enemy"))
        //{
        //    Destroy(gameObject);
        //}
        //if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "ground")
        //{
        //    Deactivate();
        //}
        hitn = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy!");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Wall") || collision.CompareTag("ground"))
        {
            Debug.Log("Hit wall or ground!");
            Deactivate();
        }
    }
    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hitn = false;

        float localScaleX = transform.localScale.x;
        if(Math.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y,transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
