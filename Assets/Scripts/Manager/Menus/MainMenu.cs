using LevelManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        public void OnPlayPressed()
        {
            if(GameManager.Instance != null) 
            {
            
            }

            //GameMenu.Open();
        }

        public void OnSettingsPressed()
        {
            SettingsMenu.Open();
        }

        public void OnCreditPressed()
        {
            CreditMenu.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }

    }
}