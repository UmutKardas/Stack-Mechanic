using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{

    [SerializeField] private HeroDataTransmitter heroDataTransmitter;
    [SerializeField] private Animator animator;



    public void SetHeroAnimations()
    {
        animator.SetBool("isRun", CheckHeroRunMovement());
    }



    public bool CheckHeroRunMovement()
    {
        return Mathf.Abs(heroDataTransmitter.GetHeroMovementDirection().x) > 0 || Mathf.Abs(heroDataTransmitter.GetHeroMovementDirection().z) > 0;
    }
}
