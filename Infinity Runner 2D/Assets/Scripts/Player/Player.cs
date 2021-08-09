using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    private Rigidbody2D rig;
    private bool isJumping;

    public Animator anim;
    public GameObject bulletPrefab;
    public Transform bulletPoint;

    public float speed;
    public float jumpForce;
    public int health;


    // Start is called before the first frame update
    void Start(){
        rig = GetComponent<Rigidbody2D>();   

    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            OnJump();
        }        
                     
    }

    public void OnShoot()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

    public void OnJump()
    {
        if (!isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            isJumping = true;
        }

        
    }

    //Chamado pela física da Unity
    private void FixedUpdate(){
        rig.velocity = new Vector2(speed, rig.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 3)
        {
            anim.SetBool("jumping", false);
            isJumping = false;
        }
        
    }

    public void OnHit(int dmg)
    {
        health-=  dmg;

        if(health <= 0)
        {
            GameController.instance.ShowGameOver();
        }
    }
}
