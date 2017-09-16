using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parcial2.Game
{
    public class BulletPoolManager : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletBase;
        [SerializeField]
        private Bullet specialBulletBase;

        private List<Bullet> bullets = new List<Bullet>(5);
        private List<Bullet> specialBullets = new List<Bullet>(5);

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < bullets.Capacity; i++)
            {
                bullets.Add(Instantiate(bulletBase, new Vector3(-1000, -1000, -1000), transform.rotation));
                specialBullets.Add(Instantiate(specialBulletBase, new Vector3(-1000, -1000, -1000), transform.rotation));
            }
        }

        public Bullet CogerBalaNormal()
        {
            Bullet balaACoger;
            balaACoger = bullets[0];

            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].gameObject.activeInHierarchy)
                {
                    balaACoger = bullets[i];
                }
                else
                {
                    balaACoger = null;
                }
            }

            return balaACoger;
        }


        public Bullet CogerBalaEspecial()
        {
            Bullet balaACoger;
            balaACoger = specialBullets[0];

            for (int i = 0; i < specialBullets.Count; i++)
            {
                if (specialBullets[i].gameObject.activeInHierarchy)
                {
                    balaACoger = specialBullets[i];
                }
                else
                {
                    balaACoger = null;
                }
            }

            return balaACoger;
        }
    }
}
