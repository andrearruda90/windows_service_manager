using System.ServiceProcess;

ServiceController[] scServices;
scServices = ServiceController.GetServices();

// Display the list of services currently running on this computer.

Console.WriteLine("Services running on the local computer:");
foreach (ServiceController scTemp in ServiceController.GetServices())
{
    //if (scTemp.Status == ServiceControllerStatus.Running)
    //{
    //    // Write the service name and the display name
    //    // for each running service.
    //    Console.WriteLine();
    //    Console.WriteLine("  Service :        {0}", scTemp.ServiceName);
    //    Console.WriteLine("    Display name:    {0}", scTemp.DisplayName);
    //}
   
    Console.WriteLine(scTemp.ServiceName);
    //scTemp.Start();
    //scTemp.Stop();
}


//starting a single service
 static void StartWindowsService()
{
    string serviceName = "aspnet_state";
    ServiceController serviceController = new ServiceController(serviceName);
    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
    serviceController.Start();
    serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
}

//stopping a single service
 static void StopWindowsService()
{
    string serviceName = "aspnet_state";
    ServiceController serviceController = new ServiceController(serviceName);
    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
    serviceController.Stop();
    serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
}

//restarting a service
 static void RestartWindowsService()
{
    string serviceName = "aspnet_state";
    ServiceController serviceController = new ServiceController(serviceName);
    int tickCount1 = Environment.TickCount;
    int tickCount2 = Environment.TickCount;
    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
    serviceController.Stop();
    serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

    timeout = TimeSpan.FromMilliseconds(1000 - (tickCount1 - tickCount2));
    serviceController.Start();
    serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
}

//more information:
//http://www.tutorialspanel.com/how-to-start-stop-and-restart-windows-services-using-csharp/index.htm