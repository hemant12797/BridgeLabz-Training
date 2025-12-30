using System;

class EduQuiz
{
    static void Main()
    {
        // Correct answers
        string[] correctAnswers =
        {
            "A", "B", "C", "D", "A",
            "C", "B", "D", "A", "B"
        };

        // Student answers
        string[] studentAnswers =
        {
            "a", "B", "c", "A", "A",
            "c", "b", "D", "C", "b"
        };

        int score = CalculateScore(correctAnswers, studentAnswers);

        Console.WriteLine("\nTotal Score: " + score + " / " + correctAnswers.Length);

        double percentage = (score * 100.0) / correctAnswers.Length;
        Console.WriteLine("Percentage: " + percentage + "%");

        if (percentage >= 50)
            Console.WriteLine("Result: PASS 🎉");
        else
            Console.WriteLine("Result: FAIL ❌");
    }

    // Method to calculate score and print feedback
    static int CalculateScore(string[] correct, string[] student)
    {
        int score = 0;

        Console.WriteLine("Quiz Feedback:\n");

        for (int i = 0; i < correct.Length; i++)
        {
            if (string.Equals(correct[i], student[i], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Question {i + 1}: Correct ✔");
                score++;
            }
            else
            {
                Console.WriteLine($"Question {i + 1}: Incorrect ✖");
            }
        }

        return score;
    }
}
