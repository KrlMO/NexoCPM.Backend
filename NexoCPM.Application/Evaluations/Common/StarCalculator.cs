namespace NexoCPM.Application.Evaluations.Common
{
    public static class StarCalculator
    {
        public static int CalculateStars(int correctAnswers, int totalQuestions)
        {
            if (totalQuestions <= 0) return 0;

            var percentage = (double)correctAnswers / totalQuestions;

            return percentage switch
            {
                >= 0.95 => 5,
                >= 0.80 => 4,
                >= 0.60 => 3,
                >= 0.40 => 2,
                > 0.0 => 1,
                _ => 0
            };
        }
    }
}
