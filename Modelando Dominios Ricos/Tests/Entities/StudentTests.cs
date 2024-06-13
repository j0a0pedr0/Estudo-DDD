using Domain.Entities;

namespace Tests.Entities 
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddSubscription()
        {

            var subscription = new Subscription(null);
            var student = new Student("André","Baltieri","31231234124","Hello@balta.io");

            student.AddSubscription(subscription);


        }
    }

}