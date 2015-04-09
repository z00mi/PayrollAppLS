using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.Domain.Model;

namespace PayrollApp.Domain.Tests
{
    [TestClass]
    public class NullableTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            NullableValObj<EmailAddress> nullableNullEmail = null;
            NullableValObj<EmailAddress> nullableEmail = EmailAddress.Create("nullableEmail@ic.com");
            EmailAddress email = EmailAddress.Create("email@ic.com");

            NullableValObj<EmailAddress> nullableNullEmail2 = null;

            Assert.IsTrue(nullableNullEmail == nullableNullEmail2);
            Assert.IsTrue(nullableNullEmail == null);
            Assert.IsTrue(nullableEmail != null);

            var result = TestOperators(nullableNullEmail);
            Assert.IsNull(result);

            result = TestOperators(null);
            Assert.IsNull(result);

            result = TestOperators(nullableEmail);
            Assert.IsNotNull(result);

            result = TestOperators(email);
            Assert.IsNotNull(result);
        }

        private EmailAddress TestOperators(NullableValObj<EmailAddress> nullableValObj)
        {
            return nullableValObj;
        }
    }
}
