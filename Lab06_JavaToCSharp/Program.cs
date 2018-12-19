using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_JavaToCSharp
{
    class Program
    {   // DriverTest
        static void Main(string[] args)
        {
            // Constant for the number of answers.
            const int NUM_ANSWERS = 20;

            // Array to hold the student's answers.
            char[] answers = new char[NUM_ANSWERS];

            // This will reference an array holding the
            // question numbers of the missed questions.
            int[] missedQuestions = null;

            // Get the user's answers to the questions.
            Console.WriteLine("Enter your answers to the " +
                         "exam questions. (Make sure " +
                         "Caps Lock is ON!)");

            for(int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine("Question " + (i + 1) + ": ");
                string input = Console.ReadLine();
                
                if(char.TryParse(input, out char inserted))
                {
                    answers[i] = inserted;

                    // Validate the answer.
                    while (!Valid(answers[i]))
                    {
                        Console.WriteLine("ERROR: Valid answers are A, B, C, or D.");
                        Console.Write("Question " + (i + 1) + ": ");
                        input = Console.ReadLine();
                        if(char.TryParse(input, out char userChar))
                        {
                            answers[i] = userChar;
                        }
                    }
                }
            }

            // Create a DriverExam object.
            DriverExam exam = new DriverExam(answers);

            // Get an array of the missed question numbers.
            missedQuestions = exam.QuestionsMissed();

            // Display a report.
            Console.WriteLine("Correct answers: " + exam.TotalCorrect());
            Console.WriteLine("Incorrect answers: " + exam.TotalIncorrect());

            // Display whether the student passed or failed.
            if (exam.Passed())
                Console.WriteLine("You passed the exam!");
            else
                Console.WriteLine("You failed the exam.");

            if(missedQuestions != null)
            {
                Console.WriteLine("You missed the following questions: ");
                for(int i = 0; i < missedQuestions.Length; i++)
                {
                    Console.Write(missedQuestions[i] + " ");
                }                
            }

            Console.ReadKey();
        }


        /*
         * Valid method
         * Returns true if argument is A, B,C, or D.
         */
        public static bool Valid(char c)
        {
            bool status = false;

            if (c == 'A' || c == 'B' || c == 'C' || c == 'D')
            {
                status = true;
            }
            else
                status = false;

            return status;
        }
    }
}
