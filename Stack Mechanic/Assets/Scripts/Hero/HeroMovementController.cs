using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{

    [SerializeField] private HeroDataTransmitter heroDataTransmitter;
    [SerializeField] private Rigidbody heroRigidBody;
    [SerializeField] private float movementSpeed;



    private void FixedUpdate()
    {
        SetHeroRunMovement();
    }



    private void SetHeroRunMovement()
    {
        heroRigidBody.velocity = new Vector3(heroDataTransmitter.GetHeroMovementDirection().x * movementSpeed * Time.fixedDeltaTime, heroRigidBody.velocity.y, heroDataTransmitter.GetHeroMovementDirection().z * movementSpeed * Time.fixedDeltaTime);
    }
}
