using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    private IDamageable _target;

    public void AttackAction()
    {;

        if( _target == null )
        {
            return;
        }

        _target.TakeDamage(_damage);
    }

}
