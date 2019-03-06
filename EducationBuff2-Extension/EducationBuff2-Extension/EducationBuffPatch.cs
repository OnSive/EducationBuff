using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EducationBuff2_Extension
{
    [HarmonyPatch(typeof(EducationWindow))]
    [HarmonyPatch("SendEmployee")]
    public class EducationBuffPatch
    {
        // Until I figure out a way to avoid completely overriding the method, I will have to replace it by ending execution with Prefix
        // Yes I'm still getting used to C# and Harmony
        static bool Prefix(EducationWindow __instance, Actor emp, int months, Employee.EmployeeRole role, string spec, bool hr = false)
        {
            SDateTime time = SDateTime.Now() + new SDateTime(1, months, 0);
            time = new SDateTime(0, emp.SpawnTime, time.Day, time.Month, time.Year);
            if (__instance.HRToggle.isOn && !hr)
            {
                emp.HREd = true;
            }
            else
            {
                // Begin replacement
                emp.CoursePoints = emp.employee.GetEducationFactor(role) * (months / 6f);
                Debug.Log("EducationBuff: Harmony confirmed operational");
                // End replacement
                emp.CourseRole = role;
                emp.CourseSpec = spec;
            }
            if (emp.SpecialState == Actor.HomeState.Vacation)
                time += new SDateTime(0, 1, 0);
            emp.LastCourse = SDateTime.Now();
            emp.IgnoreOffSalary = emp.SpecialState != Actor.HomeState.Vacation;
            GameSettings.Instance.sActorManager.AddToAwaiting(emp, time, true, true);

            // This method replaces EducationWindow.SendEmployee() in the game. This is unfortunately intentional.
            return false;
        }
    }
}
