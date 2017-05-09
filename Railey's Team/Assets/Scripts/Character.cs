using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class Character : Unit
    {   
        public static Character instance;
        [SerializeField]
        private int lives = 6;
        private int coins = 0;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 6) lives = value;
            livesBar.Refresh();
        }
    }
    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
        }
    }
    private LivesBar livesBar;


    [SerializeField]
    private float speed = 10.0F;
    [SerializeField]
    private float jumpForce = 0.5F;

    private bool isGrounded = false;

    private Bullet bullet;
    
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }


    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite; //изменение положения вправо влево


    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }


    private void Update()
    {
        CheckDeath();   
        CheckGround();
        if (isGrounded) State = CharState.Idle;
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButton("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);// время 
        sprite.flipX = direction.x < 0.0F;
        State = CharState.Run;
        if (!isGrounded) State = CharState.Jump;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce*3, ForceMode2D.Impulse);
        State = CharState.Jump;
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y -= 0.5F;//позиция пули
      //  position.x -= 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
         newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);//направление пули от направления чувака 
    }

    public override void ReceiveDamage()
    {
        Lives--;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up *8.0F, ForceMode2D.Impulse);// при прыжке на обьект отбрасывает
        Debug.Log(lives);
        if (lives == 0)
            SceneManager.LoadScene(3);
    }

    private void CheckGround()
    {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0F);
        if (rigidbody.velocity.y == 0)
            isGrounded = colliders.Length > 1;
        else
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();

        if (unit) ReceiveDamage();
    }// если монстр коснулся героя отнимаем силу

    private void CheckDeath (){

        if (transform.position.y<-8.0F){
            SceneManager.LoadScene(3);
        }
    }


}

public enum CharState
{
    Idle,//0
    Run,//1
    Jump
}