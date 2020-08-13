using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineCouchFerretWithBrackeys : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHair;
    public GameObject arrowPrefab;
    
    [SerializeField] float arrowVelocity = 5f;
    [SerializeField] float moveSpeed = 1f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    
    //private Player player;


    void Update()
    {

        // MoveCrossHairs();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    

        // if (Input.GetButton("Fire") || Input.GetButtonDown("Fire1"))
        // {
        //     Debug.Log("Fire the arrow!");
        //     GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        //     arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowVelocity,0.0f);
        // }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
        //crossHair.transform = mousPos;
    }
     void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}


