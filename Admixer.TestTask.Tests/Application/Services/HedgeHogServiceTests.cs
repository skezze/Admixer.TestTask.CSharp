using Admixer.TestTask.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Admixer.TestTask.Tests.Application.Services;

    [TestClass]
    public class HedgeHogServiceTests
    {
        private IHedgeHogService _hedgeHogService;

        [TestInitialize]
        public void SetUp()
        {
            _hedgeHogService = new HedgeHogService();
        }

        [TestMethod]
        public void MinMeetings_AllSameColor_ReturnsZero()
        {
            // Arrange
            int[] population = { 10, 0, 0 }; // Всі червоні
            int desiredColor = 0; // Бажаний колір - червоний

            // Act
            int result = _hedgeHogService.MinMeetings(population, desiredColor);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MinMeetings_TwoColorsOnly_CannotAchieveDesiredColor_ReturnsMinusOne()
        {
            // Arrange
            int[] population = { 0, 10, 0 }; // Всі зелені
            int desiredColor = 0; // Бажаний колір - червоний, але червоних немає

            // Act
            int result = _hedgeHogService.MinMeetings(population, desiredColor);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void MinMeetings_ThreeColors_PossibleToAchieveDesiredColor_ReturnsCorrectResult()
        {
            // Arrange
            int[] population = { 1, 1, 1 }; // Є по одному їжачку кожного кольору
            int desiredColor = 0; // Бажаний колір - червоний

            // Act
            int result = _hedgeHogService.MinMeetings(population, desiredColor);

            // Assert
            Assert.AreEqual(1, result); // Має бути 1 зустріч
        }

        [TestMethod]
        public void MinMeetings_ThreeColors_AllConvertToSameColor_ReturnsCorrectResult()
        {
            // Arrange
            int[] population = { 5, 5, 5 }; // Є по 5 їжачків кожного кольору
            int desiredColor = 1; // Бажаний колір - зелений

            // Act
            int result = _hedgeHogService.MinMeetings(population, desiredColor);

            // Assert
            Assert.AreEqual(5, result); // Має бути 5 зустрічей
        }

        [TestMethod]
        public void MinMeetings_TwoColorsRemaining_CorrectConversionToDesiredColor_ReturnsCorrectResult()
        {
            // Arrange
            int[] population = { 0, 5, 5 }; // Залишилися тільки зелені і сині
            int desiredColor = 0; // Бажаний колір - червоний

            // Act
            int result = _hedgeHogService.MinMeetings(population, desiredColor);

            // Assert
            Assert.AreEqual(5, result); // Має бути 5 зустрічей
        }

        [TestMethod]
        public void MinMeetings_TwoColorsAndNoDesiredColor_ReturnsFive()
        {
            // Arrange
            int[] population = { 5, 0, 5 }; // Залишилися червоні та сині
            int desiredColor = 1; // Бажаний колір - зелений, але зелених немає

            // Act
            int result = _hedgeHogService.MinMeetings(population, desiredColor);

            // Assert
            Assert.AreEqual(5, result); // Має бути 5 зустрічей
        }
    }