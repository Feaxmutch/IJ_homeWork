using System;
namespace IJ_homeWork_queueInHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int doctorWorkTimeInMinutes = 10;
            int minutesInHours = 60;
            Console.WriteLine("Сколько бабушек сейчас в очереди?");
            int peoplesInQueue = Convert.ToInt32(Console.ReadLine());
            int waitingTimeInHours = peoplesInQueue * doctorWorkTimeInMinutes / minutesInHours;
            int waitingTimeInMinutes = peoplesInQueue * doctorWorkTimeInMinutes % minutesInHours;
            Console.WriteLine($"В таком случае вам предстоит ждать {waitingTimeInHours} час(а/ов) и {waitingTimeInMinutes} минут");
            Console.ReadKey();
        }
    }
}
