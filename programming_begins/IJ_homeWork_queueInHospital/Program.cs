using System;
namespace IJ_homeWork_queueInHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peoplesInQueue;
            int doctorWorkTimeInMinutes = 10;
            int waitingTimeInHours;
            int waitingTimeInMinutes;
            int minutesInHours = 60;
            Console.WriteLine("Сколько бабушек сейчас в очереди?");
            peoplesInQueue = Convert.ToInt32(Console.ReadLine());
            waitingTimeInHours = peoplesInQueue * doctorWorkTimeInMinutes / minutesInHours;
            waitingTimeInMinutes = peoplesInQueue * doctorWorkTimeInMinutes % minutesInHours;
            Console.WriteLine($"В таком случае вам предстоит ждать {waitingTimeInHours} час(а/ов) и {waitingTimeInMinutes} минут");
            Console.ReadKey();
        }
    }
}
