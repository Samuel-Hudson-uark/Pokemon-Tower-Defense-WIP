using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyPanel : MonoBehaviour
{
    public Image currencyPanel;
    public Image currencyImage;
    public Text currencyTextBox;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onCurrencyChangedCallback += UpdateUI;
        inventory.GainCurrency(40);
    }

    // Update is called once per frame
    void UpdateUI()
    {
        currencyTextBox.text = inventory.currency.ToString();
    }

    public void TurnOn()
    {
        currencyPanel.enabled = true;
        currencyImage.enabled = true;
        currencyTextBox.enabled = true;
    }

    public void TurnOff()
    {
        currencyPanel.enabled = false;
        currencyImage.enabled = false;
        currencyTextBox.enabled = false;
    }
}
