using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataOnConsole1
{
    class Program
    {
        /// <summary>
        /// Text displayed via the console for user interface simulation
        /// </summary>
        /// 
        static List<dynamic> docText = null;
        /// <summary>
        /// Determines the filler character to get center text
        /// </summary>
        static char emptyChar = ' ';
        /// <summary>
        /// Determines the maximum length of a line
        /// </summary>
        static int windowWidth = 75;
        /// <summary>
        /// Debug mode
        /// </summary>
        static bool debug = false;
        static void Main(string[] args)
        {
            List<string> fileTypes = new List<string> { ".yml", ".json", ".xml" };
            string result = "?";
            bool ready = false;
            Console.WindowWidth = windowWidth;
            #region Setup
            if (!debug)
            {
                Console.WindowHeight = 15;
                docText = new List<dynamic>()
                {
                    new KeyValuePair<string, ConsoleColor>("",ConsoleColor.White),
                    new KeyValuePair<string, ConsoleColor>("------------------",ConsoleColor.Green),
                    new List<KeyValuePair<string, ConsoleColor>>()
                    {
                        new KeyValuePair<string, ConsoleColor>("| ", ConsoleColor.Green),
                        new KeyValuePair<string, ConsoleColor>("Welcome To ", ConsoleColor.White),
                        new KeyValuePair<string, ConsoleColor>("DOC", ConsoleColor.Cyan),
                        new KeyValuePair<string, ConsoleColor>(" |", ConsoleColor.Green)
                    },
                    new KeyValuePair<string, ConsoleColor>("------------------",ConsoleColor.Green),
                    new KeyValuePair<string, ConsoleColor>("",ConsoleColor.White),
                    new List<KeyValuePair<string, ConsoleColor>>()
                    {
                        new KeyValuePair<string, ConsoleColor>("About ", ConsoleColor.Green),
                        new KeyValuePair<string, ConsoleColor>("DOC", ConsoleColor.Cyan),
                        new KeyValuePair<string, ConsoleColor>(":", ConsoleColor.Green)
                    },
                    new KeyValuePair<string, ConsoleColor>("View the many types of data from the comfort of a console.", ConsoleColor.White),
                    new KeyValuePair<string, ConsoleColor>("Intuitive design with effective input and output.", ConsoleColor.White),
                    new KeyValuePair<string, ConsoleColor>("Simple interface that allows for easy use.", ConsoleColor.White),
                    new KeyValuePair<string, ConsoleColor>("",ConsoleColor.White),
                    new List<KeyValuePair<string, ConsoleColor>>()
                    {
                        new KeyValuePair<string, ConsoleColor>("// ", ConsoleColor.Green),
                        new KeyValuePair<string, ConsoleColor>("Press Any Key To Continue", ConsoleColor.White),
                        new KeyValuePair<string, ConsoleColor>("...",ConsoleColor.Green)
                    }
                };

                SPrint(docText);

                Console.ReadKey();
            }

            Console.Clear();
            #endregion
            while (true)
            {
                #region Document File Request
                while (!ready)
                {

                    docText = new List<dynamic>()
                {
                    new KeyValuePair<string, ConsoleColor>("",ConsoleColor.White),
                    new List<KeyValuePair<string, ConsoleColor>>()
                    {
                        new KeyValuePair<string, ConsoleColor>("Please", ConsoleColor.White),
                        new KeyValuePair<string, ConsoleColor>(" input below ", ConsoleColor.Green),
                        new KeyValuePair<string, ConsoleColor>("the", ConsoleColor.White),
                        new KeyValuePair<string, ConsoleColor>(" file path ", ConsoleColor.Green),
                        new KeyValuePair<string, ConsoleColor>("and", ConsoleColor.White),
                        new KeyValuePair<string, ConsoleColor>(" document", ConsoleColor.Green)
                    },
                    new KeyValuePair<string, ConsoleColor>("which you would like to view", ConsoleColor.White),
                    new KeyValuePair<string, ConsoleColor>("",ConsoleColor.White),
                };

                    SPrint(docText);
                    string file = Console.ReadLine();
                    if (File.Exists(file))
                    {
                        Console.Clear();
                        foreach (string type in fileTypes)
                        {
                            if (Path.GetExtension(file) == type)
                            {
                                ready = true;
                                result = file;
                            }
                            else if (ready != true && fileTypes.IndexOf(type) == fileTypes.Count)
                            {
                                Console.Clear();
                                EPrintLine("File Type Not Readable");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        EPrintLine("File Not Found");
                    };
                }
                ready = false;
                #endregion

                docText = formatFileData(result);

                SPrint(docText);
                SPrint("", ConsoleColor.White);

                Console.ReadLine();
                Console.Clear();
            }
        }
        /// <summary>
        /// Print generic error message to console using Console.Write function
        /// </summary>
        static void EPrint()
        {
            string eMsg = "Error";
            int diff = windowWidth - eMsg.Length;
            if (diff % 2 == 0)
            {
                for (int i = 0; i < diff / 2; i++)
                {
                    eMsg = emptyChar + eMsg;

                }
            }
            else
            {
                for (int i = 0; i < (diff + 1) / 2; i++)
                {
                    eMsg = emptyChar + eMsg;
                }
            }
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(eMsg);
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Print generic line error message to console using Console.WriteLine function
        /// </summary>
        static void EPrintLine()
        {
            string eMsg = "Line Error";
            int diff = windowWidth - eMsg.Length;
            if (diff % 2 == 0)
            {
                for (int i = 0; i < diff / 2; i++)
                {
                    eMsg = emptyChar + eMsg;

                }
            }
            else
            {
                for (int i = 0; i < (diff + 1) / 2; i++)
                {
                    eMsg = emptyChar + eMsg;
                }
            }
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(eMsg);
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Print custom error message to console using Console.WriteLine function
        /// </summary>
        /// <param name="message"></param>
        /// <example>
        /// EPrintLine("String Value");
        /// </example>
        static void EPrintLine(string message)
        {
            string eMsg = "Error: " + message;
            int diff = windowWidth - eMsg.Length;
            if (diff >= 0 && diff % 2 == 0)
            {
                for (int i = 0; i < diff / 2; i++)
                {
                    eMsg = emptyChar + eMsg;
                }
            }
            else if (diff >= 0)
            {
                for (int i = 0; i < (diff + 1) / 2; i++)
                {
                    eMsg = emptyChar + eMsg;
                }
            }
            else
            {
                eMsg = lineBreakup(eMsg);
            }
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(eMsg);
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Fixes string value to fit in console
        /// </summary>
        /// <param name="input"></param>
        /// <returns>String value which will fit on the console properly</returns>
        static string lineBreakup(string input)
        {
            string output = "";
            string[] widthFix = new string[(input.Length / windowWidth) + 1];
            for (int currentIndex = 0; currentIndex < (widthFix.Count() - 1); currentIndex++)
            {
                widthFix[currentIndex] = currentIndex == widthFix.Count() - 1 ? widthFix[currentIndex] = input.Substring(currentIndex + 1 * windowWidth) : input.Substring(currentIndex * windowWidth, currentIndex + 1 * windowWidth);
            }
            widthFix[widthFix.Count() - 1] = input.Substring((widthFix.Count() - 1) * windowWidth);
            for (int i = widthFix[widthFix.Count() - 1].Length; i < (windowWidth/2); i++)
            {   /* centers final breakup */
                widthFix[widthFix.Count() - 1] = emptyChar + widthFix[widthFix.Count() - 1];
            }
            for (int currentIndex = 0; currentIndex <= (widthFix.Count() - 1); currentIndex++)
            {
                output += widthFix[currentIndex] == widthFix.Last() ? widthFix[currentIndex] : widthFix[currentIndex] + Environment.NewLine;
            }
            return output;
        }
        /// <summary>
        /// Returns formatted list for output to console
        /// </summary>
        /// <param name="input">Full File Path</param>
        /// <returns>List of dynamic key,value pairs</returns>
        static List<dynamic> formatFileData(string input)
        {
            List<dynamic> output = null;
            using (StreamReader file = new StreamReader(input))
            {
                string data = file.ReadToEnd();
                data = data.Replace('\t', ' ');
                output = new List<dynamic>()
                {
                    new List<KeyValuePair<string, ConsoleColor>>()
                    {
                        new KeyValuePair<string, ConsoleColor>("Displaying ", ConsoleColor.White),
                        new KeyValuePair<string, ConsoleColor>($"{Path.GetFileName(input)}", ConsoleColor.Green),
                        new KeyValuePair<string, ConsoleColor>(" . . .", ConsoleColor.White)
                    },
                        new KeyValuePair<string, ConsoleColor>("", ConsoleColor.White)
                };
                switch (Path.GetExtension(input))
                {
                    case ".yml":
                        #region Case Statement 1
                        int cachedIndex = 0;
                        for (int currentIndex = 0; currentIndex < data.Length; currentIndex++)
                        {
                            string outString = "";
                            if (currentIndex == data.Length - 1)
                            {
                                outString = data.Substring(cachedIndex);
                                if (outString.Length < windowWidth)
                                    for (int i = outString.Length; i < windowWidth; i++)
                                    {
                                        outString = outString + emptyChar;
                                    }
                                output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                            }
                            else if (data[currentIndex] == '\n')
                            {
                                outString = data.Substring(cachedIndex, (currentIndex - cachedIndex) - 1);
                                if (outString.Length < windowWidth)
                                    for (int i = outString.Length; i < windowWidth; i++)
                                    {
                                        outString = outString + emptyChar;
                                    }
                                output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                                cachedIndex = currentIndex + 1;
                            }
                        }
                        #endregion
                        return output;
                    case ".json":
                        #region Case Statement 2
                        cachedIndex = 0;
                        for (int currentIndex = 0; currentIndex < data.Length; currentIndex++)
                        {
                            string outString = "";
                            if (currentIndex == data.Length-1)
                            {
                                outString = data.Substring(cachedIndex);
                                if (outString.Length < windowWidth)
                                    for (int i = outString.Length; i < windowWidth; i++)
                                    {
                                        outString = outString + emptyChar;
                                    }
                                output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                            }
                            else if (data[currentIndex] == '\n')
                            {
                                outString = data.Substring(cachedIndex, (currentIndex - cachedIndex) - 1);
                                if (outString.Length < windowWidth)
                                {
                                    for (int i = outString.Length; i < windowWidth; i++)
                                    {
                                        outString = outString + emptyChar;
                                    }
                                    output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                                }
                                else if (outString.Length > windowWidth)
                                {
                                    string fixedOutput = outString.Substring(0, windowWidth);
                                    for (int i = fixedOutput.Length; i < windowWidth; i++)
                                    {
                                        fixedOutput = fixedOutput + emptyChar;
                                    }
                                    output.Add(new KeyValuePair<string, ConsoleColor>(fixedOutput, ConsoleColor.White));
                                    fixedOutput = outString.Substring(windowWidth);
                                    for (int i = fixedOutput.Length; i < windowWidth; i++)
                                    {
                                        fixedOutput = fixedOutput + emptyChar;
                                    }
                                    output.Add(new KeyValuePair<string, ConsoleColor>(fixedOutput, ConsoleColor.White));
                                }
                                else
                                    output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                                cachedIndex = currentIndex + 1;
                            }
                        }
                        #endregion
                        return output;
                    case ".xml":
                        #region Case Statement 3
                        cachedIndex = 0;
                        int indent = -2;
                        for (int currentIndex = 0; currentIndex < data.Length; currentIndex++)
                        {
                            string outString = "";
                            if (data[currentIndex] == '\n')
                            {
                                outString = data.Substring(cachedIndex, currentIndex - cachedIndex - 1);
                                if (outString.Contains("/"))
                                { /*prevents re-print of individual lines*/ }
                                else
                                {
                                    for (int i = 0; i <= indent; i++)
                                    {
                                        outString = emptyChar + outString;
                                    }
                                    for (int i = outString.Length; i < windowWidth; i++)
                                    {
                                        outString = outString + emptyChar;
                                    }
                                    output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                                }
                            }
                            else if (data[currentIndex] == '<')
                            {
                                if (data[currentIndex + 1] == '/')
                                {
                                    if (data.Substring(cachedIndex, currentIndex - cachedIndex).Contains("\n"))
                                    {
                                        cachedIndex = cachedIndex + data.Substring(cachedIndex,currentIndex-cachedIndex).LastIndexOf('\n');
                                    }
                                    else
                                    {
                                        outString = data.Substring(cachedIndex, currentIndex - cachedIndex);
                                        for (int i = 0; i <= indent; i++)
                                        {
                                            outString = emptyChar + outString;
                                        }
                                        for (int i = outString.Length; i < windowWidth; i++)
                                        {
                                            outString = outString + emptyChar;
                                        }
                                        output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                                        indent--;
                                    }
                                }
                                else
                                {
                                    indent++;
                                    cachedIndex = currentIndex;
                                }
                            }
                            else if (data[currentIndex] == '>')
                            {
                                outString = data.Substring(cachedIndex, (currentIndex - cachedIndex)+1);
                                if (outString.Contains("\n"))
                                {
                                    for (int i = 0; i < outString.LastIndexOf('<'); i++)
                                    {
                                        outString = outString.Remove(0, 1);
                                    }
                                    for (int i = 0; i <= indent; i++)
                                    {
                                        outString = emptyChar + outString;
                                    }
                                    for (int i = outString.Length; i < windowWidth; i++)
                                    {
                                        outString = outString + emptyChar;
                                    }
                                    output.Add(new KeyValuePair<string, ConsoleColor>(outString, ConsoleColor.White));
                                    indent--;
                                }
                            }
                        }
                        #endregion
                        return output;
                    default:
                        EPrintLine("File Type Not Supported Yet");
                        return new List<dynamic>() { new List<KeyValuePair<string, ConsoleColor>>() };
                }
            }
        }
        #region SPrint Overloads
        /// <summary>
        /// Print to console using Console.Write based on parameters
        /// </summary>
        /// <param name="input"></param>
        /// <param name="color"></param>
        /// <example>
        /// SPrint("String Value", ConsoleColor.White);
        /// </example>
        static void SPrint(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            string output = input;
            if (input.Length < windowWidth)
            {
                int diff = windowWidth - input.Length;
                if (diff % 2 == 0)
                {
                    for (int i = 0; i < diff / 2; i++)
                    {
                        output = emptyChar + output;
                    }
                }
                else
                {
                    for (int i = 0; i < (diff + 1) / 2; i++)
                    {
                        output = emptyChar + output;
                    }
                }
                Console.Write(output);
            }
        }
        /// <summary>
        /// Print to console using Console.Write based on parameters
        /// </summary>
        /// <param name="input"></param>
        /// <param name="color"></param>
        /// <example>
        /// SPrint({"String", "Array", "Value"}, ConsoleColor.White);
        /// </example>
        static void SPrint(string[] input, ConsoleColor[] color)
        {
            if (input.Length == color.Length)
            {
                for (int i = 0; i > input.Length; i++)
                {
                    Console.ForegroundColor = color[i];
                    Console.Write(input[i]);
                }
            }
            else
            {
                EPrintLine("Invalid Calculation");
                Console.Write("\n");
            }
        }
        /// <summary>
        /// Print to console using Console.Write based on parameter
        /// </summary>
        /// <param name="input"></param>
        /// <example>
        /// SPrint(Dictionary<string_ConsoleColor> Value);
        /// </example>
        static void SPrint(Dictionary<string, ConsoleColor> input)
        {
            foreach (string str in input.Keys)
            {
                Console.ForegroundColor = input[str];
                Console.Write(str);
            }
        }
        /// <summary>
        /// Print to console using Console.Write based on parameter
        /// </summary>
        /// <param name="input"></param>
        /// <example>
        /// SPrint(List<KeyValuePair<string_ConsoleColor>> Value);
        /// </example>
        static void SPrint(List<KeyValuePair<string, ConsoleColor>> input)
        {
            foreach (KeyValuePair<string, ConsoleColor> i in input)
            {
                Console.ForegroundColor = i.Value;
                Console.Write(i.Key);
            }
        }
        /// <summary>
        /// Print to console using Console.Write based on parameter
        /// </summary>
        /// <param name="input"></param>
        /// <example>
        /// SPrint(List<dynamic> Value);
        /// </example>
        static void SPrint(List<dynamic> input)
        {
            foreach (var item in input)
            {
                try
                {
                    string outputString = item.Key;
                    Console.ForegroundColor = item.Value;
                    if (outputString.Length < windowWidth)
                    {
                        int diff = windowWidth - outputString.Length;
                        if (diff % 2 == 0)
                        {
                            for (int i = 0; i < diff / 2; i++)
                            {
                                outputString = emptyChar + outputString;

                            }
                        }
                        else
                        {
                            for (int i = 0; i < (diff + 1) / 2; i++)
                            {
                                outputString = emptyChar + outputString;
                            }
                        }
                        if (outputString.Contains('\n'))
                            Console.Write(outputString);
                        else
                            Console.WriteLine(outputString);
                    }
                    else if (outputString.Length > windowWidth)
                    {
                        outputString = lineBreakup(outputString);
                        if (outputString.Contains('\n'))
                            Console.Write(outputString);
                        else
                            Console.WriteLine(outputString);
                    }
                    else
                    {
                        if (outputString.Contains('\n'))
                            Console.Write(outputString);
                        else
                            Console.WriteLine(outputString);
                    }
                }
                catch
                {
                    try
                    {
                        int outputLength = 0;
                        foreach (var listItem in item)
                        {
                            outputLength += listItem.Key.Length;
                        }
                        for (int currentItem = 0; currentItem < item.Count; currentItem++)
                        {
                            string outputString = item[currentItem].Key;
                            Console.ForegroundColor = item[currentItem].Value;
                            if (currentItem == 0)
                            {
                                if (outputString.Length < windowWidth)
                                {
                                    int diff = windowWidth - outputLength;
                                    if (diff % 2 == 0)
                                    {
                                        for (int l = 0; l < diff / 2; l++)
                                        {
                                            outputString = emptyChar + outputString;
                                        }
                                    }
                                    else
                                    {
                                        for (int l = 0; l < (diff + 1) / 2; l++)
                                        {
                                            outputString = emptyChar + outputString;
                                        }
                                    }
                                    Console.Write(outputString);
                                }
                                else if (outputString.Length > windowWidth)
                                {
                                    outputString = lineBreakup(outputString);
                                    Console.Write(outputString);
                                }
                                else
                                {
                                    Console.Write(item.Key);
                                }
                            }
                            else if (currentItem == item.Count - 1)
                            {
                                if (outputString.Contains('\n'))
                                    Console.Write(outputString);
                                else
                                    Console.Write(outputString+"\n");
                            }
                            else
                            {
                                Console.Write(outputString);
                            }
                        }
                    }
                    catch
                    {
                        EPrintLine("Invalid Dynamic");
                    }
                }
            }
        }
        #endregion
    }
}