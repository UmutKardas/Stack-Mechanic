using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputController : MonoBehaviour
{

    [SerializeField] private HeroDataTransmitter heroDataTransmitter;
    [HideInInspector] public Vector3 movementDirection;



    void Update()
    {
        HandleHeroInputs();
    }



    private void HandleHeroInputs()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");

        heroDataTransmitter.SetHeroRunAnimation();
    }
}
