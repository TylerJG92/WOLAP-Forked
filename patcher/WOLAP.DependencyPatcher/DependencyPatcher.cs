using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using Mono.Cecil;
using BepInEx.Logging;
using System.IO;

namespace WOLAP.DependencyPatcher
{
    public static class DependencyPatcher
    {
        private static ManualLogSource patcherLog; //Creates a log source for the DependencyPatcher class
        private static string patcherFolder = Paths.PatcherPluginPath;
        private static string replacementPath = Path.Combine(patcherFolder, "WOLAP.Newtonsoft.Json.V11.dll");
        
        public static void Initialize() //This method is called when the DependencyPatcher class is initialized
            {
                patcherLog = BepInEx.Logging.Logger.CreateLogSource("DependencyPatcher"); //Creates a log source for the DependencyPatcher class
                patcherLog.LogInfo("Dependency Patcher Initialized."); //Logs that the DependencyPatcher class has been initialized
                patcherLog.LogInfo("START OF PATCH FILE VIEW TEST"); //Logs that the DependencyPatcher class has been initialized

                var a = AppDomain.CurrentDomain.GetAssemblies(); //Gets all the assemblies currently loaded in the AppDomain
                var result = a.FirstOrDefault(asm => asm.GetName().Name == "Newtonsoft.Json"); //Checks if the Newtonsoft.Json assembly is loaded in the AppDomain
                if (result != null) //If the assembly is found
                {
                    patcherLog.LogInfo("Newtonsoft.Json V9 assembly found."); //Logs that the Newtonsoft.Json V9 assembly is found
                }
                else //If the assembly is not found
                {
                    patcherLog.LogWarning("Newtonsoft.Json V9 assembly not found."); //Logs that the Newtonsoft.Json V9 assembly is not found
                }

                patcherLog.LogInfo($"BepInEx patcher folder is: {patcherFolder}");
                patcherLog.LogInfo($"Looking for replacement at: {replacementPath}");

                if (File.Exists(replacementPath))
                {
                    patcherLog.LogInfo("Replacement Newtonsoft file exists.");
                }
                else
                {
                    patcherLog.LogWarning("Replacement Newtonsoft file does not exist.");
                }
                patcherLog.LogInfo("SEPERATION BETWEEN INITIALIZE AND PATCH");
            }
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Newtonsoft.Json.dll" }; //Tells BepInEx which game assembly this patcher should process

        public static void Patch(ref AssemblyDefinition targetNewton)
            {
                AssemblyDefinition replacementNewton = AssemblyDefinition.ReadAssembly(replacementPath);

                patcherLog.LogInfo($"Target: {targetNewton.Name.Name} v{targetNewton.Name.Version}");
                patcherLog.LogInfo($"Replacement: {replacementNewton.Name.Name} v{replacementNewton.Name.Version}");

                var a = AppDomain.CurrentDomain.GetAssemblies();
                var result = a.Where(asm => asm.GetName().Name == "Newtonsoft.Json");

                patcherLog.LogInfo("Newtonsoft.Json in memory?");

                if (!result.Any())
                {
                    patcherLog.LogWarning("No Newtonsoft.Json assemblies are loaded in memory at this stage.");
                }

                foreach (var asm in result)
                {
                    var name = asm.GetName().Name;
                    var version = asm.GetName().Version;
                    var location = asm.Location;

                    patcherLog.LogInfo($"Assembly {name} found at {location} and is version {version}");
                }
            }  
        public static void Finish() //This method is called when the DependencyPatcher class is finished and it logs that the DependencyPatcher class has finished
            {
                patcherLog.LogInfo("SEPERATION OF PATCHER AND FINISH SECTIONS");
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