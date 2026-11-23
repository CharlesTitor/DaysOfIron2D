using UnityEngine;

public enum DamageType
{
    Blunt, //2
    Crushing, //3
    Impact //1
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
