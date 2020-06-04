using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Transform pokemonParent;
    Inventory inventory;
    UnitManager manager;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        manager = UnitManager.instance;
        inventory.onPokemonChangedCallback += UpdateUI;

        slots = pokemonParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        //Debug.Log("Updating UI");
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.party.Count)
            {
                slots[i].AddItem(inventory.party[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void ToggleButton(InventorySlot slot)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i] == slot)
            {
                if(slots[i].isOn == false)
                {
                    slots[i].uiImage.color = Color.green;
                    manager.selectedPokemon = slots[i].pokemon;
                    slots[i].isOn = true;
                    inventory.selectedButton = slots[i];
                }
                else
                {
                    manager.selectedPokemon = null;
                    slots[i].uiImage.color = Color.white;
                    slots[i].isOn = false;
                    inventory.selectedButton = null;
                }
            }
            else if(slots[i].isOn)
            {
                slots[i].uiImage.color = Color.white;
                slots[i].isOn = false;
            }
        }
    }
} 
