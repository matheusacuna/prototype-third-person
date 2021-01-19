using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIA : MonoBehaviour
{   
    private Animator anim;
    public int hp;

    private bool isDie;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Died()
    {
        isDie = true;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    void GetHit(int amount)
    {   
      if (isDie== true) { return; }

        hp -= amount;

        if(hp > 0)
        {
            anim.SetTrigger("GetHit");
        }
        else
        {
            anim.SetTrigger("Die");
            StartCoroutine("Died");
        }
        
    }
}
