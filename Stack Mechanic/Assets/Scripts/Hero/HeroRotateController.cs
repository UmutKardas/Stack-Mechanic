using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRotateController : MonoBehaviour
{

    [SerializeField] private HeroDataTransmitter heroDataTransmitter;
    [SerializeField] private float lerpValue;



    void Update()
    {
        SetHeroRotate();
    }



    public void SetHeroRotate()
    {
        if (heroDataTransmitter.GetHeroMovementDirection().x > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), lerpValue * Time.deltaTime);
        }
        else if (heroDataTransmitter.GetHeroMovementDirection().x < 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90f, 0), lerpValue * Time.deltaTime);
        }
        else if (heroDataTransmitter.GetHeroMovementDirection().x > 0f && heroDataTransmitter.GetHeroMovementDirection().z > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 35f, 0), lerpValue * Time.deltaTime);
        }
        else if (heroDataTransmitter.GetHeroMovementDirection().z > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), lerpValue * Time.deltaTime);
        }
        else if (heroDataTransmitter.GetHeroMovementDirection().z < 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180f, 0), lerpValue * Time.deltaTime);
        }
    }
}