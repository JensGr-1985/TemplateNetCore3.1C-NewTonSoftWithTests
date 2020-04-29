using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiCore3._1WithSwagger.DbAccess;
using WebApiCore3._1WithSwagger.Repository;
using WebApiCore3._1WithSwagger.Repository.DbAccess.Interface;

namespace UnitTestProject1
{
    [TestClass]
    public class NameofTheClassYouwantToTest
    {
        Mock<IDbAccess> mock = new Mock<IDbAccess>();
        /// <summary>
        /// Here You Set Up Your Mock
        /// </summary>
        [TestInitialize]
        public void PreperationForTheTest()
        {
           //This is the mock we set up, for each string of SQl you use and any Parameter you pass the Method ExecuteSql return 1
            mock.Setup(x=>x.ExecuteSql(It.IsAny<string>(),It.IsAny<IEnumerable<SqlParam>>())).Returns(1);
            //if you uise Query<int> this will be the result
            //This is the mockup for the TEst  MethodToBeTested_With_Excepted_Behavior
            mock.Setup(x => x.Query<int>(It.IsAny<string>(), It.IsAny<IEnumerable<SqlParam>>())).Returns(new List<int>(){1,2,3,4,});
            //Same for Query<string>
            mock.Setup(x => x.Query<string>(It.IsAny<string>(), It.IsAny<IEnumerable<SqlParam>>())).Returns(new List<string>() { "1", "2", "3", "4" });
        }
        
        [TestMethod]
        public void MethodToBeTested_With_Excepted_Behavior()
        {
            //ARANGE
            //Passing the mock with DI to the class
            var mytestclass= new ClassThatContainsMethodWeWannaTest(mock.Object);
            
            //ACT
            var res = mytestclass.MethodweGonnaTest(1);

            //Assert
            Assert.IsTrue(res is int,"Return value is Type of Int");

            //
            Assert.IsTrue(res==1,"Return Value is Excepted");
        }
    }
}
