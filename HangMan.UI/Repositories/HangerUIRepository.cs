using HangMan.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.UI.Repositories
{
    public class HangerUIRepository : IHangerUIRepository
    {
        private delegate void PictureDelegate();
        public void DisplayPicture(int incorrectGuessCount)
        {

            Dictionary<int, Lazy<PictureDelegate>> strategy = new Dictionary<int, Lazy<PictureDelegate>>
            {
                {0,  new Lazy<PictureDelegate>(() =>  IsvestiPradini)},
                {1,  new Lazy<PictureDelegate>(() =>  IsvestiGalva)},
                {2,  new Lazy<PictureDelegate>(() =>  IsvestiKaklas)},
                {3,  new Lazy<PictureDelegate>(() =>  IsvestiKunas)},
                {4,  new Lazy<PictureDelegate>(() =>  IsvestiRanka1)},
                {5,  new Lazy<PictureDelegate>(() =>  IsvestiRanka2)},
                {6,  new Lazy<PictureDelegate>(() =>  IsvestiKoja1)},
                {7,  new Lazy<PictureDelegate>(() =>  IsvestiKoja2)},
            };

            strategy[incorrectGuessCount].Value.Invoke();

        }

        private void IsvestiPradini()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        void IsvestiGalva()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        private void IsvestiKaklas()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|              |   ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        private void IsvestiKunas()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|              |   ");
            Console.WriteLine(@"|              0   ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        private void IsvestiRanka1()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|             \|   ");
            Console.WriteLine(@"|              0   ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        private void IsvestiRanka2()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|             \|/  ");
            Console.WriteLine(@"|              0   ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        private void IsvestiKoja1()
        {
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|             \|/  ");
            Console.WriteLine(@"|              0   ");
            Console.WriteLine(@"|             /    ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");
        }
        private void IsvestiKoja2()
        {
            Console.Clear();
            Console.WriteLine(@"   - - - - - - |   ");
            Console.WriteLine(@"|              o   ");
            Console.WriteLine(@"|             \|/  ");
            Console.WriteLine(@"|              0   ");
            Console.WriteLine(@"|             / \  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"|                  ");
            Console.WriteLine(@"_ _ _ _");

        }
    }
}
