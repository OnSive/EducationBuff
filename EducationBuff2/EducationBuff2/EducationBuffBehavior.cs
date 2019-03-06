using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EducationBuff2
{
    class EducationBuffBehavior : ModBehaviour
    {
        Assembly harmony, extension;

        public override void OnActivate()
        {
            harmony = Assembly.LoadFile("./DLLMods/0Harmony.dll");
            extension = Assembly.LoadFile("./DLLMods/EducationBuff2-Extension.dll");
            extension.GetType("EducationBuff2_Extension.EducationBuffExtension").GetMethod("Start").Invoke(null, null);
        }

        public override void OnDeactivate()
        {
            extension.GetType("EducationBuff2_Extension.EducationBuffExtension").GetMethod("Stop").Invoke(null, null);
        }
    }
}
