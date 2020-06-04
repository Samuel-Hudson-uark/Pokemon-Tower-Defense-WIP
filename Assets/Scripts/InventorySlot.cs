using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Button yourButton;
    public InventoryUI ui;
    public bool isOn = false;

    public Image uiImage;
    public Text pokemonName;
    public Image icon;
    public Text cost;
    public Pokemon pokemon;

    private float cooldownTime;
    private float timeStamp = 0f;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void AddItem(Pokemon newPokemon)
    {
        pokemon = newPokemon;
        cooldownTime = pokemon.cooldown;
        pokemonName.text = pokemon.name;
        icon.sprite = pokemon.icon;
        cost.text = pokemon.cost.ToString();
        uiImage.enabled = true;
        pokemonName.enabled = true;
        icon.enabled = true;
        cost.enabled = true;
    }

    public void ClearSlot()
    {
        pokemon = null;
        cooldownTime = 0f;
        pokemonName.text = "";
        icon.sprite = null;
        cost.text = "";
        uiImage.enabled = false;
        pokemonName.enabled = false;
        icon.enabled = false;
        cost.enabled = false;
        if(isOn)
        {
            UnitManager.instance.selectedPokemon = null;
            isOn = false;
            uiImage.color = Color.white;
        }
    }

    void TaskOnClick()
    {
        if (Inventory.instance.editingMode)
        {
            Inventory.instance.Remove(pokemon);
        }
        else if (timeStamp <= Time.time)
        {
            ui.ToggleButton(this);
        }

    }

    public void PlacePokemon()
    {
        ui.ToggleButton(this);
        timeStamp = Time.time + cooldownTime;
    }
}
