using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace FiveMESXTest
{
    public class Main : BaseScript
    {
        dynamic ESX;

        public Main()
        {
            TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => {
            ESX = esx;
        })});

            API.RegisterCommand("TestESX", new Action<int, List<object>, string>((source, args, raw) =>
            {
                // Getting xPlayer Using ESX APi
                var xPlayer = ESX.GetPlayerFromId(source);
                var Job = xPlayer.getJob();
                xPlayer.triggerEvent("chat:addMessage", new
                {
                    color = new[] { 255, 0, 0 },
                    args = new[] { "[JobInfo]", $"Your Job is {Job.name}. Your Grade Is {Job.grade_name}. Your Salary is {Job.grade_salary}" }
                });
            }), false);
        }
    }
}
//This is server sided, please refer to the ESX documentation on functions to use: https://esx-framework.github.io/
