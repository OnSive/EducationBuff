using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;

namespace EducationBuff2_Extension
{
    [HarmonyPatch(typeof(EducationWindow))]
    [HarmonyPatch("SendEmployee")]
    public class EducationBuffPatch
    {
        // No longer necessary, will remain here but commented out (rather than deleted) in case I need to release an emergency stopgap update
        //static bool Prefix(EducationWindow __instance, Actor emp, int months, Employee.EmployeeRole role, string spec, bool hr = false)
        //{
        //    SDateTime time = SDateTime.Now() + new SDateTime(1, months, 0);
        //    time = new SDateTime(0, emp.SpawnTime, time.Day, time.Month, time.Year);
        //    if (__instance.HRToggle.isOn && !hr)
        //    {
        //        emp.HREd = true;
        //    }
        //    else
        //    {
        //        // Begin replacement
        //        emp.CoursePoints = emp.employee.GetEducationFactor(role) * (months / EducationBuffExtension.MonthsToMaxOut);
        //        Debug.Log("EducationBuff: Harmony confirmed operational, training: " + months + " out of " + EducationBuffExtension.MonthsToMaxOut + " months");
        //        // End replacement
        //        emp.CourseRole = role;
        //        emp.CourseSpec = spec;
        //    }
        //    if (emp.SpecialState == Actor.HomeState.Vacation)
        //        time += new SDateTime(0, 1, 0);
        //    emp.LastCourse = SDateTime.Now();
        //    emp.IgnoreOffSalary = emp.SpecialState != Actor.HomeState.Vacation;
        //    GameSettings.Instance.sActorManager.AddToAwaiting(emp, time, true, true);

        //    // This method replaces EducationWindow.SendEmployee() in the game. This is unfortunately intentional.
        //    return false;
        //}

        // Yay finally learned to use a transpiler to replace the one IL code that corresponds to a hardcoded value (16!)
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            // Source code decompile indicates that the value to replace is in the 36th IL code for the method. So index is 35 in this case.
            codes[35].opcode = OpCodes.Call;
            codes[35].operand = typeof(EducationBuffExtension).GetProperty("MonthsToMaxOut").GetGetMethod();
            Debug.Log("Harmony transpiler completed, IL_0068 (index 35): " + codes[35].opcode + " " + codes[35].operand);
            return codes.AsEnumerable();
        }
    }
}
