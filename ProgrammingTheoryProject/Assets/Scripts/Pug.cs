using UnityEngine;
//INHERITANCE
public class Pug : Dog
{
    int Speed = 1;
    Animator animator;
    Vector3 jumpVector = new Vector3(0, 20, 20);
    bool onGround = true;
    float time = 1.0f;
    private void Start()
    {
        AnimalName = "Pug";
        InvokeRepeating("Move", 1f, Random.Range(1, 3));
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed_f", 0.0f);
    }
    private void Update()
    {
        Jump();
    }

    protected void Move()
    {
        base.Move(Speed);
    }
    //POLYMORPHISM
    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = transform.position + jumpVector;
            onGround = false;
        }
        if (!onGround)
        {
            time -= Time.deltaTime;
        }
        if (time < 0.0f)
        {
            transform.position = transform.position - jumpVector;
            onGround = true;
            time = 1.0f;
        }
    }
}

