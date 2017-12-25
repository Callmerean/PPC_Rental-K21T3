using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC_Rental.AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

using PPC_Rental.Models;


namespace PPC_Rental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class AddDataStep
    {
          private readonly ProjectDriver _projectDriver;
        public AddDataStep(ProjectDriver driver)
        {
            _projectDriver = driver;
        }

        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProjects)
        {
            _projectDriver.InsertProjecttoDB(givenProjects);
        }

      


    }
}
