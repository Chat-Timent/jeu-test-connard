using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Upgrades/New Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;
    public virtual void Apply(PlayerStats player)
    {

    }
}
