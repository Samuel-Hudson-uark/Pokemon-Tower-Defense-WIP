using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcInterface : MonoBehaviour
{
    public Image PcBox;
    public Image PcButtonPrefab;
    PCManager pcManager;

    public Pokemon samplePokemon1;
    public Pokemon samplePokemon2;
    void Start()
    {
        pcManager = PCManager.instance;
        pcManager.onPcChangedCallback += UpdateUI;
        pcManager.Recruit(samplePokemon1);
        pcManager.Recruit(samplePokemon2);
    }

    void UpdateUI()
    {
        foreach(Transform child in PcBox.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Pokemon p in pcManager.PC.Values)
        {
            Image PcButton = (Image)Instantiate(PcButtonPrefab);
            ButtonClick buttonclick = (ButtonClick)PcButton.gameObject.GetComponent<ButtonClick>();
            buttonclick.pokemon = p;
            PcButton.transform.SetParent(PcBox.transform);
        }
    }
}
