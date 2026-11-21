using UnityEngine;

public enum DamageType
{
    Blunt,
    Crushing,
    Impact
}

[System.Serializable]
public class AttackData
{
    public string placeholderName;
    public int fixedDamage;
    public DamageType damageType;
}

[CreateAssetMenu(fileName = "NewHammer", menuName = "Weapons/Hammer")]
public class HammerData : ScriptableObject
{
    public string weaponName;
    public Sprite hammerSprite;

    [Header("Placeholder Attacks")]
    public AttackData basicAttack;
    public AttackData mediumAttack;
    public AttackData heavyAttack;
}
