using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    [Header("Movimentação")]
    [SerializeField] private float speed;
    private Vector2 target;

    [Header("Sprites")]
    [SerializeField] private float xTH;
    [SerializeField] private float yTHLarge;
    [SerializeField] private float yTHNarow;

    private SpriteRenderer sprite;

    [SerializeField] private Sprite spriteUp;
    [SerializeField] private Sprite spriteNormal;
    [SerializeField] private Sprite spriteDown;

    [HideInInspector] public bool isMoving;
    private bool isFliped;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        sprite = GetComponent<SpriteRenderer>();

        Vector2 targetPosition;
        targetPosition.x = transform.position.x;
        targetPosition.y = transform.position.y;
        target = new Vector2(targetPosition.x, targetPosition.y);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            Move();
        }
    }

    public void CheckMovement()
    {
        Vector2 position = transform.position;

        if (position == target)
        {
            StopMoving();
            return;
        }

        StartMoving();
    }

    public void StartMoving()
    {
        isMoving = true;

        ChangeSprite();
    }

    public void SetTarget(Vector2 targetPosition)
    {
        target = new Vector2(targetPosition.x, targetPosition.y);
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        Vector2 position = transform.position;

        if (position == target)
        {
            StopMoving();
        }
    }

    public void StopMoving()
    {
        isMoving = false;
        anim.Play("IdleFront");

        if (Manager.instance.isInteracting == true)
        {
            Manager.instance.LoopInteraction();
        }
    }

    public void ChangeSprite()
    {
        if (target.x < transform.position.x + xTH && target.x > transform.position.x - xTH)
        {
            if (target.y < transform.position.y - yTHNarow)
            {
                sprite.sprite = spriteDown;
                anim.Play("WalkindFoward");
            }

            else if (target.y > transform.position.y + yTHNarow)
            {
                sprite.sprite = spriteUp;
                anim.Play("WalkingBack");
            }
        }

        else
        {
            if (target.y < transform.position.y - yTHLarge)
            {
                sprite.sprite = spriteDown;
                anim.Play("WalkindFoward");
            }

            else if (target.y > transform.position.y + yTHLarge)
            {
                sprite.sprite = spriteUp;
                anim.Play("WalkingBack");
            }
        }

        if (transform.position.y - yTHLarge < target.y && target.y < transform.position.y + yTHLarge)
        {
            sprite.sprite = spriteNormal;
            anim.Play("WalkindSide");
        }

        if (transform.position.x > target.x && isFliped == false)
        {
            Flip();
        }

        else if (transform.position.x < target.x && isFliped == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        sprite.flipX = !sprite.flipX;
        isFliped = !isFliped;
    }
}
