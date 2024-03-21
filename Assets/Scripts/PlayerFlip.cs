using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player1;
    public Transform player2;
    public bool flip = false;
  
    // Update is called once per frame
    void Update()
    {
        float p1pos = player1.position.x;
        float p2pos = player2.position.x;
        if(p1pos < p2pos)
        {
            player1.localScale= new Vector3(5, 5, 0);
            player2.localScale = new Vector3(-5, 5, 0);
            flip = true;
        }
        else
        {
            player1.localScale = new Vector3(-5, 5, 0);
            player2.localScale = new Vector3(5, 5, 0);
            flip = false;
        }
    }
}
