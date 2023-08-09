namespace IJ_homeWork_variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName = "здесь где то должно быть Console.readline(), но по правилам я не могу это использовать здесь :)";      //1#
            ushort playerLevel = 1;                                                                                                     //2#
            int playerHealth = 100;                                                                                                     //3#
            float playerDamageResistance = 0.6f;                                                                                        //4#
            short playerWeaponDamage = 12;                                                                                              //5#
            byte enemysOnLocation = 0;                                                                                                  //6# 
            bool onMission = false;                                                                                                     //7#
            char shotButton = 'z';                                                                                                      //8# Сам знаю, что за такую реализацию управления варят в котле, но лучше применение char в контексте игры к сожалению не придумал.¯\_(ツ)_/¯
            uint repairKits = 23;                                                                                                       //9#
            double xPlanetСordinate = 4235345.534532, yPlanetСordinate = 3949.546677;                                                   //10# так как я использовал 1 и тот же тип, будем считать за одну переменную из десяти, а не две. Как же без "Y", когда есть "X"? :)
        }
    }
}
