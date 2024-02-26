using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllectableHealingObject : MonoBehaviour
{
    public int healAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RubyController controller = collision.GetComponent<RubyController>();
            if (controller.HP < controller.maxHP)
            {
                print("Player HP is now " + controller.currentHP);
                controller.ChangeHP(healAmount);
                Destroy(this.gameObject);
            }
            
        }
    }
}
