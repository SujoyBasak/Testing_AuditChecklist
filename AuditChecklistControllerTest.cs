using AuditChecklistModule.Controllers;
using AuditChecklistModule.Repository;
using AuditChecklistModule.Providers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuditChecklistModule.Testing
{
    public class AuditChecklistControllerTest
    {
                
        [TestCase("Internal")]
        [TestCase("SOX")]        
        public void GetQuestionsTest(string type)
        {
            ChecklistRepo rep = new ChecklistRepo();
            ChecklistProvider pr = new ChecklistProvider(rep);
            AuditChecklistController con = new AuditChecklistController(pr);

            OkObjectResult data = con.GetQuestions(type) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }



        [TestCase("SOX123")]
        [TestCase("Internal123")]
        public void GetQuestionsFailTest(string type)
        {
            try
            {
                ChecklistRepo rep = new ChecklistRepo();
                ChecklistProvider pr = new ChecklistProvider(rep);
                AuditChecklistController con = new AuditChecklistController(pr);

                OkObjectResult data = con.GetQuestions(type) as OkObjectResult;

                Assert.AreEqual(200, data.StatusCode);
            }
            catch(Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.",e.Message);
            }
            
            
        }


    }
}