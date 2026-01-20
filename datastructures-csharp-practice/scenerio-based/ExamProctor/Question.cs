namespace ExamProctor;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public string CorrectAnswer { get; set; }

    public Question(int id, string text, List<string> options, string correctAnswer)
    {
        Id = id;
        Text = text;
        Options = options;
        CorrectAnswer = correctAnswer;
    }
}
