﻿using System;
using ConfigurationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfigurationModelTests
{
    [TestClass]
    public class TagTests
    {
        [TestMethod]
        public void GetName()
        {
            Tag tag = new Tag();   
            Assert.AreEqual("Tag Name", (tag.TagName.Name));
            Assert.AreEqual("Address", (tag.Address.Name));
            Assert.AreEqual("Clamp High", (tag.ClampHigh.Name));

        }
    }
}
