using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    //perform attack variable
    private PlayerAnimation player_anim;
    private bool ComboReset;
    private float ComboTimerReset = 0.4f;
    private float currentComboTimer;
    private float attackCoolDown = 0.25f;
    private bool canAttack = true;
    private Combo current_attack;
    //attack variable
    public BoxCollider2D hitbox;
    public BoxCollider2D hurtbox;
    private int damageTimer;
    private int hitStuntimer;
    public Animator p1Animator;
    //health variable
    public PlayerHealth p1health;
    public PlayerHealth p2health;

    // Start is called before the first frame update
    void Awake()
    {
        player_anim = GetComponent<PlayerAnimation>();
    }
    private void Start()
    {
        GlobalVarieties.global.p2currentHealth = GlobalVarieties.global.p2MaxHealth;
        p2health.SetMaxHealth(GlobalVarieties.global.p2MaxHealth);
        p2health.disPlayCurrentHealth(GlobalVarieties.global.p2MaxHealth);
        currentComboTimer = ComboTimerReset;
        current_attack = Combo.None;
        hitbox.isTrigger = true;
    }
    // Update is called once per frame
    void Update()
    {
        p2health.disPlayCurrentHealth(GlobalVarieties.global.p2currentHealth);
        ComboAttacks();
        ResetCombo();
    }
    private void FixedUpdate()
    {
        DealDamage();
    }

    void DealDamage()
    {
        if(hitStuntimer != 0)
        {
            hitStuntimer--;
            GlobalVarieties.global.p1takenDamage = true;
            p1Animator.SetBool("Damaged", true);
        }
        else
        {
            GlobalVarieties.global.p1takenDamage = false;
            p1Animator.SetBool("Damaged", false);
        }
        if (damageTimer > 0)
        {
            damageTimer--;
        }
        if (hitbox.IsTouching(hurtbox) && !GlobalVarieties.global.p1takenDamage)
        {
            hitStuntimer = 15;
            if (current_attack == Combo.Punch1)
            {
                GlobalVarieties.global.p1currentHealth -= 5;
                Debug.Log("Attack1 received");
            }
            if (current_attack == Combo.Punch2)
            {
                GlobalVarieties.global.p1currentHealth -= 5;
                Debug.Log("Attack1 received");

            }
            if (current_attack == Combo.Punch3)
            {
                GlobalVarieties.global.p1currentHealth -= 8;
                Debug.Log("Attack1 received");

            }
            if (current_attack == Combo.Kick1)
            {
                GlobalVarieties.global.p1currentHealth -= 5;
                Debug.Log("Attack1 received");

            }
            if (current_attack == Combo.Kick2)
            {
                GlobalVarieties.global.p1currentHealth -= 5;
                Debug.Log("Attack1 received");

            }
            if (current_attack == Combo.Kick3)
            {
                GlobalVarieties.global.p1currentHealth -= 8;
                Debug.Log("Attack1 received");

            }
            p1health.SetHealth(GlobalVarieties.global.p1currentHealth);
        }
    }

    void ComboAttacks()
    {
        if (Input.GetKey(KeyCode.KeypadPeriod))
        {
            player_anim.Blocking();
            GlobalVarieties.global.p2isBlocking = true;
        }
        if(Input.GetKeyUp(KeyCode.KeypadPeriod))
        {
            GlobalVarieties.global.p2isBlocking = false;
        }

        //Punch
        if (Input.GetKeyDown(KeyCode.Keypad1) && !GlobalVarieties.global.p2isBlocking)
        {
            if (current_attack == Combo.Punch3 || current_attack == Combo.Kick3) return;

            if (current_attack == Combo.Kick1 || current_attack == Combo.Kick2 || current_attack == Combo.None)
            {
                current_attack = Combo.Punch1;
            }
            else if (canAttack)
            {
                current_attack++;
            }
            ComboReset = true;
            currentComboTimer = ComboTimerReset;
            if (canAttack)
            {
                if (current_attack == Combo.Punch1)
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
        if (Input.GetKeyDown(KeyCode.Keypad2) && !GlobalVarieties.global.p2isBlocking)
        {
            if (current_attack == Combo.Kick3 || current_attack == Combo.Punch3) return;

            if (current_attack == Combo.Punch1 || current_attack == Combo.Punch2 || current_attack == Combo.None)
            {
                current_attack = Combo.Kick1;
            }
            else if (canAttack)
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
            if (currentComboTimer <= 0f)
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
