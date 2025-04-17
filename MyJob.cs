namespace HangfireJobApp
{
    public class MyJob
    {
        public void Execute()
        {
            Console.WriteLine("⏰ 1. Hangfire job çalıştı: " + DateTime.Now);
        }
    }
}
