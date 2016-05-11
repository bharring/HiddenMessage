using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HiddenMessage
{
    public class Program
    {
        /// <summary>
        /// Finds all of the possible unique sequences of remaining tokens after
        /// removing the second and third message's tokens from the first message's tokens.
        /// </summary>
        /// <param name="args">
        /// Three command-line arguments denoting the original message, the first hidden message,
        /// and the second hidden message. The three messages will be in Morse code. 
        /// There are 3 different types of tokens in the Morse code message.
        /// • Dot (*)
        /// • Dash(-)
        /// • Blank(_)
        /// Every letter in the message is separated by a single blank character (_) and
        /// every word is separated by 3 blank characters(___).
        /// </param>
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: HiddenMessage MESSAGE REDUCE...");
                return;
            }
            
            var results = Message.Reduce(args);
            Console.WriteLine(results.Count);
        }
    }
}
