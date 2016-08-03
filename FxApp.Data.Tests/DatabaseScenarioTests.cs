using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace FxApp.Data.Tests
{
    [TestClass]
    public class DatabaseScenarioTests
    {
        [TestMethod]
        public void CanCreateDatabase()
        {
            using (var db=new DataContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
