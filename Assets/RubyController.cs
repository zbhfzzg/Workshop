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
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    Animator animator;
    public GameObject projectilePrefab;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = maxHP;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible) //workshop 4
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
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
        if (value < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

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
        UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}

