using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator p1Anim;
    public Animator p2Anim;
    public Player1Movement player1;
    public Player2Movement player2;
    public Player1Attack attack1;
    public Player2Attack attack2;
    public StartMenuScript script;
    // Update is called once per frame
    void Update()
    {
        if(GlobalVarieties.global.p1currentHealth <= 0)
        {
            attack1.enabled = false;
            p1Anim.SetBool("Death", true);
            p1Anim.SetBool("Damaged", false);
            player1.enabled = false;
            GlobalVarieties.global.p1Death = true;
            script.EndGame();
        }
        if(GlobalVarieties.global.p2currentHealth <= 0)
        {
            attack2.enabled = false;
            p2Anim.SetBool("Death", true);
            p2Anim.SetBool("Damaged", false);
            player2.enabled = false;
            GlobalVarieties.global.p2Death = true;
            script.EndGame();
        }
    }
}
