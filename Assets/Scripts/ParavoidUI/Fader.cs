using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ParavoidUI
{
    public class Fader : MonoBehaviour
    {
        //private Image screen;
        private bool isFaded;
        public Button returnToMenu_button;
        public Button back;

        public KeyCode toggleMenuPanelKey = KeyCode.Escape;

        public void Awake()
        {
            //screen = GetComponent<Image>();
            UnFadeScreen();
            returnToMenu_button.onClick.AddListener(delegate
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 1;
                SceneLoader.LoadScene("TitleScene");
            });

            back.onClick.AddListener(delegate
            {
                ToggleMenuPanel();
            });
        }

        public void Update()
        {
            UpdateGeneralInput();
        }

        public void UpdateGeneralInput()
        {
            if (Input.GetKeyDown(toggleMenuPanelKey))
            {
                ToggleMenuPanel();
            }
        }

        public void ToggleMenuPanel()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "MenuPanelV2")
                {
                    if (child.gameObject.activeInHierarchy)
                    {
                        Debug.Log("Deactive: " + child.gameObject.name);
                        child.gameObject.SetActive(false);
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = false;
                        Time.timeScale = 1;
                    }
                    else
                    {
                        Debug.Log("Active: " + child.gameObject.name);
                        child.gameObject.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        Time.timeScale = 0;
                    }

                    break;
                }
            }
        }

        public void FadeScreenTo(float fade)
        {
            //screen.CrossFadeAlpha(fade, 2.0f, true);
        }

        public void FadeScreenTo(float fade, float duration)
        {
            //screen.CrossFadeAlpha(fade, duration, true);
        }

        public void UnFadeScreen()
        {
            FadeScreenTo(0);
        }

        public void ToggleFade()
        {
            if (!isFaded)
            {
                isFaded = false;
                UnFadeScreen();
            }
            else
                FadeScreenTo(0.4f);
        }
    }
}

