using System.Collections.Generic;
using System.Threading.Tasks;
using CovidTrackerApp.Interfaces;
using CovidTrackerApp.Models;
using CovidTrackerApp.Controllers;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace CovidTesting
{
	public class PatientTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task Index_ReturnsView()
		{
			// arrange
			var mockService = new Mock<IPatientService>();
			mockService.Setup(service => service.RetrievePatientListAsync()).ReturnsAsync(new List<Patient>());
			var sut = new PatientsController(mockService.Object);
			// act
			var result = await sut.Index();
			// assert
			Assert.That(result, Is.InstanceOf<ViewResult>());
		}
	}
}