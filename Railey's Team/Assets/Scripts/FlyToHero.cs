using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FlyToHero : Monster {

    [SerializeField]
    new private Rigidbody2D rigidbody;
    public float speed = 10f;
    private Vector3 pos;

    private Vector3 direction;

    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction = rigidbody.transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - rigidbody.transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        

        pos = GameObject.Find("Character").transform.position;
        float MoveToCoor = rigidbody.transform.position.x - pos.x;
        if ((rigidbody.transform.position.x > pos.x && MoveToCoor < 5 ) || (rigidbody.transform.position.x < pos.x && MoveToCoor > -5))
        {
            rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, pos, step);
        }
        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(rigidbody.transform.position + rigidbody.transform.up * 0.5F + rigidbody.transform.right * direction.x * 0.1F, 0.0F);
            if (colliders.Length >= 0)

            rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, rigidbody.transform.position + direction, speed * Time.deltaTime);
        }
    }
    
}
