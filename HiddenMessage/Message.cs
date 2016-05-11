using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenMessage
{
    public static class Message
    {
        /// <summary>
        /// Accepts the command line args and calls the recusive method.
        /// </summary>
        /// <param name="args">
        /// The two or three (or more) Morse command line strings.
        /// </param>
        /// <returns>
        /// A collection containing the unique set of reduced strings.
        /// The HashSet object automatically eliminates duplicate entries.
        /// </returns>
        public static HashSet<string> Reduce(string[] args)
        {
            // Initial reduction step contains only one input string, from the command line
            var results = new HashSet<string> { args[0] };
            for (int i = 1; i < args.Length; i++)
            {
                var newResults = new HashSet<string>();
                foreach (var remain in results)
                {
                    newResults = Reduce(remain, args[i], "", newResults);
                }
                // update the collection object for the next set of iterations for the optional second removal string
                results = newResults;
            }
            return results;
        }
        /// <summary>
        /// The recursive method to parse the given message string.
        /// </summary>
        /// <param name="given">
        /// The given Morse code to reduce.
        /// </param>
        /// <param name="remove">
        /// The Morse message to reduce from the given message.
        /// </param>
        /// <param name="prefix">
        /// Temporary place holder for iterating through messages.
        /// </param>
        /// <param name="results">
        /// Collection of unique reduced messages to be accumulated.
        /// </param>
        /// <returns>
        /// Final collection of unique reduced messages.
        /// </returns>
        private static HashSet<string> Reduce(string given, string remove, string prefix, HashSet<string> results)
        {
            if (remove.Length == 0) // Nothing left to reduce
            {
                results.Add(prefix + given);
                return results;
            }

            if (remove.Length >= given.Length) // Last character, nothing left to reduce
            {
                if (remove == given) // Still matching?
                {
                    results.Add(prefix); // It fits, I sits!
                }
                return results;
            }

            int i = -1;
            while (true)
            {
                i = given.IndexOf(remove[0], i + 1);
                if ((i < 0) || ((given.Length - i) < remove.Length))
                {
                    return results; // Match is no longer possible
                }
                
                // Recursive call with partially reduces messages
                Reduce(given.Substring(i + 1), remove.Substring(1), prefix + given.Substring(0, i), results);
            }
        }
    }
}
