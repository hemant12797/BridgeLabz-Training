using ExamProctor;

class Program
{
    static void Main(string[] args)
    {
        // Sample questions
        var questions = new List<Question>
        {
            new Question(1, "What is 2 + 2?", new List<string> { "3", "4", "5", "6" }, "4"),
            new Question(2, "What is the capital of France?", new List<string> { "London", "Berlin", "Paris", "Madrid" }, "Paris"),
            new Question(3, "What is 5 * 6?", new List<string> { "30", "35", "40", "45" }, "30")
        };

        var exam = new Exam(questions);

        Console.WriteLine("Welcome to ExamProctor - Online Exam Review System");
        Console.WriteLine("Navigate through questions. Type 'next' to go to next question, 'back' to go back, 'submit' to submit exam.");

        bool examInProgress = true;
        while (examInProgress)
        {
            var currentQuestion = exam.Questions[exam.CurrentQuestionIndex];
            Console.WriteLine($"\nQuestion {currentQuestion.Id}: {currentQuestion.Text}");
            for (int i = 0; i < currentQuestion.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentQuestion.Options[i]}");
            }

            Console.Write("Your answer (number or text): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "next")
            {
                if (exam.CurrentQuestionIndex < exam.Questions.Count - 1)
                {
                    exam.NavigateToQuestion(exam.CurrentQuestionIndex + 1);
                }
                else
                {
                    Console.WriteLine("You are at the last question.");
                }
            }
            else if (input.ToLower() == "back")
            {
                exam.GoBack();
            }
            else if (input.ToLower() == "submit")
            {
                examInProgress = false;
            }
            else
            {
                // Assume input is the answer
                exam.SubmitAnswer(currentQuestion.Id, input);
                if (exam.CurrentQuestionIndex < exam.Questions.Count - 1)
                {
                    exam.NavigateToQuestion(exam.CurrentQuestionIndex + 1);
                }
                else
                {
                    Console.WriteLine("You have answered all questions. Type 'submit' to finish.");
                }
            }
        }

        int score = exam.CalculateScore();
        Console.WriteLine($"\nExam submitted. Your score: {score}/{exam.Questions.Count}");
    }
}
