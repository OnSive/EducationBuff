using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EducationBuff2_Extension
{
    class EducationBuffExtension
    {
        static HarmonyInstance harmony;

        public static void Start()
        {
            Debug.Log("EducationBuff: Starting Harmony patching");
            harmony = HarmonyInstance.Create("d225.buffs.education");
            harmony.PatchAll();
        }

        public static void Stop()
        {
            harmony.UnpatchAll();
            harmony = null;
            Debug.Log("EducationBuff: Goodbye Harmony... for now");
        }
    }
}
