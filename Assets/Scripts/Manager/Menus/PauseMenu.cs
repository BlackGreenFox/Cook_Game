using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        public void OnResumePressed()
        {
            Time.timeScale = 1.0f;
            base.OnBackPressed();
        }


    }
}