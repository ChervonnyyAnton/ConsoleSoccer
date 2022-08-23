namespace ConsoleSoccer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MatchGenerator match;
            bool status = true;

            void Say(string text)
            {
                Console.WriteLine(text);
            }


            while (status)
            {
                match = new MatchGenerator();
                match.CreateTeams()
                    .Start()
                    .IntroduceTeams()
                    .FlipTheCoin()
                    .Move()
                    .Game();

                Console.WriteLine("Do you want to play again? (Y or N)");

                string answer = Console.ReadLine().ToUpper();

                while(!answer.Equals("Y") && !answer.Equals("N"))
                {
                    Console.WriteLine("You entered unacceptable letter");
                    Console.WriteLine("Type Y or N to answer Yes or No, please");

                    answer = Console.ReadLine().ToUpper();
                }

                switch (answer)
                {
                    case "Y":
                        status = true;
                        break;
                    case "N":
                        status = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}