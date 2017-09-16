using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Parcial2.Game
{
    public class DisparoInput : MonoBehaviour
    {
        [SerializeField]
        private int tiempoEntreDisparoEspecial;

        private bool noDisparo = false;

        [SerializeField]
        private Button otherButton;
        private Button myButton;

        public delegate void Disparos();
        public static event Disparos EnDisparoNormal;
        public static event Disparos EnDisparoEspecial;

        public void Start()
        {
            Bullet.EnDesaparecer += Rehabilitar;
        }

        public void Disparar()
        {
            if (myButton == null)
            {
                myButton = this.gameObject.GetComponent<Button>();
            }

            EnDisparoNormal();
            otherButton.interactable = false;
            myButton.interactable = false;

        }

        public void DispararEspecial()
        {
            if (myButton == null)
            {
                myButton = this.gameObject.GetComponent<Button>();
            }

            EnDisparoEspecial();
            otherButton.interactable = false;
            noDisparo = true;
            Invoke("EsperarDisparo", tiempoEntreDisparoEspecial);
        }

        private void EsperarDisparo()
        {
            noDisparo = false;
            otherButton.interactable = true;
        }

        private void Rehabilitar()
        {
            myButton.interactable = true;
            if (!noDisparo)
            {
                otherButton.interactable = true;
            }
        }

        private void OnDestroy()
        {
            Bullet.EnDesaparecer -= Rehabilitar;
        }

    }
}
