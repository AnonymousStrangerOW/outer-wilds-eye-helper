﻿using OWML.Common;
using OWML.ModHelper;

namespace EyeHelper
{
    public class EyeHelper : ModBehaviour
    {
        public override void SetupPauseMenu(IPauseMenuManager pauseMenu)
        {
            base.SetupPauseMenu(pauseMenu);

            if (LoadManager.GetCurrentScene() == OWScene.EyeOfTheUniverse)
            {
                var solarSystemButton = pauseMenu.MakeSimpleButton("RETURN TO OUTER WILDS", 3, true);
                solarSystemButton.OnSubmitAction += () =>
                {
                    Locator.GetSceneMenuManager().pauseMenu.OnSkipToNextTimeLoop();
                    PlayerData._currentGameSave.warpedToTheEye = false;
                    LoadManager.LoadSceneAsync(OWScene.SolarSystem, true, LoadManager.FadeType.ToBlack);
                };
            }
            if (LoadManager.GetCurrentScene() == OWScene.SolarSystem)
            {
                var solarSystemButton = pauseMenu.MakeSimpleButton("GO TO THE EYE", 3, true);
                solarSystemButton.OnSubmitAction += () =>
                {
                    Locator.GetSceneMenuManager().pauseMenu.OnSkipToNextTimeLoop();
                    PlayerData._currentGameSave.warpedToTheEye = true;
                    LoadManager.LoadSceneAsync(OWScene.EyeOfTheUniverse, true, LoadManager.FadeType.ToBlack);
                };
            }
        }
    }
}