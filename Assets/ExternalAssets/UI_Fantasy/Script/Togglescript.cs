using UnityEngine;
using UnityEngine.UI;

namespace ExternalAssets.UI_Fantasy.Script
{
    public class Togglescript : MonoBehaviour {

        Toggle toggle;

        private void Start()
        {
            toggle = GetComponent<Toggle>();
        }

        public GameObject Slider;


        private void Update()
        {
            if (toggle.isOn)
            {
                Slider.SetActive(false);
            }
            else
            {
                Slider.SetActive(true);
            }
        }
    }
}