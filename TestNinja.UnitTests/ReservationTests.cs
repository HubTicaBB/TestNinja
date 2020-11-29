using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            var reservation = new Reservation();
            var user = new User() { IsAdmin = true };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnsFalse()
        {
            var reservation = new Reservation();
            var user = new User() { IsAdmin = false };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_MadeByThisUser_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };            

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_NotMadeByThisUser_ReturnsFalse()
        {
            var reservation = new Reservation() { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}
