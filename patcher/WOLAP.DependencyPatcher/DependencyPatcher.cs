using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using Mono.Cecil;
using BepInEx.Logging;

namespace WOLAP.DependencyPatcher
{
    public static class DependencyPatcher
    {
        private static ManualLogSource patcherLog; //Creates a log source for the DependencyPatcher class
        public static void Initialize() //This method is called when the DependencyPatcher class is initialized
            {
                patcherLog = BepInEx.Logging.Logger.CreateLogSource("DependencyPatcher"); //Creates a log source for the DependencyPatcher class
                patcherLog.LogInfo("Dependency Patcher Initialized."); //Logs that the DependencyPatcher class has been initialized
                patcherLog.LogInfo("START OF PATCH FILE VIEW TEST"); //Logs that the DependencyPatcher class has been initialized

                var a = AppDomain.CurrentDomain.GetAssemblies(); //Gets all the assemblies currently loaded in the AppDomain
                var result = a.FirstOrDefault(asm => asm.GetName().Name == "Newtonsoft.Json"); //Checks if the Newtonsoft.Json assembly is loaded in the AppDomain
                if (result != null) //If the assembly is found
                {
                    patcherLog.LogInfo("Newtonsoft.Json assembly found."); //Logs that the Newtonsoft.Json assembly is found
                }
                else //If the assembly is not found
                {
                    patcherLog.LogWarning("Newtonsoft.Json assembly not found."); //Logs that the Newtonsoft.Json assembly is not found
                }
            }
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Newtonsoft.Json.dll" }; //Tells BepInEx which game assembly this patcher should process
        public static void Patch(AssemblyDefinition newtonsoftAssembly) //Called by BepInEx when it processes the targeted assembly.
                                                                        //newtonsoftAssembly is the Mono.Cecil representation of that assembly.
        {
            patcherLog.LogInfo($"Found {newtonsoftAssembly.Name.Name} assembly with version {newtonsoftAssembly.Name.Version}."); //Logs the name and version of the assembly that was found

            var a = AppDomain.CurrentDomain.GetAssemblies(); 
                var result = a.FirstOrDefault(asm => asm.GetName().Name == "Newtonsoft.Json"); 
                if (result != null)
                {
                    patcherLog.LogInfo("Newtonsoft.Json assembly found.");
                }
                else
                {
                    patcherLog.LogWarning("Newtonsoft.Json assembly not found.");
                }
        }   
        public static void Finish() //This method is called when the DependencyPatcher class is finished and it logs that the DependencyPatcher class has finished
            {
                List<string> modNeeds = new List<string>
            {
                "MonoMod.Backports",
                "MonoMod.ILHelpers",
                "Newtonsoft.Json",
                "Archipelago.MultiClient.Net",
                "WOLAP"
            }; //this creates a list of the files im looking for

            var asmFind = AppDomain.CurrentDomain.GetAssemblies();
            var foundAssemblies = asmFind.Where(
                asm => modNeeds.Contains(asm.GetName().Name)
            );

            foreach (var a in modNeeds)
            {
                var found = foundAssemblies.FirstOrDefault(asm => asm.GetName().Name == a);

                if (found != null)
                {
                    patcherLog.LogInfo($"Assembly {a} found at {found.Location} and is version {found.GetName().Version}");
                }
                else
                {
                    patcherLog.LogWarning($"{a} not found at this stage");
                }
            }

                patcherLog.LogInfo("END OF PATCH FILE VIEW TEST"); //Logs that the DependencyPatcher class has finished
            }
    }
}