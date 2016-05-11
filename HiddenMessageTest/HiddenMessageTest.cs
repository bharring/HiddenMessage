using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HiddenMessage;
using Xunit.Extensions;
using Xunit.Abstractions;

namespace HiddenMessageTest
{
    public class HiddenMessageTest
    {
        /// <summary>
        /// XUnit test to verify program accuracy. Can be extended by adding any number of InlineData statements
        /// </summary>
        /// <param name="args">
        /// Morse message strings in the form expected from the command line.
        /// </param>
        /// <param name="count">
        /// Expected result.
        /// </param>
        [Theory]
        [InlineData(new string[] { "*-_-***", "*-*"}, 2)]
        [InlineData(new string[] { "****_*_*-**_*-**_---___*--_---_*-*_*-**_-**", "****_*_*-**_*--*" }, 1311)]
        [InlineData(new string[] { "-_****_*___***_-_*-_*-*___*--_*-_*-*_***___***_*-_--*_*-", "-*--_---_-**_*-", "*-**_*_**_*-" }, 11474)]
        public void GivenABRemoveR(string[] args, int count)
        {
            var results = Message.Reduce(args);
            Assert.Equal(results.Count, count);
        }
    }
}
