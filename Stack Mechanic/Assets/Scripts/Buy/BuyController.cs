using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyController : MonoBehaviour
{

    [SerializeField] private GameObject modelGameObject;
    [SerializeField] private GameObject storeObjectBar;

    public float maxMoney;
    public float currentMoney;
    public float sellMoney;


    [SerializeField] private Image moneyBar;
    [SerializeField] private TMP_Text sellText;



    void Start()
    {
        SetMoneyBarFillAmout();
    }



    public void SetMoneyBarFillAmout()
    {
        moneyBar.fillAmount = currentMoney / maxMoney;

        CheckModelObjectActive();
        SetSellTextValue();
    }



    public void CheckModelObjectActive()
    {
        if (currentMoney >= maxMoney)
        {
            modelGameObject.SetActive(true);
            storeObjectBar.SetActive(true);
        }
    }



    private void SetSellTextValue()
    {
        sellText.text = currentMoney + " / " + maxMoney;
    }
}
