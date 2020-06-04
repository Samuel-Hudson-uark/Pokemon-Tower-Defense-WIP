using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPartyManagerButton : MonoBehaviour
{
	public Button yourButton;
	public Image panel;
	public Image currency;
	CurrencyPanel currencyPanel;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		currencyPanel = currency.GetComponent<CurrencyPanel>();
	}

	void TaskOnClick()
	{
		if(panel.enabled)
		{
			foreach (Image i in panel.GetComponentsInChildren<Image>())
			{
				i.enabled = false;
			}
			panel.enabled = false;
			currencyPanel.TurnOn();
			Inventory.instance.editingMode = false;
		} 
		else
		{
			foreach (Image i in panel.GetComponentsInChildren<Image>())
			{
				i.enabled = true;
			}
			panel.enabled = true;
			currencyPanel.TurnOff();
			Inventory.instance.editingMode = true;
		}

	}
}