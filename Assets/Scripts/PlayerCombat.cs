using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public LayerMask NpcsLayer;
    Animator animatorCombat;
    public GameObject GameOverScreen;
    public GameObject Camera;
    public GameObject Npc;
    public Transform AttackPoint;
    public Transform AttackLeftPoint;
    public float AttackRange = 0.2f;
    public int LightDmg = 25;
    public Health PlayerHP;
    public int HpAt;
    public int maxHP = 100;


    // Start is called before the first frame update
    void Start()
    {
        HpAt = maxHP;
        PlayerHP.SetMaxHealth(maxHP);
        animatorCombat = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool LightAttack = Input.GetButtonDown("Fire1");
        bool LeftAttack = Input.GetButtonDown("Fire1");

        //Left mouse click
        if (LightAttack && animatorCombat.GetBool("IdleRight"))
        {   
            Attack();
            animatorCombat.SetBool("LightAttack", true);
        }
        else if (LightAttack == false)
        {
            animatorCombat.SetBool("LightAttack", false);
        }

        //left
        if (LeftAttack && animatorCombat.GetBool("IdleLeft"))
        {

            AttackLeft();
            animatorCombat.SetBool("LeftAttack", true);
        }
        else if (LeftAttack == false)
        {
            animatorCombat.SetBool("LeftAttack", false);
        }


 
    }

    //maybe chnage name
    public void Attack()
    {
        
        //detect Npc in range of attack
        //create a cicrle at Point of Attack to check if Npc layer is in the circle
        Collider2D[] HitNpc = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, NpcsLayer);
        //damage Npc
        
        foreach(Collider2D npc in HitNpc)
        {
            npc.GetComponent<NpcVampire>().Damage(LightDmg);
        }
    }

    public void AttackLeft()
    {

        //detect Npc in range of attack
        //create a cicrle at Point of Attack to check if Npc layer is in the circle
        Collider2D[] HitNpc = Physics2D.OverlapCircleAll(AttackLeftPoint.position, AttackRange, NpcsLayer);
        //damage Npc

        foreach (Collider2D npc in HitNpc)
        {
            npc.GetComponent<NpcVampire>().Damage(LightDmg);
        }
    }

    //shows the attack point and the range of it 
    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
        Gizmos.DrawWireSphere(AttackLeftPoint.position, AttackRange);
    }

    public void Damage(int dmg)
    {
        HpAt -= dmg;
        PlayerHP.SetHealth(HpAt);

        //make a hit animation
        //sets up so this can only play while above 0 hp
        if (HpAt >= 0)
        {
         
            animatorCombat.SetTrigger("Hit");
        }
        else
        if (HpAt <= 0)
        {
            //run die
            Dead();
        }
    }


    void Dead()
    {
        animatorCombat.SetBool("Death", true);
        //Game Over Screen comes up. 
        GetComponent<PlayerContorller>().enabled = false;
        Npc.GetComponent<Collider2D>().enabled = false;
        Npc.GetComponent<NpcVampire>().enabled = false;
        GameOver();

        this.enabled = false;

    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

}
