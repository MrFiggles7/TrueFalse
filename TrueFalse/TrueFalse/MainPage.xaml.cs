using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrueFalse
{
    public partial class MainPage : ContentPage
    {
        protected Dictionary<string, bool> Questions = new Dictionary<string, bool>()
        {
            { "Water is wet" , false},
            { "Birds exist" , false},
            { "The earth is round" , false},
            { "Programming is fun" , true}

        };
        protected int Score = 0;
        protected string CurrentQuestion;
        int i = 0;
        public MainPage()
        {
            InitializeComponent();
            GetQuestion();
        }

        public void Reset(object sender, EventArgs e)
        {
            i = 0;
            Score = 0;
            GetQuestion();
            TrueButton.IsVisible = true;
            FalseButton.IsVisible = true;
            ResetButton.IsVisible = false;
        }

        public void True(object sender, EventArgs e)
        {                
            if (Questions[CurrentQuestion] == true)
            {
                Score++;
                if (isLastQuestion())
                {
                    PerformEndingSequence();
                }
                else
                {
                    GetNextQuestion();

                }
            }
            else
            {
                GetNextQuestion();
            }
            
            
        }

        public void False(object sender, EventArgs e)
        {           
            if (Questions[CurrentQuestion] == false)
            {
                Score++;
                if (isLastQuestion())
                {
                    PerformEndingSequence();
                }
                else
                {
                    GetNextQuestion();

                }
            }
            else
            {
                GetNextQuestion();
            }       
        }

        public void PerformEndingSequence()
        {
            TrueButton.IsVisible = false;
            FalseButton.IsVisible = false;
            Question.Text = "Your Score is: " + Score + "/" + Questions.Count;
            ResetButton.IsVisible = true;
        }

        public bool isLastQuestion()
        {
            if (i >= Questions.Count-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetNextQuestion()
        {
            Increment();
            GetQuestion();
        }


        public void Increment()
        {
            i++;
        }

        public void GetQuestion()
        {
            CurrentQuestion = Questions.ElementAt(i).Key;
            Question.Text = CurrentQuestion;
        }
    }
}
