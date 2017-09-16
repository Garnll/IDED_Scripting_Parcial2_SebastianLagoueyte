//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parcial2.Game
{
    public abstract class EnemyFactory : MonoBehaviour
    {
        [SerializeField]
        protected int tipoDeFactory;
        [SerializeField]
        protected Enemy enemigoBase;
        [SerializeField]
        protected int tiempoEntreEnemigo;

        private static bool crear = true;

        private int AtkVariante;
        private int HPVariante;

        public void Llamar(int aQuien)
        {
            if (tipoDeFactory == aQuien)
            {
                InvokeRepeating("CrearEnemigo", tiempoEntreEnemigo, tiempoEntreEnemigo);
            }
        }


        private void CrearEnemigo()
        {
            if (crear)
            {
                Enemy enemigoCopia = Instantiate(enemigoBase, this.transform);
                OlasController.SumarEnemigos(1);
                VariarPropiedades();
                enemigoCopia.SetParameters(AtkVariante, HPVariante);
            }
        }

        private void VariarPropiedades()
        {
            AtkVariante = Random.Range(0, 10);
            HPVariante = Random.Range(0, 50);
        }

        public static void SetCreacion(bool creacion)
        {
            crear = creacion;
        }
    }
}
