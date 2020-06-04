using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour
{
	public Button yourButton;
	public Image buttonImage;
	public Pokemon pokemon;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		buttonImage.sprite = pokemon.icon;
	}

	void TaskOnClick()
	{
		Inventory.instance.Add(pokemon);
	}
}
