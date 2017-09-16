using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parcial2.Game
{
    public class OlasController : MonoBehaviour
    {
        private static int numDeEnemigos;

        [SerializeField]
        private int tiempoDeEspera;
        [SerializeField]
        private int limiteDeOla;

        // Use this for initialization
        void Start()
        {
            numDeEnemigos = 0;
        }

        public static void SumarEnemigos(int sumador)
        {
            numDeEnemigos += sumador;
        }

        // Update is called once per frame
        private void Update()
        {
            if (numDeEnemigos >= limiteDeOla)
            {
                numDeEnemigos = 0;
                EnemyFactory.SetCreacion(false);
                Invoke("VolverASalir", tiempoDeEspera);
            }
        }

        private void VolverASalir()
        {
            EnemyFactory.SetCreacion(true);
        }
    }
}
