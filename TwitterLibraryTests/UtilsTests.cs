using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterLibrary.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        /// <summary>
        /// Test example.
        /// </summary>
        [TestMethod()]
        public void DoActionTest()
        {
            string action = "z";
            string expected = "The action '" + action + "' not exists.";
            string actual = Utils.DoAction(action, null, null);

            Assert.AreEqual(expected, actual);
        }
    }
}