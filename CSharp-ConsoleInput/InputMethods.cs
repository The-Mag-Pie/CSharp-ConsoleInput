using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_ConsoleInput
{
    public static class InputMethods
    {
        /// <summary>
        /// Allows user to enter an unsigned integer.
        /// </summary>
        /// <returns>An unsigned integer entered by the user.</returns>
        public static int GetInt()
        {
            char key;
            Stack<char> stack = new Stack<char>();
            while (true)
            {
                key = Console.ReadKey(true).KeyChar;
                if (key >= '0' && key <= '9')
                {
                    Console.Write(key);
                    stack.Push(key);
                }
                else if (key == (char)13)
                {
                    Console.Write((char)13);
                    Console.Write((char)10);
                    try
                    {
                        return int.Parse(new string(stack.Reverse().ToArray()));
                    }
                    catch
                    {
                        Console.WriteLine("Niepoprawna liczba. Podaj jeszcze raz:");
                        return GetInt();
                    }
                }
                else if (key == (char)8 && stack.Count > 0)
                {
                    Console.Write((char)8);
                    Console.Write(' ');
                    Console.Write((char)8);
                    stack.Pop();
                }
            }
        }

        /// <summary>
        /// Displays a text and allows user to enter an unsigned integer.
        /// </summary>
        /// <param name="text">A text to be displayed.</param>
        /// <returns>An unsigned integer entered by the user.</returns>
        public static int GetInt(string text)
        {
            Console.Write(text);
            return GetInt();
        }

        /// <summary>
        /// Allows user to enter an unsigned integer within the given range.
        /// </summary>
        /// <param name="start">Begin of range.</param>
        /// <param name="end">End of range.</param>
        /// <returns>An unsigned integer entered by the user.</returns>
        public static int GetInt(int start, int end)
        {
            int num = GetInt();
            if (num >= start && num <= end)
            {
                return num;
            }
            else
            {
                Console.WriteLine("Niepoprawna liczba. Podaj jeszcze raz: ");
                return GetInt(start, end);
            }
        }

        /// <summary>
        /// Displays a text and allows user to enter an unsigned integer within the given range.
        /// </summary>
        /// <param name="start">Begin of range.</param>
        /// <param name="end">End of range.</param>
        /// <param name="text">A text to be displayed.</param>
        /// <returns>An unsigned integer entered by the user.</returns>
        public static int GetInt(int start, int end, string text)
        {
            Console.Write(text);
            return GetInt(start, end);
        }

        /// <summary>
        /// Allows user to enter an unsigned double.
        /// </summary>
        /// <returns>An unsigned double entered by the user.</returns>
        public static double GetDouble()
        {
            bool point = false;
            char key;
            Stack<char> stack = new Stack<char>();
            while (true)
            {
                key = Console.ReadKey(true).KeyChar;
                if (key >= '0' && key <= '9')
                {
                    Console.Write(key);
                    stack.Push(key);
                }
                else if ((key == '.' || key == ',') && !point)
                {
                    Console.Write(key);
                    stack.Push(key);
                    point = true;
                }
                else if (key == (char)13)
                {
                    Console.Write((char)13);
                    Console.Write((char)10);
                    try
                    {
                        return double.Parse(new string(stack.Reverse().ToArray()));
                    }
                    catch
                    {
                        Console.WriteLine("Niepoprawna liczba. Podaj jeszcze raz:");
                        stack = new Stack<char>();
                        point = false;
                        continue;
                    }
                }
                else if (key == (char)8 && stack.Count > 0)
                {
                    Console.Write((char)8);
                    Console.Write(' ');
                    Console.Write((char)8);
                    char popKey = stack.Pop();
                    if (popKey == '.' || popKey == ',')
                    {
                        point = false;
                    }
                }
            }
        }

        /// <summary>
        /// Displays a text and allows user to enter an unsigned double.
        /// </summary>
        /// <param name="text">A text to be displayed.</param>
        /// <returns>An unsigned double entered by the user.</returns>
        public static double GetDouble(string text)
        {
            Console.Write(text);
            return GetDouble();
        }

        /// <summary>
        /// Allows user to enter any string. This method checks only if string is not empty.
        /// </summary>
        /// <returns>An string entered by the user.</returns>
        public static string GetString()
        {
            string text = Console.ReadLine();
            if (text.Equals(""))
            {
                Console.WriteLine("Puste dane. Podaj jeszcze raz.");
                return GetString();
            }
            else
            {
                return text;
            }
        }

        /// <summary>
        /// Displays a text and allows user to enter any string. This method checks only if string is not empty.
        /// </summary>
        /// <param name="text">A text to be displayed.</param>
        /// <returns>An string entered by the user.</returns>
        public static string GetString(string text)
        {
            Console.Write(text);
            return GetString();
        }

        /// <summary>
        /// Allows user to enter a single char.
        /// </summary>
        /// <param name="visible">Defines if entered char should be visible in console or not.</param>
        /// <returns>A char entered by the user.</returns>
        public static char GetChar(bool visible = true)
        {
            char ch = Console.ReadKey(true).KeyChar;
            if (ch < (char)32)
            {
                return GetChar();
            }
            else
            {
                if (visible)
                {
                    Console.Write(ch);
                }
                return ch;
            }
        }

        /// <summary>
        /// Allows user to enter a single char from given list of chars.
        /// </summary>
        /// <param name="allowedCharsList">List of allowed chars.</param>
        /// <returns>A char entered by the user.</returns>
        public static char GetChar(List<char> allowedCharsList)
        {
            char ch = GetChar(false);
            if (allowedCharsList.Contains(ch))
            {
                Console.Write(ch);
                return ch;
            }
            else
            {
                return GetChar(allowedCharsList);
            }
        }

        /// <summary>
        /// Displays a text and allows user to enter a single char.
        /// </summary>
        /// <param name="text">A text to be displayed.</param>
        /// <param name="visible">Defines if entered char should be visible in console or not.</param>
        /// <returns>A char entered by the user.</returns>
        public static char GetChar(string text, bool visible = true)
        {
            Console.Write(text);
            return GetChar(visible);
        }

        /// <summary>
        /// Displays a text and allows user to enter a single char from given list of chars.
        /// </summary>
        /// <param name="text">A text to be displayed.</param>
        /// <param name="allowedCharsList">List of allowed chars.</param>
        /// <returns>A char entered by the user.</returns>
        public static char GetChar(string text, List<char> allowedCharsList)
        {
            Console.Write(text);
            return GetChar(allowedCharsList);
        }
    }
}
