using System.Collections.Generic;

namespace ExamProctor;

public class Exam
{
    public List<Question> Questions { get; set; }
    public Stack<int> NavigationHistory { get; set; } // Stack to track last visited question indices
    public Dictionary<int, string> Answers { get; set; } // questionID -> answer
    public int CurrentQuestionIndex { get; set; }

    public Exam(List<Question> questions)
    {
        Questions = questions;
        NavigationHistory = new Stack<int>();
        Answers = new Dictionary<int, string>();
        CurrentQuestionIndex = 0;
        NavigationHistory.Push(0); // Start with first question
    }

    public void NavigateToQuestion(int index)
    {
        if (index >= 0 && index < Questions.Count)
        {
            CurrentQuestionIndex = index;
            NavigationHistory.Push(index);
        }
    }

    public void GoBack()
    {
        if (NavigationHistory.Count > 1)
        {
            NavigationHistory.Pop(); // Remove current
            CurrentQuestionIndex = NavigationHistory.Peek(); // Go to previous
        }
        else
        {
            Console.WriteLine("Cannot go back further.");
        }
    }

    public void SubmitAnswer(int questionId, string answer)
    {
        Answers[questionId] = answer;
    }

    public int CalculateScore()
    {
        int score = 0;
        foreach (var question in Questions)
        {
            if (Answers.ContainsKey(question.Id) && Answers[question.Id] == question.CorrectAnswer)
            {
                score++;
            }
        }
        return score;
    }
}
