using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public int playerId = 0;
    public Animator animatorTop;
    public Animator animatorBottom;
    public GameObject crossHair;
    public GameObject arrowPrefab;
    [SerializeField] float arrowVelocity = 3f;
    
    Vector2 shootingDirection;
    Vector3 movement;
    Vector3 aim;
    bool isAiming;
    bool endOfAiming;

    public bool useController;

    //private Player player;

    void Awake()
    {
       //player = ReInput.players.GetPlayer(playerId);

    }

    void Update()
    {
        ProcessInputs();
        AimAndShoot();
        Animate();
        Move();


    }
    private void Animate(){

        //we are aiming anytime so you need to connect aim from idle and run because both can tranistion into it
        //animation movements
        animatorBottom.SetFloat("MoveHorizontal", movement.x);
        animatorBottom.SetFloat("MoveVertical", movement.y);
        animatorBottom.SetFloat("MoveMagnitude", movement.magnitude);//magitude is the speed or maybe movement pressure at which the animation shoudl start
        
        animatorTop.SetFloat("MoveHorizontal", movement.x);
        animatorTop.SetFloat("MoveVertical", movement.y);
        animatorTop.SetFloat("MoveMagnitude", movement.magnitude);//magitude is the speed or maybe movement pressure at which the animation shoudl start
        

        animatorTop.SetFloat("AimHorizontal", aim.x);
        animatorTop.SetFloat("AimVertical", aim.y);
        animatorTop.SetFloat("AimMagnitude", aim.magnitude);//magitude is the speed or maybe movement pressure at which the animation shoudl start
        animatorTop.SetBool("Aim",isAiming);

    }

    private void Move(){
        transform.position = transform.position + movement * Time.deltaTime;

    }

    private void ProcessInputs(){

        if(useController)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"),0.0f);
            aim.Normalize();//this will only allow the aimer to be within a certain amount of untits away from him.
            isAiming = Input.GetButton("Fire"); //this will be true when the button is pressed
            endOfAiming = Input.GetButton("Fire") || Input.GetButtonUp("Fire1");//only true when the button is released
        }
        else
        {   
        

        }

    }



    private void AimAndShoot(){

        shootingDirection = new Vector2(aim.x, aim.y);
    
        if(aim.magnitude > 0.0f){
            // aim *= 0.4f;
            crossHair.transform.localPosition = aim * 0.4f;
            crossHair.SetActive(true);
            shootingDirection.Normalize();

            shootingDirection.Normalize();
        if (endOfAiming)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowVelocity;
            //arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowVelocity,0.0f);
            arrow.transform.Rotate(0,0,Mathf.Atan2(shootingDirection.y,shootingDirection.x)* Mathf.Rad2Deg);
            Destroy(arrow,2.0f);
        }
        }
    else
         {
        crossHair.SetActive(false);
    }
    
    } 

//aim has a transition time of 2 so it will play 2 times before exiting
//the fire has a condition to decide weather it should move to the run state or the move state
}
