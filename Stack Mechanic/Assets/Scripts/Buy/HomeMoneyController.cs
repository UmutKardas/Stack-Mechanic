using System.Collections.Generic;
using UnityEngine;

public class HomeMoneyController : MonoBehaviour
{

    [SerializeField] private Transform[] moneySpawnPoints;
    [SerializeField] private GameObject moneyPrefab;


    public List<GameObject> moneyList = new List<GameObject>();
    public int spawnIndex = 0;
    public bool isHeroInside = false;


    [Header("Time Values")]
    [SerializeField] private float time;
    private float currentTime;



    private void Update()
    {
        CreateNewMoney();
    }



    private void CreateNewMoney()
    {
        if (!isHeroInside)
        {
            if (currentTime <= 0)
            {
                currentTime = time;

                GameObject newMoney = Instantiate(moneyPrefab, moneySpawnPoints[spawnIndex].position, transform.rotation);
                moneyList.Add(newMoney);
                newMoney.GetComponent<BoxCollider>().enabled = false;
                spawnIndex++;

                if (spawnIndex >= moneySpawnPoints.Length)
                {
                    spawnIndex = 0;
                    for (int i = 0; i < moneySpawnPoints.Length; i++)
                    {
                        moneySpawnPoints[i].transform.position = new Vector3(moneySpawnPoints[i].transform.position.x, moneySpawnPoints[i].transform.position.y + 0.5f, moneySpawnPoints[i].transform.position.z);
                    }
                }
            }

            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }



    public void ResetMoneySpawnPoints()
    {
        for (int i = 0; i < moneySpawnPoints.Length; i++)
        {
            moneySpawnPoints[i].transform.position = new Vector3(moneySpawnPoints[i].transform.position.x, 0.5f, moneySpawnPoints[i].transform.position.z);
        }
    }
}
