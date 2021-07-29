using System.Collections.Generic;
using CommercialOptimiser.Core;
using CommercialOptimiser.Models;
using NUnit.Framework;
using System.Linq;

namespace CommercialOptimiser.Tests
{
    public class CommercialOptimiserTests
    {
        ICommercialOptimiser commercialOptimiser;

        [SetUp]
        public void Setup()
        {
            var commericals = new List<Commercial>()
            {
                new Commercial(){ Name = "Commercial 1", Type = CommercialTypes.Automotive, Demographic = Demographics.W_25_30 },
                new Commercial(){ Name = "Commercial 2", Type = CommercialTypes.Travel, Demographic = Demographics.M_18_35 },
                new Commercial(){ Name = "Commercial 3", Type = CommercialTypes.Travel, Demographic = Demographics.T_18_40 },
                new Commercial(){ Name = "Commercial 4", Type = CommercialTypes.Automotive, Demographic = Demographics.M_18_35 },
                new Commercial(){ Name = "Commercial 5", Type = CommercialTypes.Automotive, Demographic = Demographics.M_18_35 },
                new Commercial(){ Name = "Commercial 6", Type = CommercialTypes.Finance, Demographic = Demographics.W_25_30 },
                new Commercial(){ Name = "Commercial 7", Type = CommercialTypes.Finance, Demographic = Demographics.M_18_35 },
                new Commercial(){ Name = "Commercial 8", Type = CommercialTypes.Automotive, Demographic = Demographics.T_18_40 },
                new Commercial(){ Name = "Commercial 9", Type = CommercialTypes.Travel, Demographic = Demographics.W_25_30 },
            };

            var ratings = new List<Break>()
            {
                new Break(){ Type = BreakType.Break1, Demographic = Demographics.W_25_30, Rating = 80 },
                new Break(){ Type = BreakType.Break1, Demographic = Demographics.M_18_35, Rating = 100 },
                new Break(){ Type = BreakType.Break1, Demographic = Demographics.T_18_40, Rating = 250 },
                new Break(){ Type = BreakType.Break2, Demographic = Demographics.W_25_30, Rating = 50 },
                new Break(){ Type = BreakType.Break2, Demographic = Demographics.M_18_35, Rating = 120 },
                new Break(){ Type = BreakType.Break2, Demographic = Demographics.T_18_40, Rating = 200 },
                new Break(){ Type = BreakType.Break3, Demographic = Demographics.W_25_30, Rating = 350 },
                new Break(){ Type = BreakType.Break3, Demographic = Demographics.M_18_35, Rating = 150 },
                new Break(){ Type = BreakType.Break3, Demographic = Demographics.T_18_40, Rating = 500 }
            };

            commercialOptimiser = CommercialOptimiserService.GetCommercialOptimiser(commericals, ratings);
        }

        [Test]
        public void CommercialOptimiserService_Instance_Check_Test()
        {
            Assert.IsNotNull(commercialOptimiser, "Commercial Optimiser instance is null");
        }

        [Test]
        public void CommercialOptimiser_ObtainOptimisedRatings_Results_Check_Test()
        {
            var optimisedResult = commercialOptimiser.ObtainOptimisedRatings(3, 3, 3);

            Assert.IsNotNull(optimisedResult, "Result of ObtainOptimisedRatings method is null");
            Assert.IsTrue(optimisedResult.Key == 1940, "Maximum optimised ratings is not correct");
            Assert.IsTrue(optimisedResult.Count() == 8, "Maximum optimised ratings combinations");
        }

        [Test]
        public void CommercialOptimiser_Filters_Check_Test()
        {
            var optimisedResult = commercialOptimiser.ObtainOptimisedRatings(3, 3, 3);

            Assert.IsTrue(optimisedResult.Any(b => b.Break2.Any(c => c.Type != CommercialTypes.Finance)), "Finance type commercials are present in break 2");

            bool isFilterCondition2Failed = false;
            foreach (var item in optimisedResult)
            {
                for (int i = 0; (i + 1) < item.Break1.Count; i++)
                {
                    if(item.Break1[i].Type == item.Break1[i + 1].Type)
                    {
                        isFilterCondition2Failed = true;
                        break;
                    }
                }

                if(!isFilterCondition2Failed)
                {
                    for (int i = 0; (i + 1) < item.Break2.Count; i++)
                    {
                        if (item.Break2[i].Type == item.Break2[i + 1].Type)
                        {
                            isFilterCondition2Failed = true;
                            break;
                        }
                    }
                }

                if (!isFilterCondition2Failed)
                {
                    for (int i = 0; (i + 1) < item.Break3.Count; i++)
                    {
                        if (item.Break3[i].Type == item.Break3[i + 1].Type)
                        {
                            isFilterCondition2Failed = true;
                            break;
                        }
                    }
                }
            }

            Assert.IsFalse(isFilterCondition2Failed, "Same type commercials are present in a Break");
        }

        [Test]
        public void CommercialOptimiser_UnEvenBreakLimit_Check_Test()
        {
            var optimisedResult = commercialOptimiser.ObtainOptimisedRatings(2, 3, 4);

            Assert.IsNotNull(optimisedResult, "Result of ObtainOptimisedRatings method is null");
            Assert.IsTrue(optimisedResult.Key == 2190, "Maximum optimised ratings is not correct");
            Assert.IsTrue(optimisedResult.Count() == 4, "Maximum optimised ratings combinations");

            var firstOptimisedItem = optimisedResult.FirstOrDefault();

            Assert.IsTrue(firstOptimisedItem.Break1.Count == 2, "Uneven break limit for break 1 is not achieved");
            Assert.IsTrue(firstOptimisedItem.Break2.Count == 3, "Uneven break limit for break 2 is not achieved");
            Assert.IsTrue(firstOptimisedItem.Break3.Count == 4, "Uneven break limit for break 3 is not achieved");
        }

        [Test]
        public void CommercialOptimiser_InvalidInput_Zero_Test()
        {
            bool isExceptionThrown = false;
            try
            {
                var optimisedResult = commercialOptimiser.ObtainOptimisedRatings(0, 5, 4);
            }
            catch (InvalidInputException)
            {
                isExceptionThrown = true;
            }

            Assert.IsTrue(isExceptionThrown, "Invaild input exception not thrown");
        }

        [Test]
        public void CommercialOptimiser_InvalidInput_Count_Test()
        {
            bool isExceptionThrown = false;
            try
            {
                var optimisedResult = commercialOptimiser.ObtainOptimisedRatings(3, 5, 5);
            }
            catch (InvalidInputException)
            {
                isExceptionThrown = true;
            }

            Assert.IsTrue(isExceptionThrown, "Invaild input exception not thrown");
        }
    }
}
