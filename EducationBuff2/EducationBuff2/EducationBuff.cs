using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace EducationBuff2
{
    public class EducationBuff : ModMeta
    {
        public override string Name => "Buffed Education Gains";

        public static bool GiveMeFreedom = true;

        public override void ConstructOptionsScreen(RectTransform parent, bool inGame)
        {
            Text label = WindowManager.SpawnLabel();
            label.text = "Created by Designer225 using Harmony Patch Library by Andreas Pardeike.\n" +
                         "Buffs skill gains from education to make them seem less useless. Useful\n" +
                         "for mods that add a lot of specialization fields.\n\n" +
                         "Due to technical issues with code mod uploads, I will not give permission\n" +
                         "to upload the mod to Steam Workshop. You may not edit my mod without\n" +
                         "permission, either; but you can contribute at GitHub.";

            WindowManager.AddElementToElement(label.gameObject, parent.gameObject, new Rect(0, 0, 400, 128),
                new Rect(0, 0, 0, 0));
        }
    }
}
