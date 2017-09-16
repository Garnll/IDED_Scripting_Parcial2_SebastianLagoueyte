using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parcial2.Game
{
    public class BulletExplosive : Bullet
    {
        protected override void CambiarParametrosAlDesaparecer()
        {
            Collider[] otherColliders = Physics.OverlapSphere(transform.position, 10F);

            for (int i = 0; i < otherColliders.Length; i++)
            {
                if (otherColliders[i].gameObject == gameObject)
                {
                    continue;
                }
                else
                {
                    Enemy enemy = otherColliders[i].GetComponent<Enemy>();

                    if (enemy != null)
                    {
                        enemy.ReceiveDamage(damage);
                    }
                }
            }
        }
    }
}
