using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // public int playerId = 0;
    public Animator animatorTop;
    public Animator animatorBottom;
    public GameObject crossHair;
    public GameObject arrowPrefab;
    [SerializeField] float arrowVelocity = 3f;
    

    //private Player player;

    void Awake()
    {
       //player = ReInput.players.GetPlayer(playerId);

    }

    void Update()
    {
        AimAndShoot();
        Vector2 shootingDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        Vector3 aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"),0.0f);

        //shooting
        // if (Input.GetButton("Fire") || Input.GetButtonDown("Fire1"))
        // {
        //     GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);//this instantiaes the arrow
        //     arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowVelocity;//this will project the arrow and give it a speed
        //     arrow.transform.Rotate(0.0f,0.0f,Mathf.Atan2(shootingDirection.y, shootingDirection.x)* Mathf.Rad2Deg);//this will keep the arrows rotation in the same direction that its shoot and not some inorganic way
        //     Destroy(arrow,2.0f);
        // }
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
        animatorTop.SetBool("Aim",Input.GetButton("Fire1"));

        transform.position = transform.position + movement * Time.deltaTime;
    }
    //magitude is the speed or maybe movement pressure at which the animation shoudl start


    private void AimAndShoot(){

        Vector2 shootingDirection = new Vector2(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"));
        Vector3 aim = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);
    
        if(aim.magnitude > 0.0f){
            aim.Normalize();//this will only allow the aimer to be within a certain amount of untits away from him.
            aim *= 0.4f;
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true);
            shootingDirection.Normalize();
        if (Input.GetButton("Fire") || Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Fire the arrow!");
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
