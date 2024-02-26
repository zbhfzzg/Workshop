using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecfile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //���ǻ������˵�����־���˽�ɵ��������Ķ���
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
}
