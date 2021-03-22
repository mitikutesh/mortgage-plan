using Moq;
using Mortgage.Data.DTO;
using Mortgage.Data.Entity;
using Mortgage.Data.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mortgage.Data.Test
{
    public class Tests
    {
        public Tests()
        {
            Mock<IMortgageProspect> mockRepository = new Mock<IMortgageProspect>();

            List<ProspectDTO> prospectInMemoryDatabase = new List<ProspectDTO>
                {
                    new ProspectDTO() {Id = 1, CustomerName = "Juha", LoanAmount = 1000, AnnualInterest = 10, LoanTerm = 3},
                    new ProspectDTO() {Id = 2, CustomerName = "Test", LoanAmount = 5002, AnnualInterest = 16, LoanTerm = 2},
                     new ProspectDTO() {Id = 3, CustomerName = "Test2", LoanAmount = 100000, AnnualInterest = 2, LoanTerm = 25}
                };
            // Return all the products
            mockRepository.Setup(mr => mr.GetListAsync().Result).Returns(prospectInMemoryDatabase);

            // return a product by Id
            mockRepository.Setup(mr => mr.GetProspectAsync(
                It.IsAny<int>()).Result).Returns((int i) => prospectInMemoryDatabase.Where(x => x.Id == i).Single());

            // Allows us to test saving a product
            mockRepository.Setup(mr => mr.AddAsync(It.IsAny<ProspectDTO>())).Returns(
                (ProspectDTO target) =>
                {
                    if (target.Id.Equals(default(int)))
                    {
                        target.CustomerName = "Tst";
                        target.LoanAmount = 1000;
                        target.LoanTerm = 3;
                        target.AnnualInterest = 10;
                        prospectInMemoryDatabase.Add(target);
                    }
                    else
                    {
                        var original = prospectInMemoryDatabase.Where(
                            q => q.Id == target.Id).Single();

                        if (original == null)
                        {
                            return Task.FromResult(false);
                        }

                        target.CustomerName = "Tst2";
                        target.LoanAmount = 10020;
                        target.LoanTerm = 23;
                        target.AnnualInterest = 12;
                    }

                    return Task.FromResult(true);
                });

            this.MockProspectRepository = mockRepository.Object;
        }

        [SetUp]
        public void Setup()
        {


        }

        public TestContext TestContext { get; set; }
        public readonly IMortgageProspect MockProspectRepository;


        [Test]
        public async Task Get_By_Id_Should_workdAsync()
        {
            ProspectDTO testProspect = await this.MockProspectRepository.GetProspectAsync(2);

            Assert.IsNotNull(testProspect); // Test if null
            Assert.AreEqual("Test", testProspect.CustomerName);
        }
        [Test]
        public async Task Get_All_Should_workdAsync()
        {
             IList<ProspectDTO> testProp = await this.MockProspectRepository.GetListAsync();

                    Assert.IsNotNull(testProp); // Test if null
            Assert.AreEqual(3, testProp.Count);
        }
       
        
        //[Test]
        //public void Delete_Should_work()
        //{
        //    mockRepository.Setup(a => a.AddAsync(prospectInMemoryDatabase.First()))
        //    Assert.Pass();
        //}
        //[Test]
        //public void Add_Should_work()
        //{
           
        //}
       
    }
}