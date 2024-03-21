using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    private PlayerAnimation player_anim;
    private bool ComboReset;
    private float ComboTimerReset = 0.4f;
    private float currentComboTimer;
    private float attackCoolDown = 0.25f;
    private bool canAttack= true;

    private int hitStunTimer;
    public BoxCollider2D hitbox;
    public BoxCollider2D hurtbox;

    public PlayerHealth p1health;
    public PlayerHealth p2health;
    public Animator p2Animator;

    public GameObject bloodEffect;
    public Transform player2;
    private Combo current_attack;
    // Start is called before the first frame update
    void Awake()
    {
        player_anim = GetComponent<PlayerAnimation>();
    }
    private void Start()
    {
        GlobalVarieties.global.p1currentHealth = GlobalVarieties.global.p1MaxHealth;
        p1health.SetMaxHealth(GlobalVarieties.global.p1currentHealth);
        p1health.disPlayCurrentHealth(GlobalVarieties.global.p1MaxHealth);
        currentComboTimer = ComboTimerReset;
        current_attack = Combo.None;   
        hitbox.isTrigger = true;
    }
    // Update is called once per frame
    void Update()
    {
        p1health.disPlayCurrentHealth(GlobalVarieties.global.p1currentHealth);
        ComboAttacks();
        ResetCombo();
    }

    private void FixedUpdate()
    {
        DealDamage();
    }
    void DealDamage()
    {
        //other player take damage logic.
        if(hitStunTimer == 0)
        {
            GlobalVarieties.global.p2takenDamage = false;
            p2Animator.SetBool("Damaged", false);
        }
        else
        {
            GlobalVarieties.global.p2takenDamage = true;
            p2Animator.SetBool("Damaged", true);
            hitStunTimer--;
        }

        //hit registered logic.
       
        if (hitbox.IsTouching(hurtbox) && !GlobalVarieties.global.p2takenDamage)
        {
            hitStunTimer = 15;

            Instantiate(bloodEffect, player2.transform.position, Quaternion.identity);
            if (current_attack == Combo.Punch1)
            {
                if (!GlobalVarieties.global.p2isBlocking) { GlobalVarieties.global.p2currentHealth -= 5; }
                else { GlobalVarieties.global.p2currentHealth -= 2; }
                Debug.Log("punch Registered");
            }
            if (current_attack == Combo.Punch2)
            {
                if (!GlobalVarieties.global.p2isBlocking) { GlobalVarieties.global.p2currentHealth -= 5; }
                else { GlobalVarieties.global.p2currentHealth -= 2; }
                Debug.Log("punch Registered");

            }
            if (current_attack == Combo.Punch3)
            {
                if (!GlobalVarieties.global.p2isBlocking) { GlobalVarieties.global.p2currentHealth -= 8; }
                else { GlobalVarieties.global.p2currentHealth -= 4; }
                Debug.Log("punch Registered");

            }
            if (current_attack == Combo.Kick1)
            {
                if (!GlobalVarieties.global.p2isBlocking) { GlobalVarieties.global.p2currentHealth -= 5; }
                else { GlobalVarieties.global.p2currentHealth -= 2; }
                Debug.Log("kick Registered");

            }
            if (current_attack == Combo.Kick2)
            {
                if (!GlobalVarieties.global.p2isBlocking) { GlobalVarieties.global.p2currentHealth -= 5; }
                else { GlobalVarieties.global.p2currentHealth -= 2; }
                Debug.Log("kick Registered");

            }
            if (current_attack == Combo.Kick3)
            {
                if (!GlobalVarieties.global.p2isBlocking) { GlobalVarieties.global.p2currentHealth -= 8; }
                else { GlobalVarieties.global.p2currentHealth -= 4; }
                Debug.Log("kick Registered");

            }
            p2health.SetHealth(GlobalVarieties.global.p2currentHealth);
        }
    }
    void ComboAttacks()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player_anim.Blocking();
            GlobalVarieties.global.p1isBlocking = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            GlobalVarieties.global.p1isBlocking = false;
        }
        
       
        //Punch
        if (Input.GetKeyDown(KeyCode.J) && !GlobalVarieties.global.p1isBlocking)
        {
            if (current_attack == Combo.Punch3 || current_attack == Combo.Kick3) return;

            if(current_attack == Combo.Kick1 || current_attack == Combo.Kick2 || current_attack == Combo.None)
            {
                current_attack = Combo.Punch1;
            }else if(canAttack)
            {
                current_attack++;
            }
            ComboReset = true;
            currentComboTimer = ComboTimerReset;
            if (canAttack)
            {
                if(current_attack == Combo.Punch1)
                {
                    player_anim.Punch_1();
                }
                else if (current_attack == Combo.Punch2)
                {
                    player_anim.Punch_2();
                }
                else if (current_attack == Combo.Punch3)
                {
                    player_anim.Punch_3();
                }
                StartCoroutine(TimeBetweenAttack());
            }

        }
        //Kick
        if (Input.GetKeyDown(KeyCode.K) && !GlobalVarieties.global.p1isBlocking)
        {
            if (current_attack == Combo.Kick3 || current_attack == Combo.Punch3) return;

            if(current_attack == Combo.Punch1 || current_attack == Combo.Punch2 || current_attack == Combo.None)
            {
                current_attack = Combo.Kick1;
            }
            else if(canAttack)
            {
                current_attack++;
            }
            ComboReset = true;
            currentComboTimer = ComboTimerReset;
            if (canAttack)
            {
                if (current_attack == Combo.Kick1)
                {
                    player_anim.Kick_1();
                }
                if (current_attack == Combo.Kick2)
                {
                    player_anim.Kick_2();
                }
                if (current_attack == Combo.Kick3)
                {
                    player_anim.Kick_3();
                }

                StartCoroutine(TimeBetweenAttack());
            }
            
        }
    }

    void ResetCombo()
    {
        if (ComboReset)
        {
            currentComboTimer -= Time.deltaTime;
            if(currentComboTimer <= 0f)
            {
                current_attack = Combo.None;
                ComboReset = false;
                currentComboTimer = ComboTimerReset;
            }
        }
    }

    IEnumerator TimeBetweenAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }
    
    public enum Combo
    {
        None,
        Punch1,
        Punch2,
        Punch3,
        Kick1,
        Kick2,
        Kick3,
    }
}
