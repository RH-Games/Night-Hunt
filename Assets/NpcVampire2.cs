using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcVampire2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public int NpcMaxHealth = 100;
    public bool isTurned = false;
    public Transform playerPos;
    public Transform AttackPoint;
    public int VampDmg = 15;
    public float AttackRange = 0.2f;
    public int bloodDmg = 5;
    public LayerMask Player;
    private int MaxvamCount = 2;
    public GameObject endgameScreen;
    int NpcHealth;
    private int vamCount;



    void Start()
    {
        NpcHealth = NpcMaxHealth;
        vamCount = MaxvamCount;
        Debug.Log(vamCount);
    }


    public void lookAt()
    {
        Vector3 turned = transform.localScale;
        turned.z *= -1f;

        if (transform.position.x > playerPos.position.x && isTurned)
        {

            transform.localScale = turned;
            transform.Rotate(0f, 180f, 0f);
            isTurned = false;
        }
        else if (transform.position.x < playerPos.position.x && !isTurned)
        {

            transform.localScale = turned;
            transform.Rotate(0f, 180f, 0f);
            isTurned = true;
        }
    }


    public void Attack()
    {

        //detect player in range of attack
        //create a cicrle at Point of Attack to check if Npc layer is in the circle
        Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, Player);
        //damage Npc

        foreach (Collider2D player in HitPlayer)
        {   //gets player component and runs the damage function and 
            player.GetComponent<PlayerCombat>().Damage(VampDmg);
        }
    }



    public void Damage(int dmg)
    {
        NpcHealth -= dmg;

        animator.SetTrigger("Hit");
        if (NpcHealth <= 0)
        {
            vamCount += 1;
            Debug.Log(vamCount);
            VampDie();
        }
    }

    void VampDie()
    {
        animator.SetTrigger("Dead");
        //vamp death anmation;
        //disables compoent
        GetComponent<Collider2D>().enabled = false;
        GetComponent<NpcVampire>().enabled = false;
        //VamLeft();
        if (vamCount == 0)
        {
            EndGame();
            //this.enabled = false;
        }
    }

    void EndGame()
    {

        endgameScreen.SetActive(true);
    }

    //shows the range of the attack point 
    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}