using System;
using TechTalk.SpecFlow;

namespace PPC_Rental.AcceptanceTests
{
    [Binding]
    public class EditofagencyprojectSteps
    {
        [Given(@"Mở trang trủ(.*)")]
        public void GivenMởTrangTrủ(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
