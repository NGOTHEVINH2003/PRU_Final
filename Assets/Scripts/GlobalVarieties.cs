using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarieties : MonoBehaviour
{
    public static GlobalVarieties global;
    public int p1currentHealth = 100;
    public int p2currentHealth = 100;
    public int p1MaxHealth = 100;
    public int p2MaxHealth = 100;
    public bool p1takenDamage = false;
    public bool p2takenDamage = false;
    public bool p1isBlocking = false;
    public bool p2isBlocking = false;
    public bool p1Death = false;
    public bool p2Death = false;

    // Start is called before the first frame update
    void Start()
    {
        global = this;
    }

}
