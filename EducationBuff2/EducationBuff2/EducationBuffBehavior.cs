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
        private static EducationBuffBehavior _instance;
        
        public static float MonthsToMaxOut
        {
            get
            {
                return _instance.LoadSetting<float>("MonthsToMaxOut", 6);
            }
            set
            {
                _instance.SaveSetting("MonthsToMaxOut", value.ToString());
            }
        }

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

        private void Start()
        {
            _instance = this;
        }

        private void Update()
        {
            extension.GetType("EducationBuff2_Extension.EducationBuffExtension").GetMethod("Update").Invoke(null, new object[] { MonthsToMaxOut });
        }
    }
}
