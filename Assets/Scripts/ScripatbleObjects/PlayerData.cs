using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public ItemObject PlayerVisual;
    public int Money;
    public int Health;
}