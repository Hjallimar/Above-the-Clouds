using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 0.5f;
    [SerializeField] private float rotationSpeed = 0.2f;
    [SerializeField] private float acceleration = 0.2f;
    [SerializeField] private Transform playerDeckPosition;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject dockedBridge;
    public Transform playerSteeringPos;
    private float currentSpeed = 0.0f;
    public bool PlayerSteering { get; set; } = true;
    public bool Docked { get; set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (!Docked)
        {
            if (PlayerSteering)
            {
                currentSpeed = Input.GetAxisRaw("Horizontal") > 0 ? maxSpeed / 2 : maxSpeed;
                transform.RotateAround(transform.position, Vector3.up, Input.GetAxisRaw("Horizontal") * rotationSpeed);
                transform.position += transform.forward.normalized * currentSpeed * Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.T))
                {
                    PlayerSteering = false;
                    player.OnDeck = true;
                    player.transform.position = playerDeckPosition.position;
                    player.transform.SetParent(null);
                }
            }
        }
    }


    public void GettingDocked(bool status)
    {
        Docked = status;
        dockedBridge.SetActive(status);
        player.OnDeck = status;
    }
}
