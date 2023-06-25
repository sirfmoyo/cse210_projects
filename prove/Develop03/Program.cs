using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    namespace ScriptureMemorizer
{
    class Scripture
    {
        private readonly string reference;
        private readonly List<Word> words;

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.words = text.Split(' ').ToList();
        }

        public string GetReference()
        {
            return reference;
        }

        public List<Word> GetWords()
        {
            return words;
        }

        public void HideWord()
        {
            int index = 0;
            while (index < words.Count)
            {
                if (!words[index].IsHidden)
                {
                    words[index].IsHidden = true;
                    break;
                }
                index++;
            }
        }

        public void Display()
        {
            foreach (Word word in words)
            {
                if (word.IsHidden)
                {
                    Console.Write("_");
                }
                else
                {
                    Console.Write(word);
                }
            }
            Console.WriteLine();
        }
    }

    class Word
    {
        private readonly string text;
        private bool isHidden = false;

        public Word(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }

        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

            while (true)
            {
                scripture.Display();

                string input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }

                scripture.HideWord();
            }
        }
    }

}