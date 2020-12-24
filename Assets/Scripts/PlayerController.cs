using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator anim;
    

    [Header("Config Player")]
    public float player_speed = 3f;
    private Vector3 direction;
    private bool isWalk;


    [Header("Attack Config")]
    public ParticleSystem fxAttack;
    
    [SerializeField]
    private bool isAttack;

    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        MoveCharacter();
        UpdateAnimator();
    }

    void Attack()
    {   
        if (isAttack == false)
        {
            isAttack = true;
            anim.SetTrigger("Attack");
            fxAttack.Emit(1);
        }
    }

    void Inputs() 
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void MoveCharacter()
    {
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
        controller.Move(direction * player_speed * Time.deltaTime);
    }

    void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk);
    }

    void AttackIsDone()
    {
        isAttack = false;
    }
}

   
        
    

