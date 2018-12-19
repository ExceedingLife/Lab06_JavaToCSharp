using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_JavaToCSharp
{
    // DriverExam class
    class DriverExam
    {
        // Array containing the correct answers
        private char[] correct = { 'B', 'D', 'A', 'A',
                              'C', 'A', 'B', 'A',
                              'C', 'D', 'B', 'C',
                              'D', 'A', 'D', 'C',
                              'C', 'B', 'D', 'A' };
        private char[] student;       // The student's answers
        private int[] missed;         // The missed question numbers
        private int numCorrect = 0;   // The number correct
        private int numIncorrect = 0; // The number incorrect

        /**
         * Constructor
         * Accepts an array of the student's
         * answers as the argument. The contents
         * of the array are copied to the student
         * field.
         */
        public DriverExam(char[] s)
        {
            student = s;
            GradeExam();
        }


        /**
         * GradeExam method
         * This method determines the number of
         * correct and incorrect answers. It calls
         * the makeMissedArray method.
         */
        private void GradeExam()
        {
            /* Missing code starts here */
            for(int i = 0; i < student.Length; i++)
            {
                if (student[i] == correct[i])
                    numCorrect++;
                else
                    numIncorrect++;
            }
            /* Missing code ends here */
            MakeMissedArray();
        }


        /**
         * MakeMissedArray method
         * This method makes the missed array and
         * stores the numbers of all the questions
         * that the student missed in it.
         */
        private void MakeMissedArray()
        {
            /* Missing code starts here */
            missed = new int[numIncorrect];     // Declare array so it isn't 'null'
            int index = 0;                      // Create variable to hold 'index of array'
            for(int i = 0; i < student.Length; i++)
            {
                if(student[i] != correct[i])
                {
                    missed[index] = i + 1;
                    index++;
                }
            }
            /* Missing code ends here */
        }


        /*
         * Passed method - looks at answers.
         */
         public bool Passed()
        {
            bool status = false;
            if (numCorrect >= 15)
                status = true;
            else
                status = false;

            return status;
        }


        /*
         * TotalCorrect method.
         */
         public int TotalCorrect()
        {
            return numCorrect;
        }


        /*
         * TotalIncorrect method.
         */
         public int TotalIncorrect()
        {
            return numIncorrect;
        }


        /**
         * questionsMissed method
         * Returns an array containing the numbers
         * of the missed questions. If no questions
         * were missed, returns null.
         */
         public int[] QuestionsMissed()
        {
            return missed;
        }
    }
}
