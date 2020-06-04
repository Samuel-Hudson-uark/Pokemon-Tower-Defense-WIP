using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Inventory/Pokemon")]

public class Pokemon : ScriptableObject
{
    public int id = 0;
    new public string name = "Pokemon";
    public Sprite icon = null;
    public int cost = 0;
    public float cooldown = 0;
    public GameObject pokemon = null;
    public string description = "Default description.";
}
