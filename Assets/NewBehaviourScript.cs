using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    [Range(0, 10f)]
    public float speed;
    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    public int HP;
    public int currentHP { get => HP; }

    public int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }

    public void ChangeHP(int value)
    {
        HP += value;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
        if (HP < 0)
        {
            HP = 0;
        }

        HP = Mathf.Clamp(HP, 0, maxHP);
        Debug.Log("Player hp is now" + HP);
    }
}
