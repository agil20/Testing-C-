using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestingUnit.Models;
using TestingUnit.Services;

namespace TestingJob
{
    public class Tests
    {
        [Test]
        public void Job_Yasheddi_Yasheddiduygundeyil()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var evaluator = new AplicationJob(mockValidator.Object);
            var job = new Job()
            {
                User = new User()
                {
                    Age = 17
                }
            };
        var appResult=evaluator.Evalute(job);
          Assert.AreEqual(appResult, JobResult.YasheddiUygundeyil);
                
        }
        [Test]
        public void Job_BilikSayi_BilikSayiUYgundur()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(i => i.IsValid("")).Returns(true);
            var evaluator = new AplicationJob(mockValidator.Object);
            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>(){ "1" }
                
            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.Biliksayiduzgundeyil);

        }
        [Test]
        public void Job_BilikSayi_BilikSayiUYgundeyil()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var evaluator = new AplicationJob(mockValidator.Object);
            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>() { "" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.BiliksayiUygundur);

        }
        [Test]
        public void Job_Number_Numbersboolfalse()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(false);
            var evaluator = new AplicationJob(mockValidator.Object);
           
            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>() { "C#", "MVC", "APi", "Sql" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.HrlaElaq);

        }
        [Test]
        public void Job_Number_NumbersboolTrue()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var evaluator = new AplicationJob(mockValidator.Object);

            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>() { "C#", "MVC", "APi", "Sql" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.BiliksayiUygundur);

        }
        [Test]
        public void Job_CvReturn_NumbersboolFalse()
        {
            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
           // mockValidator.Setup(i => i.IsReturnCv()).Returns(false);
            var evaluator = new AplicationJob(mockValidator.Object);

            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>() { "C#", "MVC", "APi", "Sql" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.cvGonderilmedi);

        }
        [Test]
        public void Job_CvReturn_NumbersboolTrue()
        {
            var mockValidator = new Mock<IIdentityValidator>(MockBehavior.Strict);
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(i => i.IsReturnCv()).Returns(true);
            mockValidator.DefaultValue = DefaultValue.Mock;
            var evaluator = new AplicationJob(mockValidator.Object);

            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>() { "C#", "MVC", "APi", "Sql" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.BiliksayiUygundur);

        }
        [Test]
        public void Job_Country_Hr()
        {
            var mockValidator = new Mock<IIdentityValidator>(MockBehavior.Strict);
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(i => i.IsReturnCv()).Returns(true);
            mockValidator.Setup(i => i.Country.Countr).Returns("Turkey");
            var evaluator = new AplicationJob(mockValidator.Object);

            var job = new Job()
            {
                User = new User()
                {
                    Age = 19
                },
                BilikSayi = new List<string>() { "C#", "MVC", "APi", "Sql" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(appResult, JobResult.HrlaElaq);

        }
        [Test]
        public void Job_Country_yasheddi()
        {
         
            var mockValidator = new Mock<IIdentityValidator>(MockBehavior.Strict);
            mockValidator.SetupProperty(i=>i.yasheddi);
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(i => i.IsReturnCv()).Returns(true);
            mockValidator.Setup(i => i.Country.Countr).Returns("Turkey");
       
            var evaluator = new AplicationJob(mockValidator.Object);

            var job = new Job()
            {
                User = new User()
                {
                    Age = 51
                },
                BilikSayi = new List<string>() { "C#", "MVC", "APi", "Sql" }

            };
            var appResult = evaluator.Evalute(job);
            Assert.AreEqual(Yasheddi.kecersizdir,mockValidator.Object.yasheddi);

        }
    }
}