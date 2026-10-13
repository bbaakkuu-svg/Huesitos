// AntigravityIntegration.cs
// Auto‑generated integration helper for Antigravity CLI inside Unity Editor
// Provides menu items to run Antigravity commands (e.g., asset sync, script generation)

using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public static class AntigravityIntegration
{
    private const string AntigravityExe = "agy"; // Assumes `agy` is on the system PATH

    // Path to the Antigravity project root (relative to Unity project)
    private static string AntigravityRoot => Path.GetFullPath(Path.Combine(Application.dataPath, "..", ".."));

    [MenuItem("Antigravity/Run CLI Command...")]
    private static void RunCliCommand()
    {
        string command = EditorUtility.DisplayDialogComplex("Antigravity CLI", "Enter the Antigravity CLI command you wish to run (without the leading 'agy').", "Run", "Cancel", "Copy to Clipboard");
        // For simplicity we use a hard‑coded example; real implementation would open a prompt window.
        // Here we just run a demo sync command.
        RunAntigravity("sync assets");
    }

    [MenuItem("Antigravity/Sync Assets")]
    private static void SyncAssets()
    {
        RunAntigravity("sync assets");
    }

    [MenuItem("Antigravity/Generate Scripts")]
    private static void GenerateScripts()
    {
        RunAntigravity("generate scripts --target UnityIntegration");
    }

    private static void RunAntigravity(string arguments)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = AntigravityExe,
            Arguments = arguments,
            WorkingDirectory = AntigravityRoot,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };
        try
        {
            using var proc = Process.Start(startInfo);
            string stdout = proc.StandardOutput.ReadToEnd();
            string stderr = proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            if (proc.ExitCode == 0)
            {
                EditorUtility.DisplayDialog("Antigravity", $"Command succeeded:\n{stdout}", "OK");
            }
            else
            {
                EditorUtility.DisplayDialog("Antigravity – Error", $"Command failed (exit {proc.ExitCode}):\n{stderr}", "OK");
            }
        }
        catch (System.Exception ex)
        {
            EditorUtility.DisplayDialog("Antigravity – Exception", ex.Message, "OK");
        }
    }
}
