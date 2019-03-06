using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
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
                         "for mods that add a lot of specialization fields.\n\n";

            WindowManager.AddElementToElement(label.gameObject, parent.gameObject, new Rect(0, 0, label.preferredWidth, label.preferredHeight),
                new Rect(0, 0, 0, 0));

            Text text = WindowManager.SpawnLabel();
            text.text = "Enter the desired number of months required to max out a skill (up to 4 characters including dots):";
            WindowManager.AddElementToElement(text.gameObject, parent.gameObject, new Rect(0, label.preferredHeight, text.preferredWidth, text.preferredHeight), new Rect(0, 0, 0, 0));

            InputField input = WindowManager.SpawnInputbox();
            input.lineType = InputField.LineType.SingleLine;
            input.characterValidation = InputField.CharacterValidation.Decimal;
            input.characterLimit = 4;
            input.text = EducationBuffBehavior.MonthsToMaxOut.ToString();
            input.onEndEdit.AddListener(newValue =>
            {
                if (!float.TryParse(newValue, out float result))
                    return;
                EducationBuffBehavior.MonthsToMaxOut = result;
            });
            WindowManager.AddElementToElement(input.gameObject, parent.gameObject, new Rect(0, text.preferredHeight + label.preferredHeight, 100, 28), new Rect(0, 0, 0, 0));
        }
    }
}
