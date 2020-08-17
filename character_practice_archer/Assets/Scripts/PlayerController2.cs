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

        //AimAndShoot();

        Vector2 shootingDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        //shooting
        if (Input.GetButton("Fire") || Input.GetButtonDown("Fire1"))
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);//this instantiaes the arrow
            arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * arrowVelocity;//this will project the arrow and give it a speed
            
            arrow.transform.Rotate(0.0f,0.0f,Mathf.Atan2(shootingDirection.y, shootingDirection.x)* Mathf.Rad2Deg);//this will keep the arrows rotation in the same direction that its shoot and not some inorganic way
            Destroy(arrow,2.0f);
        }

        //animation movements
        animatorBottom.SetFloat("Horizontal", movement.x);
        animatorBottom.SetFloat("Vertical", movement.y);
        animatorBottom.SetFloat("Magnitude", movement.magnitude);//magitude is the speed or maybe movement pressure at which the animation shoudl start

        transform.position = transform.position + movement * Time.deltaTime;
    }
    //magitude is the speed or maybe movement pressure at which the animation shoudl start


    // private void AimAndShoot(){
    //     //if i manage to get a controlelr set up I can use this... 
    //     //Vector3 aim = new Vector3(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"),0.0f);
    //     //until then I will use arrow keys
    //     Vector2 shootingDirection = new Vector2(player.GetAxis("AimHorizontal"), player.GetAxis("AimVertical"));
    //     Vector3 aim = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);
    //     if(aim.magnitude > 0.0f){
    //         aim.Normalize();//this will only allow the aimer to be within a certain amount of untits away from him.
    //         aim *= 0.4f;
    //         crossHair.transform.localPosition = aim;
    //         crossHair.SetActive(false);
    //   if (Input.GetButton("Fire") || Input.GetButtonDown("Fire1"))
    //     {
    //         Debug.Log("Fire the arrow!");
    //         GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
    //         arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowVelocity,0.0f);
    //     }
    //     }
    //      else{
    //     crossHair.SetActive(false);
    // }
    
    // } 


}
