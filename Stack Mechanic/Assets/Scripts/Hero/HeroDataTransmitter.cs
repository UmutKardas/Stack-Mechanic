using UnityEngine;

public class HeroDataTransmitter : MonoBehaviour
{

    [SerializeField] private HeroInputController heroInputController;
    [SerializeField] private HeroAnimationController heroAnimationController;
    [SerializeField] private HeroStackController heroStackController;



    public Vector3 GetHeroMovementDirection()
    {
        return heroInputController.movementDirection;
    }



    public void SetHeroRunAnimation()
    {
        heroAnimationController.SetHeroAnimations();
    }



    public void AddNewMoneyStack(GameObject _gameObject)
    {
        heroStackController.AddNewMoneyStack(_gameObject);
    }



    public void DeacreaseMoneyStack(GameObject _gameObject)
    {
        heroStackController.DeacreaseMoneyStack(_gameObject);
    }
}
