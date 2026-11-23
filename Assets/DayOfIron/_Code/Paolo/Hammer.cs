using UnityEngine;

public class Hammer : MonoBehaviour
{
    public HammerData weaponData;
    public SpriteRenderer spriteRenderer;

    [SerializeField] private Attack _attack;

    void Start()
    {
        UpdateSprite();
    }

    void OnValidate()
    {
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        if (weaponData != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = weaponData.hammerSprite;
        }
    }

    public AttackData UseBasicAttack()
    {
        /*
        Debug.Log("Placeholder: " + weaponData.basicAttack.placeholderName + " | Damage: " + weaponData.basicAttack.fixedDamage + " (" + weaponData.basicAttack.damageType + ")");
        return weaponData.basicAttack;
        */
        _attack.AttackAction(weaponData.basicAttack);
    }

    public AttackData UseMediumAttack()
    {
        /*
        Debug.Log("Placeholder: " + weaponData.mediumAttack.placeholderName + " | Damage: " + weaponData.mediumAttack.fixedDamage + " (" + weaponData.mediumAttack.damageType + ")");
        return weaponData.mediumAttack;
        */
        _attack.AttackAction(weaponData.mediumAttack);
    }

    public AttackData UseHeavyAttack()
    {
        /*
        Debug.Log("Placeholder: " + weaponData.heavyAttack.placeholderName + " | Damage: " + weaponData.heavyAttack.fixedDamage + " (" + weaponData.heavyAttack.damageType + ")");
        return weaponData.heavyAttack;
        */
        _attack.AttackAction(weaponData.heavyAttack);
    }
}