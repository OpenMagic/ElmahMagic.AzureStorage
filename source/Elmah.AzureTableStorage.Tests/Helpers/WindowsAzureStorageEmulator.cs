namespace Elmah.AzureTableStorage.Tests.Helpers
{
    internal class WindowsAzureStorageEmulator
    {
        private static readonly WindowsAzureStorageEmulatorProcess Instance = new WindowsAzureStorageEmulatorProcess();

        internal static void StartIfNotRunning()
        {
            Instance.StartIfNotRunning();
        }
    }
}