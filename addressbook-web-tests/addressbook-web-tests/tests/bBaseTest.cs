﻿using NUnit.Framework;

namespace WebAddressbookTests
{
    public class bBaseTest
    {
        protected mApplicationManager app;
        [SetUp]
        public void SetupApplicationManager()
        {
            app = mApplicationManager.GetInstance();
        }
    }
}
