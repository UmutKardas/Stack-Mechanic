using UnityEngine;
using Kardas;

public class HeroCollisionController : MonoBehaviour
{

    [SerializeField] private HomeMoneyController homeMoneyController;
    [SerializeField] private HeroDataTransmitter heroDataTransmitter;
    private bool heroPoolInside = false;


    [Header("Time Values")]
    [SerializeField] private float time;
    private float currentTime;



    private void Update()
    {
        StackHomeMoneyPool();
    }



    private void StackHomeMoneyPool()
    {
        if (heroPoolInside)
        {
            for (int i = 0; i < homeMoneyController.moneyList.Count; i++)
            {
                if (currentTime <= 0)
                {
                    currentTime = 5;
                    heroDataTransmitter.AddNewMoneyStack(homeMoneyController.moneyList[i]);
                    homeMoneyController.moneyList.RemoveAt(i);
                }

                else
                {
                    currentTime -= Time.deltaTime;
                }
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.MONEY))
        {
            heroDataTransmitter.AddNewMoneyStack(other.gameObject);
        }


        if (other.gameObject.CompareTag(Tag.MONEY_POOL))
        {
            homeMoneyController = GameObject.FindObjectOfType<HomeMoneyController>();
            homeMoneyController.isHeroInside = true;
            heroPoolInside = true;
        }

    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.MONEY_POOL))
        {
            homeMoneyController.isHeroInside = false;
            homeMoneyController.spawnIndex = 0;
            heroPoolInside = false;
            homeMoneyController.ResetMoneySpawnPoints();
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.HOME_AREA))
        {
            heroDataTransmitter.DeacreaseMoneyStack(other.gameObject);
            other.gameObject.GetComponent<BuyController>().SetMoneyBarFillAmout();
        }


        if (other.gameObject.CompareTag(Tag.STORE_AREA))
        {
            heroDataTransmitter.DeacreaseMoneyStack(other.gameObject);
            other.gameObject.GetComponent<BuyController>().SetMoneyBarFillAmout();
        }
    }



    public void IncreaseCurrentMoney(GameObject _gameObject)
    {
        if (currentTime <= 0)
        {
            currentTime = time;
            if (_gameObject.GetComponent<BuyController>().currentMoney < _gameObject.GetComponent<BuyController>().maxMoney)
            {
                _gameObject.GetComponent<BuyController>().currentMoney += _gameObject.GetComponent<BuyController>().sellMoney;
            }
        }

        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}

