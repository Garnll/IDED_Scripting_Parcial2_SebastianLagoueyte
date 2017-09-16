using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parcial2.Game
{
    public class FactoryManager : MonoBehaviour
    {
        [SerializeField]
        EnemyFactory[] factories;

        private int turnoParaCrear;
        private int callate;
        private float tiempo;

        private void Start()
        {
            callate = 0;
            turnoParaCrear = 0;
            tiempo = 0;
        }

        private void Update()
        {
            tiempo += Time.time;

            if (tiempo > 10)
            {
                turnoParaCrear = 3;
            }
            else if (tiempo > 5)
            {
                turnoParaCrear = 2;
            }
            else if (tiempo > 2)
            {
                turnoParaCrear = 1;
            }

            Crear();
            
        }

        private void Crear()
        {
            if (callate == turnoParaCrear)
            {
                factories[turnoParaCrear].Llamar(turnoParaCrear);
                callate++;
            }
        }
    }
}
