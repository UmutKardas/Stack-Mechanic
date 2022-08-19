using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HeroStackController : MonoBehaviour
{

    public List<GameObject> moneyList = new List<GameObject>();
    [SerializeField] private GameObject lastObject;
    [SerializeField] private float verticalIncrementValue;
    [SerializeField] private float moveTime;


    [Header("Scale Values")]
    [SerializeField] private Vector3 currentScale;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float scaleAnimationTime;


    [Header("Time Values")]
    [SerializeField] private float time;
    private float currentTime;



    void Start()
    {
        lastObject = moneyList[0];
    }



    public void AddNewMoneyStack(GameObject _gameObject)
    {
        moneyList.Add(_gameObject);
        _gameObject.transform.SetParent(transform);
        _gameObject.transform.rotation = transform.rotation;
        _gameObject.transform.DOLocalMove(new Vector3(0f, lastObject.transform.localPosition.y + verticalIncrementValue, lastObject.transform.localPosition.z), moveTime);
        lastObject = _gameObject;
        SetMoneyScaleAnimation();
    }



    private void SetMoneyScaleAnimation()
    {
        Sequence mySequence = DOTween.Sequence();
        if (moneyList.Count > 1)
        {
            for (int i = 0; i < moneyList.Count; i++)
            {
                mySequence.Append(moneyList[i].transform.DOScale(targetScale, scaleAnimationTime)).
                Append(moneyList[i].transform.DOScale(currentScale, scaleAnimationTime));
            }
        }
    }



    public void DeacreaseMoneyStack(GameObject _gameObject)
    {
        for (int i = moneyList.Count - 1; i >= 1; i--)
        {
            if (_gameObject.GetComponent<BuyController>().currentMoney < _gameObject.GetComponent<BuyController>().maxMoney)
            {
                if (currentTime <= 0)
                {
                    currentTime = time;
                    moneyList[i].transform.parent = null;
                    moneyList[i].GetComponent<BoxCollider>().enabled = false;
                    _gameObject.GetComponent<BuyController>().currentMoney += _gameObject.GetComponent<BuyController>().sellMoney;
                    moneyList[i].transform.DOMove(_gameObject.transform.position, 0.2f);
                    moneyList.RemoveAt(i);
                    lastObject = moneyList[moneyList.Count - 1];
                }

                else
                {
                    currentTime -= Time.deltaTime;
                }
            }

        }
    }
}
