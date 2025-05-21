using System;
using System.Timers;

public class Program
{
    private static System.Timers.Timer? _offTimer;
    private static bool _isLightOn = false;

    public static void Main()
    {
        Console.WriteLine("灯光控制系统已启动 (输入 'open' 开门/'close' 关门/'exit' 退出)");
        
        while (true)
        {
            var input = Console.ReadLine()?.ToLower();
            
            switch (input)
            {
                case "open":
                    DoorOpened();
                    break;
                case "close":
                    DoorClosed();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("无效命令");
                    break;
            }
        }
    }

    private static void DoorOpened()
    {
        // 取消现有定时器
        _offTimer?.Stop();
        _offTimer?.Dispose();
        
        if (!_isLightOn)
        {
            _isLightOn = true;
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} → 灯已打开");
        }
    }

    private static void DoorClosed()
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} → 门已关闭，5分钟后关灯...");
        
        _offTimer = new System.Timers.Timer(300000); // 5分钟 = 300,000毫秒
        _offTimer.Elapsed += (s, e) => 
        {
            _isLightOn = false;
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} → 灯已自动关闭");
            _offTimer?.Stop();
        };
        _offTimer.AutoReset = false;
        _offTimer.Start();
    }
}
