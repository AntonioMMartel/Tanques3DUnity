using UnityEngine;

public class BulletBox : MonoBehaviour, IHittable
{
    [SerializeField] int ammoAmount = 10;

    public void Hit(GameObject hitter)
    {
        Bullet bullet = hitter.GetComponent<Bullet>();
        TankAttack tank = bullet.owner.GetComponent<TankAttack>();
        if (tank != null)
        {
            tank.AddAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
