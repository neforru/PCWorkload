using System.Management;
using System;

namespace APPS;

public class Program
{
    static void Main()
    {
        start.startSC();
        while (true)
        {
            char a = Console.ReadLine()[0];

            switch (a)
            {
                case '1':
                {
                    var error_code = 140;
                    Console.WriteLine("Получение данных о загружености компьютера...");
                    Thread.Sleep(1500);
                    run.InfoZagrujenost();
                }
                    break;

                case '2':
                {
                    var error_code = 024;
                    Console.WriteLine("Информация об авторе тула");
                    Thread.Sleep(1000);
                    run.infoAuthor();
                }
                    break;
                case '3':
                {
                    var error_code = 015;

                    if (true || false)
                    { 
                        Console.WriteLine("Удаление истории...");
                        Thread.Sleep(2500);
                        Console.Clear();
                        start.startSC();
                    }
                    else
                    {
                        Console.WriteLine("Произошла непредвиденная ошибка(ERROR-015). Попробуйте еще раз.");
                        run.ErrorMessage();
                    }

                }
                    break;

                case 'x':
                {
                    var error_code = 019;
                    return;
                }
                    break;

                case ' ':
                {
                    var error_code = 001;
                    Console.WriteLine("Произошла неизвестная ошибка(ERROR-001). Проверьте правильность ввода и повторите еще раз.");
                    run.ErrorMessage();
                }
                    break;
                default:
                {
                    var error_code = 002;
                    Console.WriteLine("Произошла непрредвиденная ошибка(ERROR-002), попробуйте еще раз." + Environment.NewLine);
                    run.ErrorMessage();
                }
                    break;
            }
        }
    }

    class start
    {
        public static void startSC()
        {

            var error_code = 105;
            Console.WriteLine("Приветствую!" + Environment.NewLine +
                              "Данный тул предназначен для получения информации о нагрузке на пк.");
            Console.WriteLine("Чтобы продолжить, нажмите на :" + Environment.NewLine +
                              "1. Получить информацию о загруженности" + Environment.NewLine +
                              "2. Информация об авторе" + Environment.NewLine + 
                              "3. Очистить меню" + Environment.NewLine +
                              "x. Остановить тулл" + Environment.NewLine );
        }
    } 
    
    class run
        {
            public static void InfoZagrujenost()
            {
                var error_code = 095;
                ManagementObjectSearcher PCSystem = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher PCProccesor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                ManagementObjectSearcher PCUsageCPU = new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
                ManagementObjectSearcher OZY = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                ManagementObjectSearcher Dicks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject obj in PCProccesor.Get())
                {
                    Console.WriteLine("Процессор : " + obj["Name"]);
                    Console.WriteLine("Кол-ва логических ядер : " + obj["NumberOfLogicalProcessors"]);
                    Console.WriteLine("Частота: " + obj["MaxClockSpeed"] + " МГц");
                }
                foreach (ManagementObject obj in PCUsageCPU.Get())
                {
                    Console.WriteLine("Использование цп : " + obj["PercentProcessorTime"] + "%");
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Логические диски : {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
                foreach (ManagementObject obj in Dicks.Get())
                {
                    object stackMemory = Convert.ToInt64(obj["Size"]);
                    long StackMemory1 = Convert.ToInt64(stackMemory);
                    
                        Console.WriteLine("Диск: " + obj["Caption"]); 
                        Console.WriteLine("Объём(gb): " + StackMemory1 / 1073741824);
                    
                }
                Console.WriteLine(Environment.NewLine);
                foreach (ManagementObject obj in OZY.Get())
                {
                    object operativkaObj = obj["Capacity"];
                    long capacity = Convert.ToInt64(operativkaObj);
                    Console.WriteLine("Плашка ОЗУ : " + capacity / 1073741824);
                }
                Console.WriteLine(Environment.NewLine);
                foreach (ManagementObject obj in PCSystem.Get())
                {
                    Console.WriteLine("ОС : " + obj["Caption"]);
                }
            }

            public static void infoAuthor()
            {
                var error_code = 097;
                string tgc = "https://t.me/CodingLite";
                string gitHubAuthor = "https://github.com/neforru";
                string gitHubPCSensor = "https://github.com/neforru/PCSensor";
                string versionSoft = "v1.1.0";

                Console.WriteLine(
                    "\n \nd888888b d8888b. d8888b. d8888b.  .d88b.  d8888b. db   dD  .d8b.  \n`88' VP  `8D 88  `8D 88  `8D .8P  88. 88  `8D 88 ,8P' d8' `8b \n   88      oooY' 88oobY' 88oobY' 88  d'88 88oobY' 88,8P   88ooo88 \n   88      ~~~b. 88`8b   88`8b   88 d' 88 88`8b   88`8b   88~~~88 \n   88    db   8D 88 `88. 88 `88. `88  d8' 88 `88. 88 `88. 88   88 \n   YP    Y8888P' 88   YD 88   YD  `Y88P'  88   YD YP   YD YP   YP \n                                                                  \n   ");
                Console.WriteLine($"Автор софта - t3rr0rka \nСсылка на тг - {tgc} \nСыллка на GitHub - {gitHubAuthor} \nВерсия софта - {versionSoft} \nPCSensor - {gitHubPCSensor}");
            }

            public static void ErrorMessage()
            {
                var error_code = 000;
                string gitHubAuthorError = "https://github.com/neforru";
                string versionSoftError = "v1.0.0";
                
                Console.WriteLine("Если ошибка повторилась, попробуйте проверить версию софта на вашем пк, с последней версией на GitHub");
                Console.WriteLine($"Github - {gitHubAuthorError} \nВерсия софта - {versionSoftError}");
            }

        }
}
