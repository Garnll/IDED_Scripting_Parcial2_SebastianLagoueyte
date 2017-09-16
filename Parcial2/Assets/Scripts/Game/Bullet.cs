using UnityEngine;

namespace Parcial2.Game
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        public delegate void Desaparecida();
        public static event Desaparecida EnDesaparecer;

        private Rigidbody myRigidBody;
        private float speed;
        protected int damage;

        private GameObject instigator;

        public void SetParams(float bulletSpeed, int bulletDamage, GameObject instanceInstigator)
        {
            instigator = instanceInstigator;
            speed = bulletSpeed;
            damage = bulletDamage;
        }

        public void Toss()
        {
            myRigidBody.AddForce(transform.forward * speed, ForceMode.VelocityChange);

            Invoke("DestroyMe", 1f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player.Instance.gameObject)
            {
                //Collided with player
            }
            else
            {
                Enemy enemy = other.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.ReceiveDamage(damage);
                }
            }

            if (instigator != other.gameObject)
            {
                DestroyMe();
            }
        }

        // Use this for initialization
        private void Awake()
        {
            myRigidBody = GetComponent<Rigidbody>();
        }

        private void DestroyMe()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            EnDesaparecer();
            CambiarParametrosAlDesaparecer();

            myRigidBody = null;
        }

        protected virtual void CambiarParametrosAlDesaparecer()
        {
            //Aqui no va nada
        }
    } 
}