using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private CapsuleCollider myCollider;
    [SerializeField] private BoatMovement myBoat;
    

    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    RaycastHit hit;

    Vector3 point1;
    Vector3 point2;
    public bool OnDeck { get; set; } = false;

    private void Start()
    {
        myBoat.PlayerSteering = true;
        OnDeck = false;
        transform.position = myBoat.playerSteeringPos.position;
        transform.SetParent(myBoat.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (OnDeck)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.z = Input.GetAxisRaw("Vertical");
            velocity = direction * maxSpeed * Time.deltaTime;
            if (CollisionCheck())
            {
                transform.position += velocity;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                myBoat.PlayerSteering = true;
                OnDeck = false;
                transform.position = myBoat.playerSteeringPos.position;
                transform.SetParent(myBoat.transform);
            }
        }
    }

    bool CollisionCheck()
    {
        point1 = transform.position + new Vector3(0,myCollider.height/2,0);
        point2 = transform.position + new Vector3(0, -myCollider.height / 2, 0);
        if (Physics.CapsuleCast(point1, point2, myCollider.radius, direction, out hit, maxSpeed * Time.deltaTime))
        {
            return false;
        }
        return true;
    }
}
